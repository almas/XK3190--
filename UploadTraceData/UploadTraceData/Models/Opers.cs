using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace UploadTraceData.Models
{
    //Opers
    public class Opers
    {

        /// <summary>
        /// Id
        /// </summary>		

        public int Id { get; set; }
        /// <summary>
        /// userName
        /// </summary>		

        public string userName { get; set; }
        /// <summary>
        /// operName
        /// </summary>		

        public string operName { get; set; }
        /// <summary>
        /// password
        /// </summary>		

        public byte[] password { get; set; }
        /// <summary>
        /// isAdmin
        /// </summary>		

        public bool isAdmin { get; set; }
        /// <summary>
        /// isRepoter
        /// </summary>		

        public bool isRepoter { get; set; }
        /// <summary>
        /// stopped
        /// </summary>		

        public bool stopped { get; set; }
        /// <summary>
        /// JobNumber
        /// </summary>		

        public string JobNumber { get; set; }

    }
}