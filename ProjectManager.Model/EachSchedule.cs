﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Model
{
    public class EachSchedule : BaseModel
    {
        public int ID { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string now_level { get; set; }
        public string target_level { get; set; }
        public string create_time { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string User_nickname { get; set; }
        public string Leader_nickname { get; set; }
        public string Leader_phone { get; set; }
        public string Leader_email { get; set; }
        public string start_y { get; set; }
        public string start_m { get; set; }
        public string start_d { get; set; }
        public string end_y { get; set; }
        public string end_m { get; set; }
        public string end_d { get; set; }
        public string state { get; set; }
    }
}
