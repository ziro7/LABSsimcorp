using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LABSsimcorp;

namespace MobileClassLibrary.UnitTests {
    [TestClass]
    public class CallListTests {

        [TestMethod]
        public void CallList_Add_AddNewCallShouldEndUpAsFirstInTheList() {

            //Arrange
            CallList myCallList = new CallList();
            Contact jacob = new Contact(1, "Jacob", 12341234, 234523456, 23452346);
            Contact anne = new Contact(1, "Anne", 23452345);
            Contact jesper = new Contact(1, "Jesper", 34563456, 34563457);
            myCallList.AddIncommingCall(new Call(jacob,12341234,DateTime.Now.Add(new TimeSpan(-3, 0, 0)), true));
            myCallList.AddIncommingCall(new Call(anne, 234523456, DateTime.Now.Add(new TimeSpan(-2, 0, 0)), true));
            myCallList.AddIncommingCall(new Call(jesper, 34563456, DateTime.Now.Add(new TimeSpan(-1, 0, 0)), true));

            //Act
            var newCall = new Call(jacob, 12341234, DateTime.Now.Add(new TimeSpan(0, 0, 0)), true);
            myCallList.AddIncommingCall(newCall);

            //Assert
            Assert.AreEqual(myCallList.incommingCallList[0], newCall);
        }

        [TestMethod]
        public void CallList_Add_AddNewCallShouldEndUpLastInTheList() {

            //Arrange
            CallList myCallList = new CallList();
            Contact jacob = new Contact(1, "Jacob", 12341234, 234523456, 23452346);
            Contact anne = new Contact(1, "Anne", 23452345);
            Contact jesper = new Contact(1, "Jesper", 34563456, 34563457);
            myCallList.AddIncommingCall(new Call(jacob, 12341234, DateTime.Now.Add(new TimeSpan(-3, 0, 0)), true));
            myCallList.AddIncommingCall(new Call(anne, 234523456, DateTime.Now.Add(new TimeSpan(-2, 0, 0)), true));
            myCallList.AddIncommingCall(new Call(jesper, 34563456, DateTime.Now.Add(new TimeSpan(-1, 0, 0)), true));

            //Act
            var newCall = new Call(jacob, 12341234, DateTime.Now.Add(new TimeSpan(-4, 0, 0)), true);
            myCallList.AddIncommingCall(newCall);

            //Assert
            Assert.AreEqual(myCallList.incommingCallList[3], newCall);
        }

        [TestMethod]
        public void CallList_Add_AddNewCallShouldEndUpAs2ndLastInTheList() {

            //Arrange
            CallList myCallList = new CallList();
            Contact jacob = new Contact(1, "Jacob", 12341234, 234523456, 23452346);
            Contact anne = new Contact(1, "Anne", 23452345);
            Contact jesper = new Contact(1, "Jesper", 34563456, 34563457);
            myCallList.AddIncommingCall(new Call(jacob, 12341234, DateTime.Now.Add(new TimeSpan(-3, 0, 0)), true));
            myCallList.AddIncommingCall(new Call(anne, 234523456, DateTime.Now.Add(new TimeSpan(-2, 0, 0)), true));
            myCallList.AddIncommingCall(new Call(jesper, 34563456, DateTime.Now.Add(new TimeSpan(-1, 0, 0)), true));

            //Act
            var newCall = new Call(jacob, 12341234, DateTime.Now.Add(new TimeSpan(-2, -1, 0)), true);
            myCallList.AddIncommingCall(newCall);

            //Assert
            Assert.AreEqual(myCallList.incommingCallList[2], newCall);
        }

        [TestMethod]
        public void CallList_Remove_RemoveOldestCallOthersShouldRemainInTheList() {

            //Arrange
            CallList myCallList = new CallList();
            Contact jacob = new Contact(1, "Jacob", 12341234, 234523456, 23452346);
            Contact anne = new Contact(1, "Anne", 23452345);
            Contact jesper = new Contact(1, "Jesper", 34563456, 34563457);
            var call1 = new Call(jacob, 12341234, DateTime.Now.Add(new TimeSpan(-3, 0, 0)), true);
            myCallList.AddIncommingCall(call1);
            var call2 = new Call(anne, 234523456, DateTime.Now.Add(new TimeSpan(-2, 0, 0)), true);
            myCallList.AddIncommingCall(call2);
            var call3 = new Call(jesper, 34563456, DateTime.Now.Add(new TimeSpan(-1, 0, 0)), true);
            myCallList.AddIncommingCall(call3);

            //Act
            myCallList.RemoveIncommingCall(call1);

            //Assert
            Assert.AreEqual(myCallList.incommingCallList[0], call3);
        }

        [TestMethod]
        public void CallList_Remove_RemoveNewestCallOthersShouldMoveUpOnTheList() {

            //Arrange
            CallList myCallList = new CallList();
            Contact jacob = new Contact(1, "Jacob", 12341234, 234523456, 23452346);
            Contact anne = new Contact(1, "Anne", 23452345);
            Contact jesper = new Contact(1, "Jesper", 34563456, 34563457);
            var call1 = new Call(jacob, 12341234, DateTime.Now.Add(new TimeSpan(-3, 0, 0)), true);
            myCallList.AddIncommingCall(call1);
            var call2 = new Call(anne, 234523456, DateTime.Now.Add(new TimeSpan(-2, 0, 0)), true);
            myCallList.AddIncommingCall(call2);
            var call3 = new Call(jesper, 34563456, DateTime.Now.Add(new TimeSpan(-1, 0, 0)), true);
            myCallList.AddIncommingCall(call3);

            //Act
            myCallList.RemoveIncommingCall(call3);

            //Assert
            Assert.AreEqual(myCallList.incommingCallList[0], call2);
        }

        [TestMethod]
        public void CallList_Remove_RemoveMiddleCallOthersShouldMoveCallAfterUpOnTheList() {

            //Arrange
            CallList myCallList = new CallList();
            Contact jacob = new Contact(1, "Jacob", 12341234, 234523456, 23452346);
            Contact anne = new Contact(1, "Anne", 23452345);
            Contact jesper = new Contact(1, "Jesper", 34563456, 34563457);
            var call1 = new Call(jacob, 12341234, DateTime.Now.Add(new TimeSpan(-3, 0, 0)), true);
            myCallList.AddIncommingCall(call1);
            var call2 = new Call(anne, 234523456, DateTime.Now.Add(new TimeSpan(-2, 0, 0)), true);
            myCallList.AddIncommingCall(call2);
            var call3 = new Call(jesper, 34563456, DateTime.Now.Add(new TimeSpan(-1, 0, 0)), true);
            myCallList.AddIncommingCall(call3);

            //Act
            myCallList.RemoveIncommingCall(call2);

            //Assert
            Assert.AreEqual(myCallList.incommingCallList[1], call1);
        }

        [TestMethod]
        public void CallList_AddOutgoingCall_AddNewCallShouldEndUpAsFirstInTheList() {

            //Arrange
            CallList myCallList = new CallList();
            Contact jacob = new Contact(1, "Jacob", 12341234, 234523456, 23452346);
            Contact anne = new Contact(1, "Anne", 23452345);
            Contact jesper = new Contact(1, "Jesper", 34563456, 34563457);
            myCallList.AddOutgoingCall(new Call(jacob, 12341234, DateTime.Now.Add(new TimeSpan(-3, 0, 0)), true));
            myCallList.AddOutgoingCall(new Call(anne, 234523456, DateTime.Now.Add(new TimeSpan(-2, 0, 0)), true));
            myCallList.AddOutgoingCall(new Call(jesper, 34563456, DateTime.Now.Add(new TimeSpan(-1, 0, 0)), true));

            //Act
            var newCall = new Call(jacob, 12341234, DateTime.Now.Add(new TimeSpan(0, 0, 0)), true);
            myCallList.AddOutgoingCall(newCall);

            //Assert
            Assert.AreEqual(myCallList.outgoingCallList[0], newCall);
        }

        [TestMethod]
        public void CallList_AddOutgoingCall_AddNewCallShouldEndUpLastInTheList() {

            //Arrange
            CallList myCallList = new CallList();
            Contact jacob = new Contact(1, "Jacob", 12341234, 234523456, 23452346);
            Contact anne = new Contact(1, "Anne", 23452345);
            Contact jesper = new Contact(1, "Jesper", 34563456, 34563457);
            myCallList.AddOutgoingCall(new Call(jacob, 12341234, DateTime.Now.Add(new TimeSpan(-3, 0, 0)), true));
            myCallList.AddOutgoingCall(new Call(anne, 234523456, DateTime.Now.Add(new TimeSpan(-2, 0, 0)), true));
            myCallList.AddOutgoingCall(new Call(jesper, 34563456, DateTime.Now.Add(new TimeSpan(-1, 0, 0)), true));

            //Act
            var newCall = new Call(jacob, 12341234, DateTime.Now.Add(new TimeSpan(-4, 0, 0)), true);
            myCallList.AddOutgoingCall(newCall);

            //Assert
            Assert.AreEqual(myCallList.outgoingCallList[3], newCall);
        }

        [TestMethod]
        public void CallList_AddOutgoingCall_AddNewCallShouldEndUpAs2ndLastInTheList() {

            //Arrange
            CallList myCallList = new CallList();
            Contact jacob = new Contact(1, "Jacob", 12341234, 234523456, 23452346);
            Contact anne = new Contact(1, "Anne", 23452345);
            Contact jesper = new Contact(1, "Jesper", 34563456, 34563457);
            myCallList.AddOutgoingCall(new Call(jacob, 12341234, DateTime.Now.Add(new TimeSpan(-3, 0, 0)), true));
            myCallList.AddOutgoingCall(new Call(anne, 234523456, DateTime.Now.Add(new TimeSpan(-2, 0, 0)), true));
            myCallList.AddOutgoingCall(new Call(jesper, 34563456, DateTime.Now.Add(new TimeSpan(-1, 0, 0)), true));

            //Act
            var newCall = new Call(jacob, 12341234, DateTime.Now.Add(new TimeSpan(-2, -1, 0)), true);
            myCallList.AddOutgoingCall(newCall);

            //Assert
            Assert.AreEqual(myCallList.outgoingCallList[2], newCall);
        }

        [TestMethod]
        public void CallList_RemoveOutgoingCall_RemoveOldestCallOthersShouldRemainInTheList() {

            //Arrange
            CallList myCallList = new CallList();
            Contact jacob = new Contact(1, "Jacob", 12341234, 234523456, 23452346);
            Contact anne = new Contact(1, "Anne", 23452345);
            Contact jesper = new Contact(1, "Jesper", 34563456, 34563457);
            var call1 = new Call(jacob, 12341234, DateTime.Now.Add(new TimeSpan(-3, 0, 0)), true);
            myCallList.AddOutgoingCall(call1);
            var call2 = new Call(anne, 234523456, DateTime.Now.Add(new TimeSpan(-2, 0, 0)), true);
            myCallList.AddOutgoingCall(call2);
            var call3 = new Call(jesper, 34563456, DateTime.Now.Add(new TimeSpan(-1, 0, 0)), true);
            myCallList.AddOutgoingCall(call3);

            //Act
            myCallList.RemoveOutgoingCall(call1);

            //Assert
            Assert.AreEqual(myCallList.outgoingCallList[0], call3);
        }

        [TestMethod]
        public void CallList_RemoveOutgoingCall_RemoveNewestCallOthersShouldMoveUpOnTheList() {

            //Arrange
            CallList myCallList = new CallList();
            Contact jacob = new Contact(1, "Jacob", 12341234, 234523456, 23452346);
            Contact anne = new Contact(1, "Anne", 23452345);
            Contact jesper = new Contact(1, "Jesper", 34563456, 34563457);
            var call1 = new Call(jacob, 12341234, DateTime.Now.Add(new TimeSpan(-3, 0, 0)), true);
            myCallList.AddOutgoingCall(call1);
            var call2 = new Call(anne, 234523456, DateTime.Now.Add(new TimeSpan(-2, 0, 0)), true);
            myCallList.AddOutgoingCall(call2);
            var call3 = new Call(jesper, 34563456, DateTime.Now.Add(new TimeSpan(-1, 0, 0)), true);
            myCallList.AddOutgoingCall(call3);

            //Act
            myCallList.RemoveOutgoingCall(call3);

            //Assert
            Assert.AreEqual(myCallList.outgoingCallList[0], call2);
        }

        [TestMethod]
        public void CallList_RemoveOutgoingCall_RemoveMiddleCallOthersShouldMoveCallAfterUpOnTheList() {

            //Arrange
            CallList myCallList = new CallList();
            Contact jacob = new Contact(1, "Jacob", 12341234, 234523456, 23452346);
            Contact anne = new Contact(1, "Anne", 23452345);
            Contact jesper = new Contact(1, "Jesper", 34563456, 34563457);
            var call1 = new Call(jacob, 12341234, DateTime.Now.Add(new TimeSpan(-3, 0, 0)), true);
            myCallList.AddOutgoingCall(call1);
            var call2 = new Call(anne, 234523456, DateTime.Now.Add(new TimeSpan(-2, 0, 0)), true);
            myCallList.AddOutgoingCall(call2);
            var call3 = new Call(jesper, 34563456, DateTime.Now.Add(new TimeSpan(-1, 0, 0)), true);
            myCallList.AddOutgoingCall(call3);

            //Act
            myCallList.RemoveOutgoingCall(call2);

            //Assert
            Assert.AreEqual(myCallList.outgoingCallList[1], call1);
        }
    }
}
