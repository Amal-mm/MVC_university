using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC9909.Models
{
    public class student
    {
        //proprties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int studentId { get; set; }
        public string studentName { get; set; }
        public string studentNo { get; set; }
       
    }
}