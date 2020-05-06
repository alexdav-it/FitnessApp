using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            string userName = Guid.NewGuid().ToString();
            //Act
            UserController controller = new UserController(userName);
            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            string userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 200;
            var gender = "man";
            var controller = new UserController(userName);
            controller.SetNewUserData(gender, birthDate, weight, height);
            var controler2 = new UserController(userName);

            Assert.AreEqual(userName, controler2.CurrentUser.Name);
            Assert.AreEqual(birthDate, controler2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controler2.CurrentUser.Weight);
            Assert.AreEqual(height, controler2.CurrentUser.Height);
            Assert.AreEqual(gender, controler2.CurrentUser.Gender.Name);
        }
    }
}