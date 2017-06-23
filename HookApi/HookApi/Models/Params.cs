using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace HookApi.Models
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

        public bool autoWeighing1 { get; set; }
        /// <summary>
        /// autoWeighing2
        /// </summary>		

        public bool autoWeighing2 { get; set; }
        /// <summary>
        /// autoWeighing3
        /// </summary>		

        public bool autoWeighing3 { get; set; }
        /// <summary>
        /// hookWeight
        /// </summary>		

        public decimal hookWeight { get; set; }
        /// <summary>
        /// meatRate
        /// </summary>		

        public decimal meatRate { get; set; }
        /// <summary>
        /// extraRate
        /// </summary>		

        public decimal extraRate { get; set; }
        /// <summary>
        /// traceURL
        /// </summary>		

        public string traceURL { get; set; }

        public string serverUrl { get; set; }

    }
}