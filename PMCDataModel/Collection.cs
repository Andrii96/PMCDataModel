using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMCDataModel
{
    //TODO: Should allow direct intuitive interaction, ElementsList has different meanings for Container, Matrix, Position
    //Should be either IList container.Matrices or container as IList<Matrix>

    /// <summary>
    /// Represents collection of elements
    /// </summary>
    /// <typeparam name="T">Collection parameters</typeparam>
    public abstract class Collection<T> :NumericType<T>, IEnumerable<T>
    {
        #region Fields

        private List<T> _elementsList;

        #endregion

        #region Constructor

        /// <summary>
        /// Empty constructor. Initializes collection.
        /// </summary>
        public Collection()
        {
            _elementsList = new List<T>();
        }

      
        #endregion

        #region Property

        //TODO: New instance per call
        /// <summary>
        /// Gets immutable collection elements
        /// </summary>
        public ReadOnlyCollection<T> ElementsList
        {
            get { return new ReadOnlyCollection<T>(_elementsList); }
        }

        /// <summary>
        /// Gets number of elements
        /// </summary>
        public int Count
        {
            get { return _elementsList.Count; }
        }

        #endregion

        #region Methods

        //TODO: Why not to accept any IEnumerable? Also, better to call in constructor directly
        /// <summary>
        /// Fills collection with list of elements
        /// </summary>
        /// <param name="list">List of elements</param>
        protected void FillCollection(List<T> list)
        {
            _elementsList = list;
        }

        /// <summary>
        /// Adds element to the collection
        /// </summary>
        /// <param name="element">Element for adding</param>
        protected void AddElement(T element)
        {
            _elementsList.Add(element);
        }

        public abstract void Add(T element);

        /// <summary>
        /// Gets element by index from collection
        /// </summary>
        /// <param name="index">Index of element</param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return _elementsList[index]; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _elementsList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

    }
}
