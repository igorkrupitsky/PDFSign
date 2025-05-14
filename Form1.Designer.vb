<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnProcess = New System.Windows.Forms.Button()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.txtLeftMargin = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtHeight = New System.Windows.Forms.TextBox()
        Me.txtWidth = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtInputFolder = New System.Windows.Forms.TextBox()
        Me.btnInputFolder = New System.Windows.Forms.Button()
        Me.btnOutputFolder = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtOutputFolder = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFind = New System.Windows.Forms.TextBox()
        Me.lblOffset = New System.Windows.Forms.Label()
        Me.txtBottomMargin = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'btnProcess
        '
        Me.btnProcess.Location = New System.Drawing.Point(132, 365)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(177, 43)
        Me.btnProcess.TabIndex = 0
        Me.btnProcess.Text = "Process"
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'txtOutput
        '
        Me.txtOutput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOutput.Location = New System.Drawing.Point(12, 414)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.Size = New System.Drawing.Size(797, 194)
        Me.txtOutput.TabIndex = 1
        '
        'txtLeftMargin
        '
        Me.txtLeftMargin.Location = New System.Drawing.Point(132, 79)
        Me.txtLeftMargin.Name = "txtLeftMargin"
        Me.txtLeftMargin.Size = New System.Drawing.Size(100, 26)
        Me.txtLeftMargin.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Left Margin"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(400, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Height"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(406, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 20)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Width"
        '
        'txtHeight
        '
        Me.txtHeight.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHeight.Location = New System.Drawing.Point(463, 108)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(309, 26)
        Me.txtHeight.TabIndex = 7
        '
        'txtWidth
        '
        Me.txtWidth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWidth.Location = New System.Drawing.Point(463, 76)
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(309, 26)
        Me.txtWidth.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 20)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Input Folder"
        '
        'txtInputFolder
        '
        Me.txtInputFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInputFolder.Location = New System.Drawing.Point(132, 12)
        Me.txtInputFolder.Name = "txtInputFolder"
        Me.txtInputFolder.Size = New System.Drawing.Size(640, 26)
        Me.txtInputFolder.TabIndex = 10
        Me.txtInputFolder.Text = "C:\Users\80014379\Downloads"
        '
        'btnInputFolder
        '
        Me.btnInputFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInputFolder.Location = New System.Drawing.Point(778, 12)
        Me.btnInputFolder.Name = "btnInputFolder"
        Me.btnInputFolder.Size = New System.Drawing.Size(31, 34)
        Me.btnInputFolder.TabIndex = 12
        Me.btnInputFolder.Text = "..."
        Me.btnInputFolder.UseVisualStyleBackColor = True
        '
        'btnOutputFolder
        '
        Me.btnOutputFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOutputFolder.Location = New System.Drawing.Point(778, 44)
        Me.btnOutputFolder.Name = "btnOutputFolder"
        Me.btnOutputFolder.Size = New System.Drawing.Size(31, 36)
        Me.btnOutputFolder.TabIndex = 15
        Me.btnOutputFolder.Text = "..."
        Me.btnOutputFolder.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 20)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Output Folder"
        '
        'txtOutputFolder
        '
        Me.txtOutputFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOutputFolder.Location = New System.Drawing.Point(132, 44)
        Me.txtOutputFolder.Name = "txtOutputFolder"
        Me.txtOutputFolder.Size = New System.Drawing.Size(640, 26)
        Me.txtOutputFolder.TabIndex = 13
        Me.txtOutputFolder.Text = "C:\Users\80014379\Downloads\output"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 614)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(797, 14)
        Me.ProgressBar1.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(79, 151)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 20)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Find"
        '
        'txtFind
        '
        Me.txtFind.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFind.Location = New System.Drawing.Point(132, 148)
        Me.txtFind.Multiline = True
        Me.txtFind.Name = "txtFind"
        Me.txtFind.Size = New System.Drawing.Size(640, 211)
        Me.txtFind.TabIndex = 18
        '
        'lblOffset
        '
        Me.lblOffset.AutoSize = True
        Me.lblOffset.Location = New System.Drawing.Point(13, 114)
        Me.lblOffset.Name = "lblOffset"
        Me.lblOffset.Size = New System.Drawing.Size(113, 20)
        Me.lblOffset.TabIndex = 20
        Me.lblOffset.Text = "Bottom Margin"
        '
        'txtBottomMargin
        '
        Me.txtBottomMargin.Location = New System.Drawing.Point(132, 111)
        Me.txtBottomMargin.Name = "txtBottomMargin"
        Me.txtBottomMargin.Size = New System.Drawing.Size(100, 26)
        Me.txtBottomMargin.TabIndex = 19
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 639)
        Me.Controls.Add(Me.lblOffset)
        Me.Controls.Add(Me.txtBottomMargin)
        Me.Controls.Add(Me.txtFind)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnOutputFolder)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtOutputFolder)
        Me.Controls.Add(Me.btnInputFolder)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtInputFolder)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtHeight)
        Me.Controls.Add(Me.txtWidth)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtLeftMargin)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.btnProcess)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Form1"
        Me.Text = "Pdf Sign"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnProcess As Button
    Friend WithEvents txtOutput As TextBox
    Friend WithEvents txtLeftMargin As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtHeight As TextBox
    Friend WithEvents txtWidth As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtInputFolder As TextBox
    Friend WithEvents btnInputFolder As Button
    Friend WithEvents btnOutputFolder As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents txtOutputFolder As TextBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label7 As Label
    Friend WithEvents txtFind As TextBox
    Friend WithEvents lblOffset As Label
    Friend WithEvents txtBottomMargin As TextBox
    Friend WithEvents ToolTip1 As ToolTip
End Class
