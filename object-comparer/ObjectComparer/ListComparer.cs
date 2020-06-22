using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    class ListComparer : ICustomComparer
    {
        public bool compare<T>(T firstValue, T secondValue)
        {
            dynamic cur = firstValue;
            dynamic oth = secondValue;

            //Return false on different counts or 0
            if (cur.Count == 0 || oth.Count == 0 || cur.Count != oth.Count)
            {
                return false;
            }
            if (cur != null)
            {
                var result = false;
                //Iterate one List
                foreach (object cVal in cur)
                {
                    result = false;
                    //Iterate second List
                    foreach (object oVal in oth)
                    {
                        //Recursively call the AreSimilar method
                        var areEqual = Comparer.AreSimilar(cVal, oVal);
                        if (!areEqual) continue;

                        result = true;
                        break;
                    }

                }
                if (result == false)
                    return false;
            }
            return false;
        }
    }
}
