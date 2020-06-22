using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    class ReferenceTypeComparer : ICustomComparer
    {
        public bool compare<T>(T first, T second)
        {
            throw new NotImplementedException();
        }
    }
}
