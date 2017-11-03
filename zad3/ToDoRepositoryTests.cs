using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using zad2;

namespace zad3
{
    [TestClass]
    public class ToDoRepositoryTests
    {

        [TestMethod]
        public void GetTest()
        {
            // arrange 
            IGenericList<TodoItem> somelist = MakeIt();
            Guid id = somelist.GetElement(2).Id;
            String expected = "kupi";

            ITodoRepository something = new TodoRepository(somelist);

            // act  
            TodoItem tryItem = something.Get(id);

            // assert  
            Assert.AreEqual(expected, tryItem.Text);
        }

        [TestMethod]
        public void AddWrongTest()
        {
            // arrange 
            IGenericList<TodoItem> somelist = MakeIt();
            TodoItem same= new TodoItem("isti");
            somelist.Add(same);
            ITodoRepository something = new TodoRepository(somelist);
            TodoItem trItem;

            // act 
            try
            {
                trItem = something.Add(same);
            }
            catch (Exception ex)
            {
                trItem = null;
            }

            //assert
            Assert.AreEqual(null, trItem);
        }


        [TestMethod]
        public void AddRightTest()
        {
            // arrange 
            IGenericList<TodoItem> somelist = MakeIt();
            ITodoRepository something = new TodoRepository(somelist);
            TodoItem shouldpass;

            // act 
            try
            {
                shouldpass = something.Add(new TodoItem("dfsf"));
            }
            catch (Exception ex)
            {
                shouldpass = null;
            }

            //assert
            Assert.AreEqual("dfsf", shouldpass.Text);
        }

        [TestMethod]
        public void RemoveTest()
        {
            //arrange
            IGenericList<TodoItem> somelist = MakeIt();
            TodoItem toRemove = new TodoItem("removeMe");
            somelist.Add(toRemove);
            TodoItem notToRemove = new TodoItem("dontRemoveMePls");

            ITodoRepository testRepository = new TodoRepository(somelist);

            //act and assert
            if(!testRepository.Remove(toRemove.Id)) Assert.Fail();
            try
            {
                if (testRepository.Remove(notToRemove.Id)) Assert.Fail();
            }
            catch (Exception e)
            {
            }
        }

        [TestMethod]
        public void UpdateTest()
        {
            //arrange
            IGenericList<TodoItem> someList = MakeIt();
            TodoItem item = new TodoItem("zamijeni");
            someList.Add(item);

            ITodoRepository testRepository = new TodoRepository(someList);
            item.Text = "zamjenjen";

            //act
            TodoItem tryItem = testRepository.Update(item);

            //assert
            Assert.AreEqual(item.Text, tryItem.Text);
        }

        [TestMethod]
        public void MarkAsCompletedTest()
        {
            //arrange
            IGenericList<TodoItem> someList = MakeIt();
            TodoItem item = new TodoItem("complete");
            someList.Add(item);
            ITodoRepository testRepository = new TodoRepository(someList);

            //act
            testRepository.MarkAsCompleted(item.Id);

            //assert
            Assert.AreEqual(true, testRepository.Get(item.Id).IsCompleted);
        }

        [TestMethod]
        public void GetAllTest()
        {
            //arrange
            IGenericList<TodoItem> someList = MakeIt();
            ITodoRepository testRepository = new TodoRepository(someList);

            //act
            List<TodoItem> newList = testRepository.GetAll();

            //assert
            if (newList == null) Assert.Fail();
        }

        [TestMethod]
        public void GetActiveTest()
        {
            //arrange
            IGenericList<TodoItem> someList = MakeIt();
            ITodoRepository testRepository = new TodoRepository(someList);

            //act
            List<TodoItem> newList = testRepository.GetActive();

            //assert
            foreach (TodoItem i in newList)
            {
                if(i.IsCompleted) Assert.Fail();
            }
        }

        [TestMethod]
        public void GetCompletedTest()
        {
            //arrange
            IGenericList<TodoItem> someList = MakeIt();
            ITodoRepository testRepository = new TodoRepository(someList);

            //act
            List<TodoItem> newList = testRepository.GetCompleted();

            //assert
            foreach (TodoItem i in newList)
            {
                if (!i.IsCompleted) Assert.Fail();
            }
        }

        [TestMethod]
        public void GetFilteredTest()
        {
            //arrange
            IGenericList<TodoItem> someList = MakeIt();
            ITodoRepository testRepository = new TodoRepository(someList);

            //act
            List<TodoItem> newList = testRepository.GetFiltered(x => x.Text.Equals("ana"));

            //assert
            foreach (TodoItem i in newList)
            {
                if (!i.Text.Equals("ana")) Assert.Fail();
            }
        }

        public IGenericList<TodoItem> MakeIt()
        {
            IGenericList<TodoItem> example = new GenericList<TodoItem>(10);
            example.Add(new TodoItem("ana"));
            example.Add(new TodoItem("boyena"));
            example.Add(new TodoItem("kupi"));
            example.Add(new TodoItem("acdaaa"));
            example.Add(new TodoItem("asdadsada"));

            return example;
        }
    }
}
