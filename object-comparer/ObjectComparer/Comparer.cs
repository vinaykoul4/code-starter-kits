using System;
using System.Collections;
using System.Reflection;

namespace ObjectComparer
{
    public static class Comparer
    {
        public static bool AreSimilar<T>(T first, T second)
        {

            //Return true for both null references 
            if (first == null || second == null)
            {
                return true;
            }
            if (object.ReferenceEquals(first, second))
            {
                return true;
            }
            //Return false for different types
            if (!first.GetType().Equals(second.GetType()))
            {
                return false;
            }


            //Compare directly values for primitive and string types
            if ((first.GetType().IsPrimitive && second.GetType().IsPrimitive) || (typeof(string).Equals(first.GetType()) && typeof(string).Equals(second.GetType())))
            {
                return first.Equals(second);
            }

            //compare arrays
            if (first.GetType().IsArray && second.GetType().IsArray)
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
                    if (!AreSimilar(en.Current, secondarray.GetValue(i)))
                        return false;
                    i++;
                }
            }

            else
            {
                foreach (PropertyInfo propertyInfo in first.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
                {
                    var firstValue = propertyInfo.GetValue(first);
                    var secondValue = propertyInfo.GetValue(second);

                    //Identify the list type properties and compare elements
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
                                    var areEqual = AreSimilar(cVal, oVal);
                                    if (!areEqual) continue;

                                    result = true;
                                    break;
                                }

                            }
                            if (result == false)
                                return false;
                        }
                    }
                    else if (!AreSimilar(firstValue, secondValue))
                        return false;

                }


            }
            return true;
        }
    }
}
