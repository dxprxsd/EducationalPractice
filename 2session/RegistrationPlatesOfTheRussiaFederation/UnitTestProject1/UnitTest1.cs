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
        public void CheckMark_InvalidCharacters_ReturnsFalse()
        {
            Assert.IsFalse(RegMarkLib.CheckMark("@123BC77"));
        }

        [TestMethod]
        public void GetNextMarkAfter_ValidNumber_ReturnsNext()
        {
            Assert.AreEqual("A124BC77", RegMarkLib.GetNextMarkAfter("A123BC77"));
        }

        [TestMethod]
        public void GetNextMarkAfter_SeriesExhausted_ReturnsMessage()
        {
            Assert.AreEqual("Series exhausted", RegMarkLib.GetNextMarkAfter("A999XX99"));
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
        public void GetCombinationsCountInRange_LargeRange_ReturnsCorrectValue()
        {
            Assert.AreEqual(900, RegMarkLib.GetCombinationsCountInRange("A100BC77", "A999BC77"));
        }

        [TestMethod]
        public void GetCombinationsCountInRange_ReversedRange_ReturnsZero()
        {
            Assert.AreEqual(0, RegMarkLib.GetCombinationsCountInRange("A110BC77", "A100BC77"));
        }

        [TestMethod]
        public void GetNextMarkAfterInRange_FullSeries_Exhausted()
        {
            Assert.AreEqual("out of stock", RegMarkLib.GetNextMarkAfterInRange("A999XX99", "A999XX99", "A999XX99"));
        }

        [TestMethod]
        public void GetNextMarkAfterInRange_MidRange_ReturnsNext()
        {
            Assert.AreEqual("A125BC77", RegMarkLib.GetNextMarkAfterInRange("A124BC77", "A120BC77", "A130BC77"));
        }

        [TestMethod]
        public void GetCombinationsCountInRange_EdgeCase_ReturnsOne()
        {
            Assert.AreEqual(1, RegMarkLib.GetCombinationsCountInRange("A999BC77", "A999BC77"));
        }

        [TestMethod]
        public void CheckMark_IInvalidCharacters_ReturnsFalse()
        {
            Assert.IsFalse(RegMarkLib.CheckMark("Z123ZZ99")); // 'Z' недопустимая буква
            Assert.IsFalse(RegMarkLib.CheckMark("A12BXY34")); // Некорректная структура
        }

        [TestMethod]
        public void GetNextMarkAfterInRange_ExceedingRange_ReturnsOutOfStock()
        {
            string result = RegMarkLib.GetNextMarkAfterInRange("A999XX77", "B000AA77", "B500AA77");
            Assert.AreEqual("out of stock", result);
        }

        [TestMethod]
        public void GetCombinationsCountInRange_ValidRange_ReturnsCorrectCount()
        {
            int count = RegMarkLib.GetCombinationsCountInRange("A123BC77", "A130BC77");
            Assert.AreEqual(8, count);
        }
    }
}
