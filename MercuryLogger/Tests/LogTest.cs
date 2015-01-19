using NUnit.Framework;
using System;
using System.IO; 

namespace MercuryLogger
{
	[TestFixture ()]
	public class LogTest
	{
		[Test ()]
		public void IdealEnvironment ()
		{
			for (int i = 1; i < 30; i++) {
				Log.Start (); 
				Log.info ("TAG", "message"); 
				Log.Stop (); 
				Assert.AreEqual (i, File.ReadAllLines ("log.log").Length); 
			}


		}
	}
}

