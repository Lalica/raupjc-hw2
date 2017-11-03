using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using zad2;

namespace zad3
{
    [TestClass]
    public class ToDoItemTests
    {
        [TestMethod]
        public void MarkAsCompletedTest()
        {
            //arrange
            TodoItem testMe = new TodoItem("I am not completed.");
            String expected = "I am completed now";

            //act
            if (testMe.MarkAsCompleted()) testMe.Text = expected;

            //assert
            Assert.AreEqual(expected, testMe.Text);
        }

        [TestMethod]
        public void EqualsTrueTest()
        {
            //arrange
            TodoItem sameItem = new TodoItem("I am the same.");
            TodoItem sameItem2 = sameItem;
            bool expected = true;

            //act
            bool actual = sameItem2.Equals(sameItem);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EqualsFalseIdTest()
        {
            //arrange
            TodoItem sameItem = new TodoItem("I am the same.");
            TodoItem sameItem2 = new TodoItem("I am not the same.");
            bool expected = false;

            //act
            bool actual = sameItem2.Equals(sameItem);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EqualsFalseObjectTest()
        {
            //arrange
            TodoItem sameItem = new TodoItem("I am the same.");
            int sameItem2 = 1;
            bool expected = false;

            //act
            bool actual = sameItem2.Equals(sameItem);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetHashCodeTest()
        {
            //arrange
            TodoItem myHash = new TodoItem("What is my hash?");
            int expected = myHash.Id.GetHashCode() * 397;

            //act
            int actual = myHash.GetHashCode();

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
