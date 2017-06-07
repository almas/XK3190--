using System;
using System.Collections.Generic;
using System.Text;

namespace AppService.Model
{
   public class ParamsModel
    {
       public string factoryId { get; set; }
       public string factoryName { get; set; }
       public string hookWeight { get; set; }
       public string meatRate { get; set; }
       public string extraRate { get; set; }
       public bool autoWeighing1 { get; set; }
       public bool autoWeighing2 { get; set; }
       public bool autoWeighing3 { get; set; }

       public string traceURL { get; set; }
       public string serverUrl { get; set; }
    }
}
