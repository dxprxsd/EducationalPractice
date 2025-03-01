using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RegistrationPlatesOfTheRussiaFederation;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckMark_ValidNumber_ReturnsTrue()
        {
            Assert.IsTrue(RegMarkLib.CheckMark("A123BC77"));
        }

        [TestMethod]
        public void CheckMark_InvalidNumber_ReturnsFalse()
        {
            Assert.IsFalse(RegMarkLib.CheckMark("Z999ZZ999"));
        }

        [TestMethod]
        public void CheckMark_EmptyString_ReturnsFalse()
        {
            Assert.IsFalse(RegMarkLib.CheckMark(""));
        }

        [TestMethod]
        public void CheckMark_Null_ReturnsFalse()
        {
            Assert.IsFalse(RegMarkLib.CheckMark(null));
        }

        [TestMethod]
        public void GetNextMarkAfter_ValidNumber_ReturnsNext()
        {
            Assert.AreEqual("A124BC77", RegMarkLib.GetNextMarkAfter("A123BC77"));
        }

        [TestMethod]
        public void GetNextMarkAfter_InvalidNumber_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() => RegMarkLib.GetNextMarkAfter("Z999ZZ999"));
        }

        [TestMethod]
        public void GetNextMarkAfterInRange_Valid_ReturnsNext()
        {
            Assert.AreEqual("A124BC77", RegMarkLib.GetNextMarkAfterInRange("A123BC77", "A100BC77", "A130BC77"));
        }

        [TestMethod]
        public void GetNextMarkAfterInRange_OutOfStock_ReturnsMessage()
        {
            Assert.AreEqual("out of stock", RegMarkLib.GetNextMarkAfterInRange("A130BC77", "A100BC77", "A130BC77"));
        }

        [TestMethod]
        public void GetCombinationsCountInRange_ValidRange_ReturnsCount()
        {
            Assert.AreEqual(10, RegMarkLib.GetCombinationsCountInRange("A100BC77", "A109BC77"));
        }

        [TestMethod]
        public void GetCombinationsCountInRange_SameNumbers_ReturnsOne()
        {
            Assert.AreEqual(1, RegMarkLib.GetCombinationsCountInRange("A100BC77", "A100BC77"));
        }

        [TestMethod]
        public void GetCombinationsCountInRange_InvalidNumbers_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() => RegMarkLib.GetCombinationsCountInRange("A100BC77", "Z999ZZ999"));
        }

        [TestMethod]
        public void GetCombinationsCountInRange_ReversedRange_ReturnsZero()
        {
            Assert.AreEqual(0, RegMarkLib.GetCombinationsCountInRange("A110BC77", "A100BC77"));
        }

        [TestMethod]
        public void CheckMark_InvalidRegion_ReturnsFalse()
        {
            Assert.IsFalse(RegMarkLib.CheckMark("A123BC9999"));
        }

        [TestMethod]
        public void GetNextMarkAfter_SeriesExhausted_ReturnsMessage()
        {
            Assert.AreEqual("Series exhausted", RegMarkLib.GetNextMarkAfter("A999XX99"));
        }

        [TestMethod]
        public void GetNextMarkAfterInRange_ValidMidRange_ReturnsNext()
        {
            Assert.AreEqual("A125BC77", RegMarkLib.GetNextMarkAfterInRange("A124BC77", "A120BC77", "A130BC77"));
        }
    }
}
