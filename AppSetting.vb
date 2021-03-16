Public Class AppSetting

	Private oDS As New Data.DataSet
	Private oTable As New Data.DataTable
	Private sFilePath As String = ""

	Public Sub New()
		Dim sAssPath As String = System.Reflection.Assembly.GetExecutingAssembly().Location
		Dim sPath As String = System.IO.Path.GetDirectoryName(sAssPath)
		sFilePath = System.IO.Path.Combine(sPath, "PdfSign2.xml")

		LoadData()
	End Sub

	Private Sub LoadData()
		oDS = New Data.DataSet()

		If System.IO.File.Exists(sFilePath) Then
			oDS.ReadXml(sFilePath)
			If oDS.Tables.Count > 0 Then
				oTable = oDS.Tables(0)
				Exit Sub
			End If
		End If

		'setup New
		oTable = New Data.DataTable()
		oTable.Columns.Add(New Data.DataColumn("key"))
		oTable.Columns.Add(New Data.DataColumn("value"))
		oDS.Tables.Add(oTable)
	End Sub

	Public Sub SaveData()

		If System.IO.File.Exists(sFilePath) Then
			Dim oFileAttr As IO.FileAttributes = IO.File.GetAttributes(sFilePath)
			If oFileAttr.HasFlag(IO.FileAttributes.Hidden) Then
				IO.File.SetAttributes(sFilePath, System.IO.FileAttributes.Normal)
			End If
		End If

		oTable.DataSet.WriteXml(sFilePath, XmlWriteMode.WriteSchema)

		Dim oFileAttributes As IO.FileAttributes = IO.File.GetAttributes(sFilePath)
		If oFileAttributes.HasFlag(IO.FileAttributes.Hidden) = False Then
			IO.File.SetAttributes(sFilePath, System.IO.FileAttributes.Hidden)
		End If

	End Sub

	Public Sub SetValue(ByVal sKey As String, ByVal sValue As String)

		Dim oDataRow As DataRow
		Dim oDataRows As DataRow() = oTable.Select("key = '" & Replace(sKey, "'", "''") & "'")
		If oDataRows.Length > 0 Then
			oDataRows(0)("value") = sValue
		Else
			oDataRow = oTable.NewRow()
			oDataRow("key") = sKey
			oDataRow("value") = sValue
			oTable.Rows.Add(oDataRow)
		End If

	End Sub

	Public Function GetValue(ByVal sKey As String) As String

		Dim oDataRows As DataRow() = oTable.Select("key = '" & Replace(sKey, "'", "''") & "'")
		If oDataRows.Length > 0 Then
			Return oDataRows(0)("value") & ""
		End If


		Return ""
	End Function

	Public Function GetValueDef(ByVal sKey As String, ByVal sDefVal As String) As String
		Dim sValue As String = GetValue(sKey)
		If sValue <> "" Then
			Return sValue
		End If

		Return sDefVal
	End Function
End Class