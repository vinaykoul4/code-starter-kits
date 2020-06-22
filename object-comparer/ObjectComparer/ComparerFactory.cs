using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
   class ComparerFactory
    {
        
        public  ICustomComparer CompareObject(string type)
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
            }
            return customobj;
        }
}
}
