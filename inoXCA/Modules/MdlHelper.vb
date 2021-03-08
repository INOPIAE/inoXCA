Module MdlHelper

    Public clsLang = New ClsLanguage
    Public lastPassword As String
    Public lastFilename As String

    Public Sub MyMessage(strMessage As String, Optional strCaption As String = vbNullString)
        Dim strCaptionPrint As String = vbNullString
        If strCaption <> vbNullString Then
            strCaptionPrint = " - " & strCaption
        End If
        MessageBox.Show(strMessage, Application.ProductName & strCaptionPrint)
    End Sub
End Module
