using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Body_Mass_Index_List_Web_API.Business
{
    
    //A Body Mass Index (BMI) Record
    public class BMIRecord
    {
        //BMI id
        public int Id { get; set; }

        //Person name
        public string Name { get; set; }

        //Person weight
        public decimal Weight { get; set; }

        //Person height
        public decimal Height { get; set; }

        //Calculated BMI

        public decimal BMI {


            get{

                return (Weight / (Height * Height));
            
            }
        
        }

    }
}
