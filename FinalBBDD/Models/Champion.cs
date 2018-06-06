using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FinalBBDD.Models
{
    public class Champion : DbContext
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Lore { get; set; }
        public String Title { get; set; }
        public List<String> Tags { get; set; }
    }
}
