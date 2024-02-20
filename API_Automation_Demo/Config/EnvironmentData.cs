using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Automation_Demo.Config
{
    public class EnvironmentData
    {
        public string name { get; set; }
        public string baseUrl { get; set; }
        public string createUserEndpoint { get; set; }
        public string getUserDetails { get; set; }
    }

    public class Root
    {
        public List<EnvironmentData> environments { get; set; }
    }


}
