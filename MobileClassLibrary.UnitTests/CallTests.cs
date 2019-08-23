using System;
using LABSsimcorp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MobileClassLibrary.UnitTests {
    [TestClass]
    public class CallTests {

        Contact jacob = new Contact(1, "Jacob", 1234);
        Contact thomas = new Contact(2, "Thomas", 2345);

        [TestMethod]
        public void Call_Equal_DifferentTypeAreNotEqual() {

            //Arrange
            object a = new object();
            Call b = new Call(jacob, 1234, DateTime.Now);

            //Assert
            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void Call_Equal_NullTypesAreNotEqual() {
            
            //Arrange
            Call a = null;
            Call b = new Call(jacob, 1234, DateTime.Now);

            //Assert
            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void Call_Equal_DifferentContactsNotEqual() {

            //Arrange
            Call a = new Call(thomas, 1234, DateTime.Now);
            Call b = new Call(jacob, 1234, DateTime.Now);

            //Assert
            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void Call_Equal_DifferentNumbersNotEqual() {

            //Arrange
            Call a = new Call(jacob, 1234, DateTime.Now);
            Call b = new Call(jacob, 2234, DateTime.Now);

            //Assert
            Assert.AreNotEqual(a, b);

        }

        [TestMethod]
        public void Call_Equal_SameTypeSameContactSameNumberEqual() {
            
            //Arrange
            Call a = new Call(jacob, 1234, DateTime.Now);
            Call b = new Call(jacob, 1234, DateTime.Now);

            //Assert
            Assert.AreEqual(a, b);
        }

        [TestMethod]
        public void Call_Equal_OperatorEqual() {

            //Arrange
            Call a = new Call(jacob, 1234, DateTime.Now);
            Call b = new Call(jacob, 1234, DateTime.Now);

            //Assert
            Assert.IsTrue(a == b);
        }

        [TestMethod]
        public void Call_Equal_OperatorNotEqual() {

            //Arrange
            Call a = new Call(jacob, 1234, DateTime.Now);
            Call b = new Call(jacob, 1234, DateTime.Now);

            //Assert
            Assert.IsFalse(a != b);
        }

        [TestMethod]
        public void Call_Equal_OperatorGreaterThen() {

            //Arrange
            Call a = new Call(jacob, 1234, DateTime.Now);
            Call b = new Call(jacob, 1234, DateTime.Now.Add(new TimeSpan(0,1,0)));

            //Assert
            Assert.IsTrue(a > b);
        }

        [TestMethod]
        public void Call_Equal_OperatorGreaterEqualThen() {

            //Arrange
            Call a = new Call(jacob, 1234, DateTime.Now);
            Call b = new Call(jacob, 1234, DateTime.Now.Add(new TimeSpan(0, 1, 0)));

            //Assert
            Assert.IsTrue(a >= b);
        }

        [TestMethod]
        public void Call_Equal_OperatorLesserThen() {

            //Arrange
            Call a = new Call(jacob, 1234, DateTime.Now);
            Call b = new Call(jacob, 1234, DateTime.Now.Add(new TimeSpan(0, 1, 0)));

            //Assert
            Assert.IsFalse(a < b);
        }

        [TestMethod]
        public void Call_Equal_OperatorLesserEqualThen() {

            //Arrange
            Call a = new Call(jacob, 1234, DateTime.Now);
            Call b = new Call(jacob, 1234, DateTime.Now.Add(new TimeSpan(0, 1, 0)));

            //Assert
            Assert.IsFalse(a <= b);
        }
    }
}
