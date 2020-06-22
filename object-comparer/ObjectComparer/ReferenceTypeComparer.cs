using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    class ReferenceTypeComparer : ICustomComparer
    {
        public bool compare<T>(T first, T second)
        {
            foreach (PropertyInfo propertyInfo in first.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
            {
                var firstValue = propertyInfo.GetValue(first);
                var secondValue = propertyInfo.GetValue(second);
                
                if ((firstValue is IList && propertyInfo.PropertyType.IsGenericType) ||
                    (secondValue is IList && propertyInfo.PropertyType.IsGenericType))
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
                }
                else if (!Comparer.AreSimilar(firstValue, secondValue))
                    return false;

            }
            return true;

        }
    }
}
