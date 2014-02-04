using System;
using System.Linq.Expressions;

namespace lib12.Extensions
{
    public static class ObjectExtension
    {
        public class NullResult
        {
            private readonly bool result;

            public NullResult(bool result)
            {
                this.result = result;
            }

            public static implicit operator bool(NullResult nullResult)
            {
                return nullResult.result;
            }

            /// <summary>
            /// Throw exception if checked object is null
            /// </summary>
            public void ThrowException()
            {
                if (result)
                    throw new NullReferenceException();
            }
        }

        public class NotNullResult<TObject> where TObject : class
        {
            private readonly bool result;
            private readonly TObject self;

            public NotNullResult(TObject self)
            {
                this.self = self;
                result = self != null;
            }

            public static implicit operator bool(NotNullResult<TObject> notNullResult)
            {
                return notNullResult.result;
            }

            public TValue Get<TValue>(Expression<Func<TObject, TValue>> expression, TValue defaultValue = default(TValue))
            {
                if (result)
                    return expression.Compile().Invoke(self);
                else
                    return defaultValue;
            }
        }

        /// <summary>
        /// Check if given object is null
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static NullResult Null(this object self)
        {
            return new NullResult(self == null);
        }

        /// <summary>
        /// Check if given object is not null
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static NotNullResult<TObject> NotNull<TObject>(this TObject self) where TObject : class
        {
            return new NotNullResult<TObject>(self);
        }
    }
}