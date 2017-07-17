using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models.DBClasses
{
    public class Tasks
    {
        [Key]
        public int id_task { get; set; }
        public string task_name { get; set; }
        public bool chek_list { get; set; }

        public virtual Application Application { get; set; }
    }
}