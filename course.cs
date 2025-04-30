using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC9909.Models
{
    public class course
    {
        //proprties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int courseId { get; set; }
        public string courseName { get; set; }
        public bool isAvailable { get; set; }
    }
}