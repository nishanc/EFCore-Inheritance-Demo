using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InheritanceStrategyDemoEFCore5.Models.TPCModels
{
    public class TPCTeacher : TPCUser
    {
        public string Designation { get; set; }
        public string Speciality { get; set; }
    }
}
