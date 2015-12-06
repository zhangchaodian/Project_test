using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ProjectManager.DAL;
using ProjectManager.Model;

namespace ProjectManagerDALTest
{
    [TestClass]
    public class EachScheduleTest
    {
        [TestMethod]
        public void Test_GetEachSchedule()
        {
            EachScheduleDAL target = new EachScheduleDAL();
            EachSchedule actual_model = target.GetEachSchedule(1);
            string actual = actual_model.nickname;


            string expected = "张朝钿";

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Test_GetMember()
        {
            EachScheduleDAL target = new EachScheduleDAL();
            List<Member> actual_models = target.GetMember(1);
            string actual = actual_models[0].nickname;


            string expected = "待审监";

            Assert.AreEqual(expected, actual);

        }

/*        [TestMethod]
        public void Test_GetProjectTask()
        {
            EachScheduleDAL target = new EachScheduleDAL();
            List<Project_Task> actual_models = target.GetMember(1);
            string actual = actual_models[0].nickname;


            string expected = "待审监";

            Assert.AreEqual(expected, actual);


        }
 */ 
    }
}
