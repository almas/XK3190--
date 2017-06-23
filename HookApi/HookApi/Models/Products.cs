using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace HookApi.Models
{
    //Products
    public class Products
    {

        /// <summary>
        /// productId
        /// </summary>		

        public int productId { get; set; }
        /// <summary>
        /// productName
        /// </summary>		

        public string productName { get; set; }
        /// <summary>
        /// productNo
        /// </summary>		

        public string productNo { get; set; }
        /// <summary>
        /// spec
        /// </summary>		

        public string spec { get; set; }
        /// <summary>
        /// comment
        /// </summary>		

        public string comment { get; set; }
        /// <summary>
        /// isFixedWeight
        /// </summary>		

        public bool isFixedWeight { get; set; }
        /// <summary>
        /// nominalWeight
        /// </summary>		

        public decimal nominalWeight { get; set; }
        /// <summary>
        /// ingredients
        /// </summary>		

        public string ingredients { get; set; }
        /// <summary>
        /// storageCondition
        /// </summary>		

        public string storageCondition { get; set; }
        /// <summary>
        /// expiration
        /// </summary>		

        public string expiration { get; set; }
        /// <summary>
        /// barcode
        /// </summary>		

        public string barcode { get; set; }

    }
}