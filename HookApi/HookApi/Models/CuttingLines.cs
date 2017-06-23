using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace HookApi.Models
{
    //CuttingLines
    public class CuttingLines
    {

        /// <summary>
        /// lineId
        /// </summary>		

        public string lineId { get; set; }
        /// <summary>
        /// traceOrder
        /// </summary>		

        public int traceOrder { get; set; }
        /// <summary>
        /// lastCuttingTime
        /// </summary>		

        public DateTime lastCuttingTime { get; set; }

    }
}