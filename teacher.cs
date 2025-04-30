using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC9909.Models
{
    public class teacher
    {
        //proprties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int teacherId { get; set; }
        public string teacherName { get; set; }
        public string teacherNo { get; set; }

    }
}