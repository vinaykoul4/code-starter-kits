using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Collections;

namespace ObjectComparer
{
   class ComparerFactory
    {
        
        public  ICustomComparer CompareObject(object type)
        {
            ICustomComparer customobj=null;
            switch (type)
            {
                case "Primitive":
                    customobj = new PrimitiveTypeComparer();
                    break;
                case "Array":
                    customobj = new ArrayComparer();
                    break;
                case "IList":
                    customobj = new ListComparer();
                    break;
                case "Class":
                    customobj = new ReferenceTypeComparer();
                    break;
            }
            return customobj;
        }
}
}
