using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InheritanceStrategyDemoEFCore5.Models.TPCModels
{
    public class TPCStudent : TPCUser
    {
        public string CGPA { get; set; }
        public string Major { get; set; }
    }
}
