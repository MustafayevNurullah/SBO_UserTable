using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO_User_Table.Models
{
   public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fathername { get; set; }
        public string  Phone { get; set; }
        public string   Address { get; set; }
        public string Company { get; set; }
    }
}
