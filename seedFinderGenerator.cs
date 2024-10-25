using System;

public class seedFinderGenerator
{
	public int seedFinder()
	{
		DateTime dtStart = new DateTime(2023, 7, 3);
		int[] minuteArray = Enumerable.Range(0, 1440).ToArray();
		string secretString = args[0];

		for (int i = 0; i<minuteArray.Length; i++)
		{
			dtStart = dtStart.AddMinutes(minuteArray[i]);
            TimeSpan ts = dt.Subtract(new DateTime(1970, 1, 1));
            Random rng = new Random((int)ts.TotalMinutes);
            byte[] key = BitConverter.GetBytes(rng.NextDouble());

			cipherText = Encrypt(key, secretString);
			if(cipherText == args[1])
			{
				return (int)dtStart;
			}
			else
			{
				return -1;
			}
        }
	}
}
