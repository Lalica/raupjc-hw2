using System;

namespace zad2
{
    internal class DuplicateTodoItemException : Exception
    {
        public DuplicateTodoItemException()
        {
        }

        public DuplicateTodoItemException(string message) : base(message)
        {
        }

        public DuplicateTodoItemException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}