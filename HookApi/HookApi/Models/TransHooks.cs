using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace HookApi.Models
{
    //TransHooks
    public class TransHooks
    {

        /// <summary>
        /// hookId
        /// </summary>		

        public string hookId { get; set; }
        /// <summary>
        /// attachTime
        /// </summary>		

        public DateTime attachTime { get; set; }
        /// <summary>
        /// oldHookId
        /// </summary>		

        public string oldHookId { get; set; }
        /// <summary>
        /// oldAttachTime
        /// </summary>		

        public DateTime oldAttachTime { get; set; }
        /// <summary>
        /// uploaded
        /// </summary>		

        public bool uploaded { get; set; }

    }
}