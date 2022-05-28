using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LepakRestaurant.Controller;

namespace LepakRestaurant.Tests
{
    [TestClass]
    public class loginTest
    {
        [TestMethod]
        public void TestStaffLoginFound()
        {
            string username = "owner".Trim();
            string password = "123".Trim();
            string expected = "1";
            UserController uc = new UserController();
            string msg = uc.LoginUser(username, password);

            Assert.AreEqual(expected, msg);
        }

        [TestMethod]
        public void TestStaffLoginNotFound()
        {
            string username = "owner".Trim();
            string password = "1234".Trim();
            string expected = "Incorrect user/password.";
            UserController uc = new UserController();
            string msg = uc.LoginUser(username, password);

            Assert.AreEqual(expected, msg);
        }

        [TestMethod]
        public void TestCustomerLoginNotFound()
        {
            CustomerController cc = new CustomerController();
            string phone = "98101010s";
            bool expected = false;
            bool test = cc.checkExistingCustomer(phone);

            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void TestCustomerLoginFound()
        {
            CustomerController cc = new CustomerController();
            string phone = "98101010";
            bool expected = true;
            bool test = cc.checkExistingCustomer(phone);

            Assert.AreEqual(expected, test);
        }
    }
}
