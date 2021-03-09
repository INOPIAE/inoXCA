Imports System.IO
Imports System.Text

Public Class ClsOpenSSL
    Public privateKey As String = My.Settings.CertFolder & "\mypriv.key"
    Public publicKey As String = My.Settings.CertFolder & "\my.key"

    Public Sub CreateCSRConfig(cn As String, email As String, Optional keysize As Int16 = 4096, Optional OU As String = vbNullString)
        Dim path As String = My.Settings.CertFolder & "\mycsr.cnf"

        Dim content As String = "[req]" & vbNewLine
        content &= "default_bits = " & keysize & vbNewLine
        content &= "default_md = sha256" & vbNewLine
        content &= "prompt = no" & vbNewLine
        content &= "encrypt_key = no" & vbNewLine
        content &= "distinguished_name = dn" & vbNewLine
        content &= "utf8 = yes" & vbNewLine
        content &= "[dn]" & vbNewLine
        content &= "emailAddress = " & email & vbNewLine
        content &= "CN = " & cn
        If OU <> vbNullString Then
            content &= vbNewLine & "OU = " & OU
        End If

        File.WriteAllText(path, content)
    End Sub

    Public Function CreateCSR(filename As String) As Boolean
        Dim Arguments As String = " req -new -config """ & My.Settings.CertFolder & "\mycsr.cnf"" -keyout """ & My.Settings.CertFolder & "\myprivate.key"" -out """ & My.Settings.CertFolder & "\mycsr.csr"
        Dim sOutput As String = UseOpenSSL(Arguments)
        Debug.Print(sOutput)
        If sOutput.Contains("problems making Certificate Request") Then
            Debug.Print(sOutput)
            Return False
        Else
            Return True
        End If

    End Function

    Public Function CreateCSR(filename As String, password As String) As Boolean
        Dim Arguments As String = " req -new -config """ & My.Settings.CertFolder & "\mycsr.cnf"" -keyout """ & My.Settings.CertFolder & "\" & filename & ".key"" -passout pass:""" & password & """ -out """ & My.Settings.CertFolder & "\" & filename & ".csr"
        Dim sOutput As String = UseOpenSSL(Arguments)
        Debug.Print(sOutput)
        If sOutput.Contains("problems making Certificate Request") Then
            Debug.Print(sOutput)
            Return False
        Else
            Return True
        End If

    End Function

    Private Shared Function UseOpenSSL(Arguments As String) As String
        Dim CertUtilPath As String = Application.StartupPath & "\lib\openssl\"
        Dim startInfo As New ProcessStartInfo
        Dim myProcess As New Process()
        startInfo.UseShellExecute = False
        startInfo.RedirectStandardOutput = True
        startInfo.RedirectStandardError = True
        startInfo.CreateNoWindow = True
        startInfo.FileName = CertUtilPath & "openssl"
        startInfo.Arguments = Arguments
        myProcess.StartInfo = startInfo
        myProcess.Start()

        Dim sOutput As String
        Using oStreamReader As System.IO.StreamReader = myProcess.StandardOutput
            sOutput = oStreamReader.ReadToEnd()
        End Using

        Dim sOutputError As String
        Using oStreamReader As System.IO.StreamReader = myProcess.StandardError
            sOutputError = oStreamReader.ReadToEnd()
        End Using

        If sOutputError.Count = 0 Then
            Return sOutput
        Else
            Return sOutputError
        End If
    End Function

    Public Function CreateP12(password As String, Filename As String) As Boolean
        Dim Arguments As String = " pkcs12 -export -out """ & My.Settings.CertFolder & "\" & Filename & ".p12"" -in """ & My.Settings.CertFolder & "\" & Filename & ".pem"" -inkey """ & My.Settings.CertFolder & "\" & Filename & ".key"" -passin pass:""" & password & """ -passout pass:""" & password & """"
        Dim sOutput As String = UseOpenSSL(Arguments)
        Debug.Print(sOutput)
        If sOutput.Contains("problems making Certificate Request") Then
            Debug.Print(sOutput)
            Return False
        Else
            Return True
        End If

    End Function

    Public Function CreateP12(passwordIn As String, passwordOut As String, Filename As String) As Boolean
        Dim Arguments As String = " pkcs12 -export -out """ & Filename & """ -in """ & publicKey & """ -inkey """ & privateKey & """ -passin pass:""" & passwordIn & """ -passout pass:""" & passwordOut & """"
        Dim sOutput As String = UseOpenSSL(Arguments)
        Debug.Print(sOutput)
        If sOutput.Contains("unable to load private key") Then
            MessageBox.Show(clsLang.rm.getString("MsgCertLoadError"), clsLang.rm.getString("MsgHint"))
            Return False
        Else
            Return True
        End If

    End Function

    Public Function OpenSSLVersion() As String
        Dim Arguments As String = " version"
        Return UseOpenSSL(Arguments)
    End Function

End Class
