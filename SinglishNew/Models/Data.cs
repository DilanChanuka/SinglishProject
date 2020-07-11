using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SinglishNew.Models
{
    public class Data
    {
        public string SinhalaTxt
        {
            get; set;
        }
        [Required]
        public string SinglishTxt
        {
            get; set;
        } 
    }
}
