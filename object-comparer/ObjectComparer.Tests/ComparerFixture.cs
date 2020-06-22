using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectComparer;

namespace ObjectComparer.Tests
{
    [TestClass]
    public class ComparerFixture
    {
        [TestMethod]
        public void Null_values_are_similar_test()
        {
            string first = null, second = null;
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void string_with_different_values_are_not_similar_test()
        {
            string first = "test1";
            string second = "test2";
            Assert.IsFalse(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void int_with_different_values_are_not_similar_test()
        {
            int first = 1;
            int second = 2;
            Assert.IsFalse(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void Array_with_same_elements_are_similar_test()
        {
            int[] first = new int[] { 10, 20, 30 };
            int[] second = new int[] { 10, 20, 30 };
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void Array_with_different_elements_are_not_similar_test()
        {
            int[] first = new int[] { 10, 20, 50 };
            int[] second = new int[] { 10, 20, 30 };
            Assert.IsFalse(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void Array_with_elements_at_different_order_are_similar_test()
        {
            int[] first = new int[] { 10, 50, 30 };
            int[] second = new int[] { 10, 30, 50 };
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void List_with_different_elements_are_not_similar_test()
        {
            List<int> first = new List<int>() { 1, 2, 3, 4 };
            List<int> second = new List<int>() { 1, 2, 3, 4, 5 };
            Assert.IsFalse(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void Blank_Objects_are_similar_test()
        {
            StudentModel FirstStudent = new StudentModel();

            StudentModel SecondStudent = new StudentModel() { };
            Assert.IsTrue(Comparer.AreSimilar(FirstStudent, SecondStudent));
        }
        [TestMethod]
        public void Complexobject_same_reference_values_are_similar_test()
        {
            StudentModel FirstStudent = new StudentModel() { Name = "John", Id = 100, Marks = new int[] { 10, 20, 30 }, TagId = new List<int>() { 1, 2, 6, 5, 6 } };

            StudentModel SecondStudent = FirstStudent;
            Assert.IsTrue(Comparer.AreSimilar(FirstStudent, SecondStudent));
        }
        
        [TestMethod]
        public void complexobject_string_property_with_different_values_are_not_similar_test()
        {
            StudentModel FirstStudent = new StudentModel() { Name = "John", Id = 100, Marks = new int[] { 10, 20, 30 }, TagId = new List<int>() { 1, 2, 6, 5, 6 } };

            StudentModel SecondStudent = new StudentModel() { Name = "Jo", Id = 100, Marks = new int[] { 10, 30, 20 }, TagId = new List<int>() { 1, 2, 3, 5, 6 } };
            Assert.IsFalse(Comparer.AreSimilar(FirstStudent, SecondStudent));
        }
        [TestMethod]
        public void complexobject_int_property__with_different_values_are_not_similartest()
        {
            StudentModel FirstStudent = new StudentModel() { Name = "John", Id = 100, Marks = new int[] { 10, 20, 30 }, TagId = new List<int>() { 1, 2, 6, 5, 6 } };

            StudentModel SecondStudent = new StudentModel() { Name = "John", Id = 101, Marks = new int[] { 10, 30, 20 }, TagId = new List<int>() { 1, 2, 6, 5, 6 } };
            Assert.IsFalse(Comparer.AreSimilar(FirstStudent, SecondStudent));
        }
        [TestMethod]
        public void complexobject_array_property__with_different_elements_are_not_similar_test()
        {
            StudentModel FirstStudent = new StudentModel() { Name = "John", Id = 100, Marks = new int[] { 10, 20, 30 }, TagId = new List<int>() { 1, 2, 6, 5, 6 } };

            StudentModel SecondStudent = new StudentModel() { Name = "John", Id = 100, Marks = new int[] { 10, 30, 50 }, TagId = new List<int>() { 1, 2, 6, 5, 6 } };
            Assert.IsFalse(Comparer.AreSimilar(FirstStudent, SecondStudent));
        }
        [TestMethod]
        public void complexobject_array_property__with_same_values_different_order_are_similar_test()
        {
            StudentModel FirstStudent = new StudentModel() { Name = "John", Id = 100, Marks = new int[] { 10, 20, 30 }, TagId = new List<int>() { 1, 2, 6, 5, 6 } };

            StudentModel SecondStudent = new StudentModel() { Name = "John", Id = 100, Marks = new int[] { 10, 30, 20 }, TagId = new List<int>() { 1, 2, 6, 5, 6 } };
            Assert.IsTrue(Comparer.AreSimilar(FirstStudent, SecondStudent));
        }
        [TestMethod]
        public void array_length_different_are_not_similar_test()
        {
            StudentModel FirstStudent = new StudentModel() { Name = "John", Id = 100, Marks = new int[] { 10, 20, 30 }, TagId = new List<int>() { 1, 2, 6, 5, 6 } };

            StudentModel SecondStudent = new StudentModel() { Name = "John", Id = 101, Marks = new int[] { 10, 30, 20, 40 }, TagId = new List<int>() { 1, 2, 6, 5, 6 } };
            Assert.IsFalse(Comparer.AreSimilar(FirstStudent, SecondStudent));
        }
        [TestMethod]
        public void list_length_different_are_not_similar_test()
        {
            StudentModel FirstStudent = new StudentModel() { Name = "John", Id = 100, Marks = new int[] { 10, 20, 30 }, TagId = new List<int>() { 1, 2, 6, 5, 6 } };

            StudentModel SecondStudent = new StudentModel() { Name = "John", Id = 101, Marks = new int[] { 10, 20, 30 }, TagId = new List<int>() { 1, 2, 6, 5, 6, 7 } };
            Assert.IsFalse(Comparer.AreSimilar(FirstStudent, SecondStudent));
        }
        [TestMethod]
        public void list_elements_with_different_order_not_similar_test()
        {
            StudentModel FirstStudent = new StudentModel() { Name = "John", Id = 100, Marks = new int[] { 10, 20, 30 }, TagId = new List<int>() { 1, 2, 6, 5, 7, 6 } };

            StudentModel SecondStudent = new StudentModel() { Name = "John", Id = 101, Marks = new int[] { 10, 20, 30 }, TagId = new List<int>() { 1, 2, 6, 5, 6, 7 } };
            Assert.IsFalse(Comparer.AreSimilar(FirstStudent, SecondStudent));
        }
        [TestMethod]
        public void different_types_are_not_similar_test()
        {
            StudentModel FirstStudent = new StudentModel() { Name = "John", Id = 100, Marks = new int[] { 10, 20, 30 } };
            object test = "test";
            Assert.IsFalse(Comparer.AreSimilar(FirstStudent, test));
        }
        [TestMethod]
        public void different_objects_are_not_similar_test()
        {
            object test1 = 1;
            object test2 = "test";
            Assert.IsFalse(Comparer.AreSimilar(test1, test2));
        }

    }

}
