using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
   public class StudentModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int[] Marks { get; set; }
        public List<int> TagId { get; set; }
    }
}
