using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InheritanceStrategyDemoEFCore5.Models.TPTModels
{
    //[Table("TPTTeachers")]
    public class TPTTeacher : TPTUser
    {
        public string Designation { get; set; }
        public string Speciality { get; set; }
    }
}
