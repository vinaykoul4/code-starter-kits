﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    class PrimitiveTypeComparer : ICustomComparer
    {
        public bool compare<T>(T first, T second)
        {
            return first.Equals(second);
        }
    }
}
