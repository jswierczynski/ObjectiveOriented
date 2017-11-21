using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Objective
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
		public Boolean Complete { get; set; }
    }
}
