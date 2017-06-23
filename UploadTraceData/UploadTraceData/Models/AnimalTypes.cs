using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace UploadTraceData.Models
{
    //AnimalTypes
    public class AnimalTypes
    {

        /// <summary>
        /// animalTypeId
        /// </summary>		

        public int animalTypeId { get; set; }
        /// <summary>
        /// animalTypeName
        /// </summary>		

        public string animalTypeName { get; set; }
        /// <summary>
        /// price
        /// </summary>		

        public decimal price { get; set; }

    }
}