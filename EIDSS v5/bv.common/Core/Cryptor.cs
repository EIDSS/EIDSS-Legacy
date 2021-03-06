using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;



namespace bv.common.Core
{
	public class Rijndael
	{
		
		/// <summary>
		/// Encrypts specified plaintext using Rijndael symmetric key algorithm
		/// and returns a base64-encoded result.
		/// </summary>
		/// <param name="plainText">
		/// Plaintext value to be encrypted.
		/// </param>
		/// <param name="passPhrase">
		/// Passphrase from which a pseudo-random password will be derived. The
		/// derived password will be used to generate the encryption key.
		/// Passphrase can be any string. In this example we assume that this
		/// passphrase is an ASCII string.
		/// </param>
		/// <param name="saltValue">
		/// Salt value used along with passphrase to generate password. Salt can
		/// be any string. In this example we assume that salt is an ASCII string.
		/// </param>
		/// <param name="passwordIterations">
		/// Number of iterations used to generate password. One or two iterations
		/// should be enough.
		/// </param>
		/// <param name="initVector">
		/// Initialization vector (or IV). This value is required to encrypt the
		/// first block of plaintext data. For RijndaelManaged class IV must be
		/// exactly 16 ASCII characters long.
		/// </param>
		/// <param name="keySize">
		/// Size of encryption key in bits. Allowed values are: 128, 192, and 256.
		/// Longer keys are more secure than shorter keys.
		/// </param>
		/// <returns>
		/// Encrypted value formatted as a base64-encoded string.
		/// </returns>
		public static string Encrypt(string plainText, string passPhrase, string saltValue, int passwordIterations, string initVector, int keySize)
			{
			byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
			byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
			byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
			
			//Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)
			Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passPhrase, saltValueBytes, passwordIterations);
			byte[] keyBytes = password.GetBytes(keySize / 8);
			RijndaelManaged symmetricKey = new RijndaelManaged();
			
			symmetricKey.Mode = CipherMode.CBC;
			
			ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
			
			cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
			cryptoStream.FlushFinalBlock();
			byte[] cipherTextBytes = memoryStream.ToArray();
			
			memoryStream.Close();
			cryptoStream.Close();
			string cipherText = Convert.ToBase64String(cipherTextBytes);
			
			return cipherText;
		}
		
		/// <summary>
		/// Decrypts specified ciphertext using Rijndael symmetric key algorithm.
		/// </summary>
		/// <param name="cipherText">
		/// Base64-formatted ciphertext value.
		/// </param>
		/// <param name="passPhrase">
		/// Passphrase from which a pseudo-random password will be derived. The
		/// derived password will be used to generate the encryption key.
		/// Passphrase can be any string. In this example we assume that this
		/// passphrase is an ASCII string.
		/// </param>
		/// <param name="saltValue">
		/// Salt value used along with passphrase to generate password. Salt can
		/// be any string. In this example we assume that salt is an ASCII string.
		/// </param>
		/// <param name="passwordIterations">
		/// Number of iterations used to generate password. One or two iterations
		/// should be enough.
		/// </param>
		/// <param name="initVector">
		/// Initialization vector (or IV). This value is required to encrypt the
		/// first block of plaintext data. For RijndaelManaged class IV must be
		/// exactly 16 ASCII characters long.
		/// </param>
		/// <param name="keySize">
		/// Size of encryption key in bits. Allowed values are: 128, 192, and 256.
		/// Longer keys are more secure than shorter keys.
		/// </param>
		/// <returns>
		/// Decrypted string value.
		/// </returns>
		/// <remarks>
		/// Most of the logic in this function is similar to the Encrypt
		/// logic. In order for decryption to work, all parameters of this function
		/// - except cipherText value - must match the corresponding parameters of
		/// the Encrypt function which was called to generate the
		/// ciphertext.
		/// </remarks>
		public static string Decrypt(string cipherText, string passPhrase, string saltValue, int passwordIterations, string initVector, int keySize)
			{
			byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
			byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
			byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
			
			//Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)
			Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passPhrase, saltValueBytes, passwordIterations);
			byte[] keyBytes = password.GetBytes(keySize / 8);
			RijndaelManaged symmetricKey = new RijndaelManaged();
			symmetricKey.Mode = CipherMode.CBC;
			
			ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
			MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
			CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
			byte[] plainTextBytes = new byte[cipherTextBytes.Length - 1+ 1];
			
			int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
			
			memoryStream.Close();
			cryptoStream.Close();
			
			string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
			
			return plainText;
		}
	}
	
	public class Cryptor
	{
		
		static string passPhrase = "Error occured"; // can be any string
		static string saltValue = "exception"; // can be any string
		static int passwordIterations = 2; // can be any number
		static string initVector = "HG123jdtemA23N33"; // must be 16 bytes
		static int keySize = 256; // can be 128 or 256
		
		public static string Encrypt(string enryptedString)
		{
			string decryptedString;
			decryptedString = Rijndael.Encrypt(enryptedString, passPhrase, saltValue, passwordIterations, initVector, keySize);
			return (decryptedString);
		}
		public static string Encrypt(string enryptedString, string passPhrase)
		{
			string decryptedString;
			decryptedString = Rijndael.Encrypt(enryptedString, passPhrase, saltValue, passwordIterations, initVector, keySize);
			return (decryptedString);
		}
		public static string Decrypt(string encryptedString)
		{
			string decryptedString;
			decryptedString = Rijndael.Decrypt(encryptedString, passPhrase, saltValue, passwordIterations, initVector, keySize);
			return (decryptedString);
		}
		public static string Decrypt(string encryptedString, string passPhrase)
		{
			string decryptedString;
			decryptedString = Rijndael.Decrypt(encryptedString, passPhrase, saltValue, passwordIterations, initVector, keySize);
			return (decryptedString);
		}
		
	}
	
	
}
