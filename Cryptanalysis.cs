using System;
using System.Net.Security;
using System.Security;
using System.Security.Cryptography;

public class Cryptanalysis
{
    public static void Main(string[] args)
        {
            string secretString = args[0];
            string argsCipherText = args[1];
            int result = finder(secretString, argsCipherText);
            Console.WriteLine(result);
        }

    private static string Encrypt(byte[] key, string secretString)
        {
            DESCryptoServiceProvider csp = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, csp.CreateEncryptor(key, key), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cs);
            sw.Write(secretString);
            sw.Flush();
            cs.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }
 
    public static int finder(string secretString, string argsCipherText) 
        {
            string cipherText = "";
            DateTime dtStart = new DateTime(2020, 7, 3, 10, 0, 0);
            DateTime enStart = new DateTime(2020, 7, 4, 11, 0, 0);
            int totalTime = (int)(enStart-dtStart).TotalMinutes;
            //DateTime dtStart = DateTime.Now;
            int right = -1;

	        for (int i = 0; i < 2880; i++)
		        {
			        dtStart = dtStart.AddMinutes(1);
                    TimeSpan newts = dtStart.Subtract(new DateTime(1970, 1, 1));
                    Random newRng = new Random((int)newts.TotalMinutes);
                    byte[] newKey = BitConverter.GetBytes(newRng.NextDouble());
			        cipherText = Encrypt(newKey, secretString);
                    //Console.WriteLine(dtStart);
                    //Console.WriteLine((int)newts.TotalMinutes);
                    //Console.WriteLine(cipherText);
			        if(cipherText == argsCipherText)
			            {
				            right = (int)newts.TotalMinutes;
                            return right;
			            }
            
                }
            return right;
        }
  
}
