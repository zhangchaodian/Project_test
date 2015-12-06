using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManager.Model;
using ProjectManager.BLL;
using System.Collections.Generic;
using ProjectManager.DAL;

namespace ProjectManagerBLLTest
{
    [TestClass]
    public class EachProjectServerTest
    {
        [TestMethod]
        public void Test_GetMember()
        {
            EachProjectServer target = new EachProjectServer();
            List<BaseModel> actual_list = target.GetMember(1);
            string actual = actual_list[0].nickname;


            string expected = "待审监";

            Assert.AreEqual(expected,actual);



        }

        [TestMethod()]
        public void Test_DALGetModel()
        {
            EachScheduleDAL target = new EachScheduleDAL();
            Member actual_member = target.GetModel(1);
            string actual = actual_member.nickname;

            Member expected = new Member();
            expected.nickname = "张朝钿";


            Assert.AreEqual(expected.nickname, actual);
        }
    }
}
