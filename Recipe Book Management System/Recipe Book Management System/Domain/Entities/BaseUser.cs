using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Book_Management_System.Domain.Entities
{
    abstract class BaseUser
    {
        public int UserID { get; set; }
        public string Name { get; set; }
    }
}
