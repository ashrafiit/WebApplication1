using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL_19102020.Model
{
    public class Restaurent_time
    {
        [Key]
        public int Time_id { get; set; }
        public string Opening_hr { get; set; }
        public string Closing_hr { get; set; }
    }
}
