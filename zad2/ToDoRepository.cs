using System;
using System.Collections.Generic;
using System.Linq;

namespace zad2
{
    /// <summary>
    ///     Class that encapsulates all the logic for accessing TodoTtems .
    /// </summary>
    public class TodoRepository : ITodoRepository
    {
        /// <summary>
        ///     Repository does not fetch todoItems from the actual database ,
        ///     it uses in memory storage for this excersise .
        /// </summary>
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;

        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            _inMemoryTodoDatabase = initialDbState ?? new GenericList<TodoItem>();
        }

        public TodoItem Get(Guid todoId)
        {
            var i = _inMemoryTodoDatabase.IndexOf(_inMemoryTodoDatabase.Where(s => s.Id.Equals(todoId)).ToList()
                .FirstOrDefault());
            return _inMemoryTodoDatabase.GetElement(i);
        }


        public TodoItem Add(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Contains(todoItem)) throw new DuplicateTodoItemException(" duplicate id: {id }");
            _inMemoryTodoDatabase.Add(todoItem);
            return Get(todoItem.Id);
        }
        
        public bool Remove(Guid todoId)
        {
            var toRemove = _inMemoryTodoDatabase.Where(s => s.Id.Equals(todoId)).ToList().FirstOrDefault();
            return _inMemoryTodoDatabase.Remove(toRemove);
        }

        public TodoItem Update(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Contains(todoItem))
            {
                var i = _inMemoryTodoDatabase.IndexOf(todoItem);
                _inMemoryTodoDatabase.GetElement(i).Text = todoItem.Text;
                _inMemoryTodoDatabase.GetElement(i).DateCreated = todoItem.DateCreated;
                _inMemoryTodoDatabase.GetElement(i).DateCompleted = todoItem.DateCompleted;
            }
            else
            {
                _inMemoryTodoDatabase.Add(todoItem);
            }
            return Get(todoItem.Id);
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            return Get(todoId).MarkAsCompleted();
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.ToList();
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(s => s.IsCompleted.Equals(false)).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(s => s.IsCompleted.Equals(true)).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(filterFunction).ToList();
        }
    }
}