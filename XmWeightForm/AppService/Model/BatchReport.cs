using System;
using System.Collections.Generic;
using System.Text;

namespace AppService.Model
{
    public class BatchReport
    {
        public string batchId { get; set; }

        public string hostName { get; set; }
        public string PIN { get; set; }
        public int Count { get; set; }
        public DateTime? weighingBeginTime { get; set; }
       
    }
}
