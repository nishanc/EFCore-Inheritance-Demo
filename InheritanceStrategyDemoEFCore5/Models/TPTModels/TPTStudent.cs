using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InheritanceStrategyDemoEFCore5.Models.TPTModels
{
    //[Table("TPTStudents")]
    public class TPTStudent : TPTUser
    {
        public string CGPA { get; set; }
        public string Major { get; set; }
    }
}
