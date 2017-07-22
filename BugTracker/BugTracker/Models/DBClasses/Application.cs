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

    public enum types_enum
    {
        bug,
        improvement,
        new_feature,
        task
    }

    public enum priorities_enum
    {
        blocker,
        critical,
        major,
        minor,
        trivial_cosmetic
    }

    public class Application
    {

        [Key]
        public int id_application { get; set; }
        [ForeignKey("us")]
        public string us_id { get; set; }
        public status_enum status { get; set; }
        public string caption { get; set; }
        public types_enum type { get; set; }
        public priorities_enum priority { get; set; }
        public string annotation { get; set; }
        public string picture { get; set; }


        public virtual List<Tasks> Tasks { get; set; }
        public virtual ApplicationUser us { get; set; }

    }
}