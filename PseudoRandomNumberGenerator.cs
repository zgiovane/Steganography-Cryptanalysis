using System;

public class PseudoRandomNumberGenerator
{
	public PseudoRandomNumberGenerator()
	{
		var rand = new Random();
		rand.Next();
		System.Out.Write(rand.Next());
	}
}
