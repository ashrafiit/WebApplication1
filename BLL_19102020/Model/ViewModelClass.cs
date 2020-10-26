using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_19102020.Model
{
    public class ViewModelClass
    {
        public FaimlyDetails faimlyDetails { get; set; }
        public Location location { get; set; }
        public Restaurent restaurent { get; set; }
        public Restaurent_time restaurent_Time { get; set; }
        public IList<Location> locations { get; set; }

    }
}
 