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
        public string IdNum { get; set; }
        public string tel { get; set; }

        public bool flag { get; set; }
        public bool upload { get; set; }
        public string animalType { get; set; }
    }
}
