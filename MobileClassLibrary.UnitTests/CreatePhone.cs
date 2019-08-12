using System;
using LABSsimcorp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MobileClassLibrary.UnitTests {
    [TestClass]
    public class CreatePhone {
        [TestMethod]
        public void CreatePhone_Headphones_OutputValidate() {

            //arrange
            var output = new FakeOutput();
            var mobile = new MobilePhone(Model.Iphone8,output);
            
            //act
            mobile.InsertEquipmentInJackStick(new Headphones(output));
            mobile.AudioInJackStik.Play(new object());

            //assert
            string outputFromMobile = output.WriteLineText;
            Assert.AreEqual(outputFromMobile, "Plays on the " + typeof(Headphones));
        }
    }
}
