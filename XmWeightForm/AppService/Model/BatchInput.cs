using System;
using System.Collections.Generic;
using System.Text;

namespace AppService.Model
{
    public class BatchInput
    {
        public string batchId { get; set; }
        public int yearNum { get; set; }
        public int sort { get; set; }
        public string hostName { get; set; }
        public string PIN { get; set; }
        public string tel { get; set; }

        public bool flag { get; set; }
        public bool upload { get; set; }
        public int animalTypeId { get; set; }
        public DateTime? weighingBeginTime { get; set; }
        public DateTime? weighingFinishedTime { get; set; }
        public string animalTypeName { get; set; }
        public bool istrace { get; set; }
        public string originalPlace { get; set; }
    }
}
