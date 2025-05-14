Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports iTextSharp.text.pdf.parser

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim oAppRegistry As New AppSetting
        txtBottomMargin.Text = oAppRegistry.GetValueDef("BottomMargin", "10")
        txtLeftMargin.Text = oAppRegistry.GetValueDef("LeftMargin", "18")
        txtWidth.Text = oAppRegistry.GetValueDef("Width", "335")
        txtHeight.Text = oAppRegistry.GetValueDef("Height", "28")
        txtInputFolder.Text = oAppRegistry.GetValueDef("InputFolder", "")
        txtOutputFolder.Text = oAppRegistry.GetValueDef("OutputFolder", "")
        txtFind.Text = oAppRegistry.GetValueDef("Find", "Provider Signature/Date/Time:")
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim oAppRegistry As New AppSetting
        oAppRegistry.SetValue("BottomMargin", txtBottomMargin.Text)
        oAppRegistry.SetValue("LeftMargin", txtLeftMargin.Text)
        oAppRegistry.SetValue("Width", txtWidth.Text)
        oAppRegistry.SetValue("Height", txtHeight.Text)
        oAppRegistry.SetValue("InputFolder", txtInputFolder.Text)
        oAppRegistry.SetValue("OutputFolder", txtOutputFolder.Text)
        oAppRegistry.SetValue("Find", txtFind.Text)
        oAppRegistry.SaveData()
    End Sub

    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click

        If txtBottomMargin.Text = "" Then
            MsgBox("Bottom Margin not set")
            Exit Sub
        End If

        If txtLeftMargin.Text = "" Then
            MsgBox("Left Margin not set")
            Exit Sub
        End If

        If txtWidth.Text = "" Then
            MsgBox("Width not set")
            Exit Sub
        End If

        If txtHeight.Text = "" Then
            MsgBox("Height not set")
            Exit Sub
        End If

        Dim sFromPath As String = txtInputFolder.Text
        If Not System.IO.Directory.Exists(sFromPath) Then
            MsgBox("Folder does not exist")
            Exit Sub
        End If

        txtOutput.Text = ""
        txtOutput.Text += "Starting..." & vbCrLf
        ProccessFolder(sFromPath, txtOutputFolder.Text)
        txtOutput.Text += "Done!"

        Try
            Process.Start(txtOutputFolder.Text)
        Catch ex As Exception

        End Try

    End Sub

    Sub ProccessFolder(ByVal sFromPath As String, ByVal sToPath As String)

        If Not Directory.Exists(sToPath) Then
            Try
                Directory.CreateDirectory(sToPath)
            Catch ex As Exception
                MsgBox("To folder does not exist and could not be created.")
                Exit Sub
            End Try
        End If

        Dim oFiles As String() = Directory.GetFiles(sFromPath)
        ProgressBar1.Maximum = oFiles.Length

        btnProcess.Enabled = False
        For i As Integer = 0 To oFiles.Length - 1
            Dim sFromFilePath As String = oFiles(i)
            Dim oFileInfo As New FileInfo(sFromFilePath)
            Dim sToFileName As String = sToPath & "\" & oFileInfo.Name

            If UCase(oFileInfo.Extension) = ".PDF" Then

                If System.IO.File.Exists(sToFileName) Then
                    Try
                        System.IO.File.Delete(sToFileName)
                    Catch ex As Exception
                        txtOutput.Text += sFromFilePath & ", File already exists and cannot be deleted: " & ex.Message & vbCrLf
                    End Try
                End If

                If System.IO.File.Exists(sToFileName) = False Then
                    Try
                        EncryptPdf(sFromFilePath, sToFileName)
                        txtOutput.Text += sFromFilePath & vbCrLf
                    Catch ex As Exception
                        txtOutput.Text += sFromFilePath & ", Error: " & ex.Message & vbCrLf
                    End Try
                End If
            End If

            ProgressBar1.Value = i
        Next

        btnProcess.Enabled = True
        ProgressBar1.Value = 0

        Dim oFolders As String() = Directory.GetDirectories(sFromPath)
        For i As Integer = 0 To oFolders.Length - 1
            Dim sChildFolder As String = oFolders(i)
            Dim iPos As Integer = sChildFolder.LastIndexOf("\")
            Dim sFolderName As String = sChildFolder.Substring(iPos + 1)
            If sChildFolder <> sToPath Then
                ProccessFolder(sChildFolder, sToPath & "\" & sFolderName)
            End If
        Next

    End Sub


    Sub EncryptPdf(ByVal sInFilePath As String, ByVal sOutFilePath As String)

        Dim oPdfReader As iTextSharp.text.pdf.PdfReader = New iTextSharp.text.pdf.PdfReader(sInFilePath)
        Dim oPdfDoc As New iTextSharp.text.Document()
        Dim oPdfWriter As PdfWriter = PdfWriter.GetInstance(oPdfDoc, New FileStream(sOutFilePath, FileMode.Create))
        'oPdfWriter.SetEncryption(PdfWriter.STRENGTH40BITS, sPassword, sPassword, PdfWriter.AllowCopy)
        oPdfDoc.Open()

        oPdfDoc.SetPageSize(iTextSharp.text.PageSize.LEDGER.Rotate())

        Dim oDirectContent As iTextSharp.text.pdf.PdfContentByte = oPdfWriter.DirectContent
        Dim iNumberOfPages As Integer = oPdfReader.NumberOfPages
        Dim iPage As Integer = 0

        Dim iBottomMargin As Integer = txtBottomMargin.Text '10
        Dim iLeftMargin As Integer = txtLeftMargin.Text '18
        Dim iWidth As Integer = txtWidth.Text '120
        Dim iHeight As Integer = txtHeight.Text '780

        Dim oStrategy As New parser.SimpleTextExtractionStrategy()


        Do While (iPage < iNumberOfPages)
            iPage += 1
            oPdfDoc.SetPageSize(oPdfReader.GetPageSizeWithRotation(iPage))
            oPdfDoc.NewPage()

            Dim oPdfImportedPage As iTextSharp.text.pdf.PdfImportedPage =
            oPdfWriter.GetImportedPage(oPdfReader, iPage)
            Dim iRotation As Integer = oPdfReader.GetPageRotation(iPage)
            If (iRotation = 90) Or (iRotation = 270) Then
                oDirectContent.AddTemplate(oPdfImportedPage, 0, -1.0F, 1.0F,
                 0, 0, oPdfReader.GetPageSizeWithRotation(iPage).Height)
            Else
                oDirectContent.AddTemplate(oPdfImportedPage, 1.0F, 0, 0, 1.0F, 0, 0)
            End If

            'Dim sPageText As String = parser.PdfTextExtractor.GetTextFromPage(oPdfReader, iPage, oStrategy)
            'sPageText = System.Text.Encoding.UTF8.GetString(System.Text.ASCIIEncoding.Convert(System.Text.Encoding.Default, System.Text.Encoding.UTF8, System.Text.Encoding.Default.GetBytes(sPageText)))
            'If txtFind.Text = "" OrElse sPageText.IndexOf(txtFind.Text) <> -1 Then

            Dim oTextExtractor As New TextExtractor()
            PdfTextExtractor.GetTextFromPage(oPdfReader, iPage, oTextExtractor) 'Initialize oTextExtractor



            Dim oFind As String() = System.Text.RegularExpressions.Regex.Split(txtFind.Text, vbCrLf)
            For Each sFind In oFind

                Dim oRect As iTextSharp.text.Rectangle = oTextExtractor.Find(sFind)

                If oRect Is Nothing Then
                    ' Try to find text manually
                    Dim oLines As New Hashtable
                    For i = 0 To oTextExtractor.oPoints.Count - 1
                        Dim r As RectAndText = oTextExtractor.oPoints(i)

                        If oLines.ContainsKey(r.Rect.Top) Then
                            oLines(r.Rect.Top) += " " & r.Text
                        Else
                            oLines(r.Rect.Top) = r.Text
                        End If

                        Dim sLine As String = oLines(r.Rect.Top) & ""
                        If sLine.IndexOf(sFind) <> -1 Then
                            oRect = r.Rect
                            Exit For
                        End If
                    Next
                End If

                If oRect IsNot Nothing Then
                    Dim iX As Integer = oRect.Left + oRect.Width + iLeftMargin 'Move right
                    Dim iY As Integer = oRect.Bottom - iBottomMargin 'Move down

                    Dim field As PdfFormField = PdfFormField.CreateSignature(oPdfWriter)
                    field.SetWidget(New Rectangle(iX, iY, iX + iWidth, iY + iHeight), PdfAnnotation.HIGHLIGHT_OUTLINE)
                    field.FieldName = "myEmptySignatureField" & iPage
                    oPdfWriter.AddAnnotation(field)
                End If
            Next




        Loop

        oPdfDoc.Close()

    End Sub

    Private Sub btnInputFolder_Click(sender As Object, e As EventArgs) Handles btnInputFolder.Click
        FolderBrowserDialog1.ShowDialog()
        txtInputFolder.Text = FolderBrowserDialog1.SelectedPath

        If txtOutputFolder.Text = "" Then
            txtOutputFolder.Text = System.IO.Path.Combine(txtInputFolder.Text, "Output")
        End If

    End Sub

    Private Sub btnOutputFolder_Click(sender As Object, e As EventArgs) Handles btnOutputFolder.Click
        FolderBrowserDialog1.ShowDialog()
        txtOutputFolder.Text = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub lblOffset_MouseHover(sender As Object, e As EventArgs) Handles lblOffset.MouseHover
        ToolTip1.SetToolTip(lblOffset, "Optional.  Will move the sign box x pixels down.  This option will be used when the position off search text is found on the PDF page.")
    End Sub

End Class

Class TextExtractor
    Inherits LocationTextExtractionStrategy
    Implements iTextSharp.text.pdf.parser.ITextExtractionStrategy
    Public oPoints As IList(Of RectAndText) = New List(Of RectAndText)
    Public Overrides Sub RenderText(renderInfo As TextRenderInfo) 'Implements IRenderListener.RenderText
        'https://stackoverflow.com/questions/23909893/getting-coordinates-of-string-using-itextextractionstrategy-and-locationtextextr
        MyBase.RenderText(renderInfo)

        Dim bottomLeft As Vector = renderInfo.GetDescentLine().GetStartPoint()
        Dim topRight As Vector = renderInfo.GetAscentLine().GetEndPoint() 'GetBaseline

        Dim rect As Rectangle = New Rectangle(bottomLeft(Vector.I1), bottomLeft(Vector.I2), topRight(Vector.I1), topRight(Vector.I2))
        oPoints.Add(New RectAndText(rect, renderInfo.GetText()))
    End Sub

    Private Function GetLines() As Dictionary(Of Single, ArrayList)
        Dim oLines As New Dictionary(Of Single, ArrayList)
        For Each p As RectAndText In oPoints
            Dim iBottom = p.Rect.Bottom

            If oLines.ContainsKey(iBottom) = False Then
                oLines(iBottom) = New ArrayList()
            End If

            oLines(iBottom).Add(p)
        Next

        Return oLines
    End Function

    Public Function Find(ByVal sFind As String) As iTextSharp.text.Rectangle
        Dim oLines As Dictionary(Of Single, ArrayList) = GetLines()

        For Each oEntry As KeyValuePair(Of Single, ArrayList) In oLines
            'Dim iBottom As Integer = oEntry.Key
            Dim oRectAndTexts As ArrayList = oEntry.Value
            Dim sLine As String = ""
            For Each p As RectAndText In oRectAndTexts
                sLine += p.Text
                If sLine.IndexOf(sFind) <> -1 Then
                    Return p.Rect
                End If
            Next
        Next

        Return Nothing
    End Function

End Class

Public Class RectAndText
    Public Rect As iTextSharp.text.Rectangle
    Public Text As String
    Public Sub New(ByVal rect As iTextSharp.text.Rectangle, ByVal text As String)
        Me.Rect = rect
        Me.Text = text
    End Sub
End Class
