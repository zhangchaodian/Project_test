using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ProjectManager.DAL;
using ProjectManager.Model;

namespace ProjectManagerDALTest
{
    [TestClass]
    public class PersonalProjectTest
    {
        [TestMethod]
        public void TestUpdateUserPwd()
        {
            PersonalProjectDAL target = new PersonalProjectDAL();
            int actual = target.UpdateUserPwd("20131003616","123456","123456");

            int expected = 1;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Testaa()
        {
            PersonalProjectDAL target = new PersonalProjectDAL();
            Comment actual_list = target.SelectProjectComment(7);
            string actual = actual_list.comment;

            string expected = "asdsa";
            Assert.AreEqual(expected, actual);
        }
    }
}
