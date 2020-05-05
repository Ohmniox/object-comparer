using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void Same_string_are_similar_test()
        {
            string first = "Test", second = "Test";
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void Different_string_are_not_similar_test()
        {
            string first = "Test", second = "Code";
            Assert.IsFalse(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void Same_objects_are_similar_test()
        {
            Student student1 = new Student() { Name = "Test", Id = 101, Marks = new List<int> { 1, 2 } };
            Student student2 = new Student() { Name = "Test", Id = 101, Marks = new List<int> { 1, 2 } };
            Assert.IsTrue(Comparer.AreSimilar(student1, student2));
        }

        [TestMethod]
        public void Different_objects_are_not_similar_test()
        {
            Student student1 = new Student() { Name = "Test", Id = 101, Marks = new List<int> { 1, 2 } };
            Student student2 = new Student() { Name = "Test", Id = 102, Marks = new List<int> { 1, 2 } };
            Assert.IsFalse(Comparer.AreSimilar(student1, student2));
        }

        [TestMethod]
        public void Same_objects_with_different_array_item_order_are_similar_test()
        {
            Student student1 = new Student() { Name = "Test", Id = 101, Marks = new List<int> { 1, 2 } };
            Student student2 = new Student() { Name = "Test", Id = 101, Marks = new List<int> { 2, 1 } };
            Assert.IsTrue(Comparer.AreSimilar(student1, student2));
        }

        [TestMethod]
        public void Empty_objects_are_similar_test()
        {
            Student student1 = new Student();
            Student student2 = new Student();
            Assert.IsTrue(Comparer.AreSimilar(student1, student2));
        }
    }
    public class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<int> Marks { get; set; }
    }
}
