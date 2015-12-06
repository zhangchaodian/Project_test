using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManager.Model;
using System.Web.Services;
using ProjectManager.BLL;


namespace ProjectManager.Controllers.User
{
    [Authorize]
    public class UserManagerController : Controller
    {
        //
        // GET: /UserManager/
   
    
    

#region 登录后进入的首个页面
[Authorize]
public ActionResult index()
    {
        Model.User userInfo = (Model.User)Session["userinfo"];
        ViewBag.UserInfo = userInfo;
       // ViewBag.user = User.Identity.Name; 
       // projectInfo = DAL.ProjectInfoDAL.getProject_pass_Info();
        //projectInfo = (from rerult in projectInfo where (rerult.remark.Equals("审核一") && rerult.p_rank.Equals("国家级")) select rerult).ToList();
       // ViewBag.ProjectInfo = projectInfo;
        return View();
    }
    #endregion

        /*
    public ActionResult index()
    {
        string str1 = Request.Form["updownorder1"];
        string str2 = "国家级";
        string str3 = Request.Form["updownorder3"];
        string str4 = "p_id";
        string str5 = "asc";
        projectInfo = DAL.ProjectInfoDAL.getProject_pass_Info();
        projectInfo = BLL.ProjectServer.getSearchResult(projectInfo, str2, str4, str5);
        string htmlstr = BLL.ProjectServer.getJsonHtml(projectInfo);
        // string tbody = "<tr><td>1</td><td>思科</td><td>IT</td><td>某某某项目</td><td>张朝钿</td><td>审核一</td><td>国家级</td><td>2015-10-29</td></tr>".ToString();
        return Content(htmlstr);
    }
         * */
       /* #region  搜索处理1，返回json数据
        
        public JsonResult GetSearch()
        {
            string str1 = Request.Form["updownorder1"];
            string str2 = Request.Form["updownorder2"];//项目级别
            string str3 = Request.Form["updownorder3"];
            string str4 = Request.Form["updownorder4"];
            string str5 = Request.Form["updownorder5"];
            projectInfo = DAL.ProjectInfoDAL.getProject_pass_Info();
            projectInfo=BLL.ProjectServer.getSearchResult(projectInfo,str2,str4,str5);
            string htmlstr = BLL.ProjectServer.getJsonHtml(projectInfo);
           // string tbody = "<tr><td>1</td><td>思科</td><td>IT</td><td>某某某项目</td><td>张朝钿</td><td>审核一</td><td>国家级</td><td>2015-10-29</td></tr>".ToString();
            return Json(htmlstr, JsonRequestBehavior.AllowGet);

            


        }
        #endregion

        #region 搜索处理2，返回json数据
        public JsonResult GetSearch2()
        {
            string keyword_type = Request.Form["updownorder1"];
            string keyword = Request.Form["updownorder2"];//项目级别
           // string tbody = "<tr><td>1</td><td>思科</td><td>IT</td><td>某某某项目</td><td>张朝钿</td><td>审核一</td><td>国家级</td><td>2015-10-29</td></tr>".ToString();
            projectInfo = DAL.ProjectInfoDAL.getProject_pass_Info();
            projectInfo=BLL.ProjectServer.getSearchResult2(projectInfo,keyword_type,keyword);
            string htmlstr = BLL.ProjectServer.getJsonHtml(projectInfo);
            return Json(htmlstr, JsonRequestBehavior.AllowGet);
        }
        #endregion
        */
        #region 详情index页面返回json数据
        [WebMethod]
        public  JsonResult GetDetail()
        {
            string str = "{ \"p_name\": \"挑战杯\", \"type\": \"竞赛\", \"st_name\": \"张朝钿\", \"st_detail\": \"姓名:张朝钿, 行政职务:教务主任, 手机号码:159842536, 邮箱:89756458@qq.com\", \"gtoup\": \"zx chaodian\", \"rank\": \"国家级\", \"s_time\": \"2015-1-1\", \"f_time\": \"2015-12-1\"}";
            return Json(str, JsonRequestBehavior.AllowGet);
        }
        #endregion

        [Authorize]
        public ActionResult Project_Schedule_Each(int ID)
        {
            ViewBag.user = User.Identity.Name;

            EachProjectServer server = new EachProjectServer();
            ViewBag.eachschedule = server.GetEachSchedule(ID);
            ViewBag.members = server.GetMember(ID);
            ViewBag.tasks = server.GetProject_task(ID);
            ViewBag.per = server.Get_Schedule_Per(ID);
          
            return View("Project_Schedule_Each");
        }
        [Authorize]
        public ActionResult Project_Schedule()
        {
            ViewBag.user = User.Identity.Name;
            //List<Model.Project_Schedule_Model> s_model = new List<Project_Schedule_Model>();
           // s_model = BLL.ProjectServer.getScheduleModel();
            //ViewBag.s_model = s_model;
            return View("Project_Schedule");
        }
        [Authorize]
        public ActionResult Personal_Project(string keyword = "")
        {
            ViewBag.user = User.Identity.Name;
            Model.User userInfo = (Model.User)Session["userinfo"];
            ViewBag.userinfo = userInfo;
            PersonalProjectServer server = new PersonalProjectServer();
            ViewBag.user = server.GetUserInfo(userInfo.ID);
            ViewBag.projects = server.GetUserProject(userInfo.ID,keyword);
            return View("Personal_Project");
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UpdateUserPwd(FormCollection formvalues)
        {
            Model.User userInfo = (Model.User)Session["userinfo"];
            string ID = userInfo.ID;
            string old_pwd = formvalues["OldPwd"];
            string new_pwd = formvalues["NewPwd"];
            PersonalProjectServer server = new PersonalProjectServer();
            char result = server.UpdateUserPwd(ID,old_pwd,new_pwd);
            return Json(result);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UpdateUserInfo(FormCollection formvalues)
        {
            Model.User userInfo = (Model.User)Session["userinfo"];
            string ID = userInfo.ID;
            string nickname = formvalues["nickname"];
            char sex = Convert.ToChar(formvalues["sex"]);
            string position = formvalues["position"];
            string phone = formvalues["phone"];
            string email = formvalues["email"];
            PersonalProjectServer server = new PersonalProjectServer();
            Boolean result = server.UpdateUseInfo(nickname,sex,position,phone,email, ID);
            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ReturnProjectComment()
        {
            int project_id = Convert.ToInt32(Request.Params["project_id"]);
            PersonalProjectServer server = new PersonalProjectServer();
            Comment comm = server.SelectProjectComment(project_id);
            return Json(comm.comment);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult ReturnTasksState(int ID)
        {
            //int newID = Convert.ToInt32(ID);
            PersonalProjectServer server = new PersonalProjectServer();
            List<Project_Task> tasks = server.SelecTasksState(ID);
            //List<Project_Task> taskss = new List<Project_Task>();
            //Project_Task task1 = new Project_Task();
            //task1.ID = 1;
            //task1.leader = "aaa";
            //Project_Task task2 = new Project_Task();
            //task2.ID = 2;
            //task2.leader = "bbb";
            //taskss.Add(task1);
            //taskss.Add(task2);
            return Json(tasks);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UpdataTaskState(FormCollection formvalues)
        {
            PersonalProjectServer server = new PersonalProjectServer();
            int sum = 0;
            int project_id = Convert.ToInt32(formvalues["Task_project_id"]);
            foreach (var key in formvalues.Keys)
            {
                string str_key = key.ToString();
                if (str_key != "Task_project_id")
                {
                    int ID = Convert.ToInt32(str_key);
                    char state = Convert.ToChar(formvalues[str_key]);
                    Boolean result = server.UpdateTaskState(ID, project_id, state);
                    if (result) sum++;
                }
            }
            return Json(sum);
        }
        
        [Authorize]
        public ActionResult Project_Declare()
        {
            ViewBag.user = User.Identity.Name;
            return View("Project_Declare");
        }
        [Authorize]
        public ActionResult Personal_Project_Abled()
        {
            ViewBag.user = User.Identity.Name; 
            return View("Personal_Project_Abled");
        }
        [Authorize]
        public ActionResult Personal_Project_Disabled()
        {
            ViewBag.user = User.Identity.Name; 
            return View("Personal_Project_Disabled");
        }
}
}

