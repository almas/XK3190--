using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace UploadTraceData.Models
{
    //CuttingsPending
    public class CuttingsPending
    {

        /// <summary>
        /// batchId
        /// </summary>		

        public string batchId { get; set; }
        /// <summary>
        /// queueTime
        /// </summary>		

        public DateTime queueTime { get; set; }
        /// <summary>
        /// assumedMeatWeights
        /// </summary>		

        public decimal assumedMeatWeights { get; set; }
        /// <summary>
        /// cuttedMeatWeights
        /// </summary>		

        public decimal cuttedMeatWeights { get; set; }
        /// <summary>
        /// cuttingFinishedTime
        /// </summary>		

        public DateTime cuttingFinishedTime { get; set; }

    }
}