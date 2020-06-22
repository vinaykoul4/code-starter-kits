using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    class ArrayComparer : ICustomComparer
    {
        public bool compare<T>(T first, T second)
        {
            Array firstarray = first as Array;
            Array secondarray = second as Array;

            //Return false on different lengths
            if (firstarray == null || secondarray == null || firstarray.Length != secondarray.Length)
            {
                return false;
            }

            Array.Sort(firstarray);
            Array.Sort(secondarray);

            var en = firstarray.GetEnumerator();
            int i = 0;

            //Iterate over array elements and give recursive call
            while (en.MoveNext())
            {
                if (!Comparer.AreSimilar(en.Current, secondarray.GetValue(i)))
                    return false;
                i++;
            }
            return true;
        }
    }
}
