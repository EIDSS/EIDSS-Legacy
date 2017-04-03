Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography


Public Class Rijndael
    ''' <summary>
    ''' Encrypts specified plaintext using Rijndael symmetric key algorithm
    ''' and returns a base64-encoded result.
    ''' </summary>
    ''' <param name="plainText">
    ''' Plaintext value to be encrypted.
    ''' </param>
    ''' <param name="passPhrase">
    ''' Passphrase from which a pseudo-random password will be derived. The
    ''' derived password will be used to generate the encryption key.
    ''' Passphrase can be any string. In this example we assume that this
    ''' passphrase is an ASCII string.
    ''' </param>
    ''' <param name="saltValue">
    ''' Salt value used along with passphrase to generate password. Salt can
    ''' be any string. In this example we assume that salt is an ASCII string.
    ''' </param>
    ''' <param name="passwordIterations">
    ''' Number of iterations used to generate password. One or two iterations
    ''' should be enough.
    ''' </param>
    ''' <param name="initVector">
    ''' Initialization vector (or IV). This value is required to encrypt the
    ''' first block of plaintext data. For RijndaelManaged class IV must be
    ''' exactly 16 ASCII characters long.
    ''' </param>
    ''' <param name="keySize">
    ''' Size of encryption key in bits. Allowed values are: 128, 192, and 256.
    ''' Longer keys are more secure than shorter keys.
    ''' </param>
    ''' <returns>
    ''' Encrypted value formatted as a base64-encoded string.
    ''' </returns>
    Public Shared Function Encrypt(ByVal plainText As String, ByVal passPhrase As String, ByVal saltValue As String, ByVal passwordIterations As Integer, ByVal initVector As String, _
    ByVal keySize As Integer) As String
        Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
        Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)
        Dim plainTextBytes As Byte() = Encoding.UTF8.GetBytes(plainText)

        'Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)
        Dim password As New Rfc2898DeriveBytes(passPhrase, saltValueBytes, passwordIterations)
        Dim keyBytes As Byte() = password.GetBytes(CInt(keySize / 8))
        Dim symmetricKey As New RijndaelManaged()

        symmetricKey.Mode = CipherMode.CBC

        Dim encryptor As ICryptoTransform = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes)
        Dim memoryStream As New MemoryStream()
        Dim cryptoStream As New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)

        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)
        cryptoStream.FlushFinalBlock()
        Dim cipherTextBytes As Byte() = memoryStream.ToArray()

        memoryStream.Close()
        cryptoStream.Close()
        Dim cipherText As String = Convert.ToBase64String(cipherTextBytes)

        Return cipherText
    End Function

    ''' <summary>
    ''' Decrypts specified ciphertext using Rijndael symmetric key algorithm.
    ''' </summary>
    ''' <param name="cipherText">
    ''' Base64-formatted ciphertext value.
    ''' </param>
    ''' <param name="passPhrase">
    ''' Passphrase from which a pseudo-random password will be derived. The
    ''' derived password will be used to generate the encryption key.
    ''' Passphrase can be any string. In this example we assume that this
    ''' passphrase is an ASCII string.
    ''' </param>
    ''' <param name="saltValue">
    ''' Salt value used along with passphrase to generate password. Salt can
    ''' be any string. In this example we assume that salt is an ASCII string.
    ''' </param>
    ''' <param name="passwordIterations">
    ''' Number of iterations used to generate password. One or two iterations
    ''' should be enough.
    ''' </param>
    ''' <param name="initVector">
    ''' Initialization vector (or IV). This value is required to encrypt the
    ''' first block of plaintext data. For RijndaelManaged class IV must be
    ''' exactly 16 ASCII characters long.
    ''' </param>
    ''' <param name="keySize">
    ''' Size of encryption key in bits. Allowed values are: 128, 192, and 256.
    ''' Longer keys are more secure than shorter keys.
    ''' </param>
    ''' <returns>
    ''' Decrypted string value.
    ''' </returns>
    ''' <remarks>
    ''' Most of the logic in this function is similar to the Encrypt
    ''' logic. In order for decryption to work, all parameters of this function
    ''' - except cipherText value - must match the corresponding parameters of
    ''' the Encrypt function which was called to generate the
    ''' ciphertext.
    ''' </remarks>
    Public Shared Function Decrypt(ByVal cipherText As String, ByVal passPhrase As String, ByVal saltValue As String, ByVal passwordIterations As Integer, ByVal initVector As String, _
    ByVal keySize As Integer) As String
        Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
        Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)
        Dim cipherTextBytes As Byte() = Convert.FromBase64String(cipherText)

        'Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)
        Dim password As New Rfc2898DeriveBytes(passPhrase, saltValueBytes, passwordIterations)
        Dim keyBytes As Byte() = password.GetBytes(CInt(keySize / 8))
        Dim symmetricKey As New RijndaelManaged()
        symmetricKey.Mode = CipherMode.CBC

        Dim decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)
        Dim memoryStream As New MemoryStream(cipherTextBytes)
        Dim cryptoStream As New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)
        Dim plainTextBytes As Byte() = New Byte(cipherTextBytes.Length - 1) {}

        Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)

        memoryStream.Close()
        cryptoStream.Close()

        Dim plainText As String = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount)

        Return plainText
    End Function
End Class

Public Class Cryptor
    Shared passPhrase As String = "Error occured"      ' can be any string
    Shared saltValue As String = "exception"           ' can be any string
    Shared passwordIterations As Integer = 2           ' can be any number
    Shared initVector As String = "Dfdfgnds2445ZldE"   ' must be 16 bytes
    Shared keySize As Integer = 256                    ' can be 128 or 256

    Public Shared Function Encrypt(ByVal enryptedString As String) As String
        Dim decryptedString As String
        decryptedString = Rijndael.Encrypt _
                            ( _
                                enryptedString, _
                                passPhrase, _
                                saltValue, _
                                passwordIterations, _
                                initVector, _
                                keySize _
                            )
        Return (decryptedString)
    End Function
    Public Shared Function Encrypt(ByVal enryptedString As String, ByVal passPhrase As String) As String
        Dim decryptedString As String
        decryptedString = Rijndael.Encrypt _
                            ( _
                                enryptedString, _
                                passPhrase, _
                                saltValue, _
                                passwordIterations, _
                                initVector, _
                                keySize _
                            )
        Return (decryptedString)
    End Function
    Public Shared Function Decrypt(ByVal encryptedString As String) As String
        Dim decryptedString As String
        decryptedString = Rijndael.Decrypt _
                            ( _
                                encryptedString, _
                                passPhrase, _
                                saltValue, _
                                passwordIterations, _
                                initVector, _
                                keySize _
                            )
        Return (decryptedString)
    End Function
    Public Shared Function Decrypt(ByVal encryptedString As String, ByVal passPhrase As String) As String
        Dim decryptedString As String
        decryptedString = Rijndael.Decrypt _
                            ( _
                                encryptedString, _
                                passPhrase, _
                                saltValue, _
                                passwordIterations, _
                                initVector, _
                                keySize _
                            )
        Return (decryptedString)
    End Function

End Class

