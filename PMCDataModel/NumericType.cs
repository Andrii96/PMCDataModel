using System;

namespace PMCDataModel
{
    /// <summary>
    /// Represents abstract numeric class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class NumericType<T>
    {
        protected NumericType()
        {
            if (!CheckType())
            {
                throw new ArgumentException("Wrong generic type.");
            }
        }

        #region Helpers

        private bool IsNumericType(Type type)
        {
            return type.Equals(typeof(int)) || type.Equals(typeof(double)) || type.Equals(typeof(decimal));
        }

        private bool CheckType()
        {
            var type = typeof(T);

            if (type.IsGenericType)
            {
                var generic = type.GenericTypeArguments;
                if (IsNumericType(generic[0]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return IsNumericType(type) ? true : false;
            }
        }

        #endregion

    }
}











