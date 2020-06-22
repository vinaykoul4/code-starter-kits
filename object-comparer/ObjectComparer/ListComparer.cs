using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    class ListComparer : ICustomComparer
    {
        public bool compare<T>(T first, T second)
        {
            dynamic firstobj = first;
            dynamic secondobj = second;
            //Return false on different counts or 0
            if (firstobj.Count == 0 || secondobj.Count == 0 || firstobj.Count != secondobj.Count)
            {
                return false;
            }
            if (first != null)
            {
                var result = false;
                //Iterate one List
                foreach (object cVal in firstobj)
                {
                    result = false;
                    //Iterate second List
                    foreach (object oVal in secondobj)
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
            return true;
        }
    }
}
