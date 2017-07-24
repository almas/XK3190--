using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace UploadTraceData.Models
{
    //Params
    public class Params
    {

        /// <summary>
        /// factoryId
        /// </summary>		

        public string factoryId { get; set; }
        /// <summary>
        /// factoryName
        /// </summary>		

        public string factoryName { get; set; }
        /// <summary>
        /// autoWeighing1
        /// </summary>			

        public decimal hookWeight { get; set; }
        /// <summary>
        /// meatRate
        /// </summary>		

        public decimal meatRate { get; set; }
        /// <summary>
        /// traceURL
        /// </summary>		

        public string traceURL { get; set; }

        public string serverUrl { get; set; }

        public decimal bonedRate { get; set; }
    }
}