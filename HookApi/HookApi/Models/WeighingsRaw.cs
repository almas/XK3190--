using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace HookApi.Models
{
    //WeighingsRaw
    public class WeighingsRaw
    {

        /// <summary>
        /// batchId
        /// </summary>		

        public string batchId { get; set; }
        /// <summary>
        /// hookIds
        /// </summary>		

        public string hookIds { get; set; }
        /// <summary>
        /// hooksCount
        /// </summary>		

        public int hooksCount { get; set; }
        /// <summary>
        /// grossWeights
        /// </summary>		

        public decimal grossWeights { get; set; }
        /// <summary>
        /// hookWeights
        /// </summary>		

        public decimal hookWeights { get; set; }
        /// <summary>
        /// weighingTime
        /// </summary>		

        public DateTime weighingTime { get; set; }

    }
}