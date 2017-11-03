using System.Collections.Generic;

namespace zad2
{
    public interface IGenericList<TX> : IEnumerable<TX>

    {
        /// <summary> 
        /// Adds an item to the collection. 
        /// </summary>


        void Add(TX item);

        /// <summary> /// 
        /// Removes the first occurrence of an item from the collection.
        /// If the item was not found, method does nothing and returns false.
        /// </summary> 
        bool Remove(TX item);

        /// <summary>
        /// Removes the item at the given index in the collection. 
        /// Throws IndexOutOfRange exception if index out of range.
        /// </summary> 
        bool RemoveAt(int index);

        /// <summary>
        /// Returns the item at the given index in the collection. 
        /// hrows IndexOutOfRange exception if index out of range.
        /// </summary> 
        TX GetElement(int index);

        /// <summary> /// 
        /// Returns the index of the item in the collection.
        /// If item is not found in the collection, method returns -1.
        /// </summary> 
        int IndexOf(TX item);

        /// <summary>
        /// Readonly property. Gets the number of items contained in the collection.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Removes all items from the collection. 
        /// </summary> 
        void Clear();

        /// <summary>
        /// Determines whether the collection contains a specific value.
        /// </summary> 
        bool Contains(TX item);
    }
}