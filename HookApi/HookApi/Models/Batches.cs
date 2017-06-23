using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace HookApi.Models
{
    //Batches
    public class Batches
    {

        /// <summary>
        /// batchId
        /// </summary>		

        public string batchId { get; set; }
        /// <summary>
        /// animalTypeId
        /// </summary>		

        public int animalTypeId { get; set; }
        /// <summary>
        /// hostName
        /// </summary>		

        public string hostName { get; set; }
        /// <summary>
        /// PIN
        /// </summary>		

        public string PIN { get; set; }
        /// <summary>
        /// weighingBeginTime
        /// </summary>		

        public DateTime weighingBeginTime { get; set; }
        /// <summary>
        /// weighingFinishedTime
        /// </summary>		

        public DateTime weighingFinishedTime { get; set; }
        /// <summary>
        /// yearNum
        /// </summary>		

        public int yearNum { get; set; }
        /// <summary>
        /// sort
        /// </summary>		

        public int sort { get; set; }
        /// <summary>
        /// tel
        /// </summary>		

        public string tel { get; set; }
        /// <summary>
        /// animalTypeName
        /// </summary>		

        public string animalTypeName { get; set; }
        /// <summary>
        /// upload
        /// </summary>		

        public bool upload { get; set; }
        /// <summary>
        /// flag
        /// </summary>		

        public bool flag { get; set; }

        public bool istrace { get; set; }

    }
}