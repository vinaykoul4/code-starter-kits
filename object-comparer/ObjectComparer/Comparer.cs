using System;
using System.Collections;
using System.Reflection;

namespace ObjectComparer
{
    public static class Comparer
    {
        static ICustomComparer Compare;
        static ComparerFactory compfactory;

        static Comparer()
        {
            compfactory = new ComparerFactory();

        }

        public static bool AreSimilar<T>(T first, T second)
        {

            //Return true for both references null or same
            if (first == null || second == null || object.ReferenceEquals(first, second))
            {
                return true;
            }

            //Return false for different types
            if (!first.GetType().Equals(second.GetType()))
            {
                return false;
            }

            //Compare directly values for primitive and string types
            if ((first.GetType().IsPrimitive || (typeof(string).Equals(second.GetType()))))
            {
                Compare = compfactory.CompareObject("Primitive");
                return Compare.compare<T>(first, second);
            }

            //compare arrays
            if (first.GetType().IsArray && second.GetType().IsArray)
            {
                Compare = compfactory.CompareObject("Array");
                return Compare.compare<T>(first, second);

            }

            else
            {
                if (first.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).Length > 0)
                {
                    Compare = compfactory.CompareObject("Class");
                    return Compare.compare<T>(first, second);
                }
                                
            }
            return true;
        }
    }
    
}
