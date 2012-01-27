using System;
using MonoTouch.Foundation;
using NUnit.Framework;


namespace Furnishly.UnitTests
{
	[TestFixture]
	// we want the test to be availble if we use the linker
	[Preserve (AllMembers = true)]
	public class Test_Reality
	{
		[Test]
		public void ensure_universal_constant()
		{
			Assert.That(true, Is.True); 
		}
	}
}

