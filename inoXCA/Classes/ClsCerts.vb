Imports System.IO

Public Class ClsCerts
    Public Enum CertType
        Certificate
        PrivateKey
        EncryptedPrivateKey
        CSR
        CRL
    End Enum

    Public CertText(4) As String

    Public Sub New()
        CertText(0) = "CERTIFICATE"
        CertText(1) = "PRIVATE KEY"
        CertText(2) = "ENCRYPTED PRIVATE KEY"
        CertText(3) = "CERTIFICATE REQUEST"
        CertText(4) = "X509 CRL"
    End Sub

    Public Function PEMString(certpart As String, type As CertType) As String
        Dim PEM As String
        PEM = String.Format("-----BEGIN {0}-----", CertText(type)) & vbNewLine
        For i As Integer = 0 To certpart.Length - 1 Step 64
            If Len(certpart.Substring(i)) > 64 Then
                PEM &= certpart.Substring(i, 64) & vbNewLine
            Else
                PEM &= certpart.Substring(i) & vbNewLine
            End If
        Next
        PEM &= String.Format("-----END {0}-----", CertText(type))
        Return PEM
    End Function

End Class
