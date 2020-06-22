using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    class CompareHandler
    {
        ICustomComparer custcomparer;
        public CompareHandler(ICustomComparer comparer)
        {
            custcomparer = comparer;
        }
        public void CompareObjects<T>(T first,T second)
        {
            

           
        }

    }
}
