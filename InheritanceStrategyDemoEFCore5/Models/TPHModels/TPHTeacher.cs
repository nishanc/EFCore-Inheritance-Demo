using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InheritanceStrategyDemoEFCore5.Models.TPHModels
{
    public class TPHTeacher : TPHUser
    {
        public string Designation { get; set; }
        public string Speciality { get; set; }
    }
}
