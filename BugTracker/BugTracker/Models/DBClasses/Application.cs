using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models.DBClasses
{
    public enum status_enum
    {
        initial,
        completed,
        verified
    }

    public class Application
    {

        [Key]
        public int id_application { get; set; }
        public status_enum status { get; set; }
        public string caption { get; set; }
        public string type { get; set; }
        public string priority { get; set; }
        public string annotation { get; set; }
        public string picture { get; set; }


        public virtual List<Tasks> Tasks { get; set; }

    }
}