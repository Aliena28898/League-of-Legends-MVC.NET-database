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
    }
}
