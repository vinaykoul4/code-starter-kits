using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    interface ICustomComparer
    {
        bool compare<T>(T first,T second);
    }
}
