
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PMCDataModel
{
    /// <summary>
    /// Abstract class that represents collection element
    /// </summary>
    /// <typeparam name="T">element type</typeparam>
    public abstract class Collection<T> : ICollection<T> 
    {
        #region Fields

         private  List<T> _collection = new List<T>();
         private bool _isReadOnly;

        #endregion

        #region Properties
            /// <summary>
            /// Readonly propety for getting data from collection
            /// </summary>
            public List<T> CollectionList
            {
                get { return _collection; }
                protected set { _collection = value; }
            }
        #endregion

        #region Methods
            /// <summary>
            /// Index method for getting collection element via index
            /// </summary>
            /// <param name="index">element's index</param>
            /// <returns>Element of type T</returns>
            public  T this[int index]
            {
                get { return _collection[index]; }
            }

            protected virtual bool IsSupportedType()
            {
                return true;
            }

        #endregion

        #region ICollection<> implementation
            
            /// <summary>
            /// Readonly property for getting number of elements
            /// </summary>
            public int Count
            {
                get
                {
                    return _collection.Count;
                }
            }

            /// <summary>
            /// Readonly property for defining whether collectin is readonly
            /// </summary>
            public bool IsReadOnly
            {
                get
                {
                    return _isReadOnly;
                }
            }

            /// <summary>
            /// Abstract method for adding element into collection
            /// </summary>
            /// <param name="item">Item for adding</param>
            public abstract void Add(T item);
        
            /// <summary>
            /// Method for clearing collection
            /// </summary>
            public void Clear()
            {
                _collection.Clear();
            }

            /// <summary>
            /// Method for checking whether element is in collection
            /// </summary>
            /// <param name="item">Item for checking</param>
            /// <returns>True if item is in collection</returns>
            public bool Contains(T item)
            {
                return _collection.Contains<T>(item);
            }
            
            /// <summary>
            /// Method for copping collection to array
            /// </summary>
            /// <param name="array">Destination</param>
            /// <param name="arrayIndex">Starting index</param>
            public void CopyTo(T[] array, int arrayIndex)
            {
                _collection.CopyTo(array,arrayIndex);
            }

            public IEnumerator<T> GetEnumerator()
            {
                foreach(var element in _collection)
                {
                    yield return element;
                }
            }

            /// <summary>
            /// Method for removing element from collection
            /// </summary>
            /// <param name="item">Item for deliting</param>
            /// <returns>True if elemet has sucsessfully been deleted</returns>
            public bool Remove(T item)
            {
                return _collection.Remove(item);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        #endregion

    }
}
