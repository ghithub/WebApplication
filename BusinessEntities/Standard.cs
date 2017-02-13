using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Standard
    {
        public Standard() { }
        public int StandardID { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }        
    }
}
