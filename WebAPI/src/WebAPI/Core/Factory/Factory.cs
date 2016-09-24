using System;
using System.Reflection;

namespace WebAPI.Core.Factory
{
    public class Factory<T> : IFactory<T>
    {
        public virtual T Create(Enum selection)
        {
            var typeString = string.Format("{0}.{1}", typeof(T).Namespace, selection.ToString());
            var type = Type.GetType(typeString, throwOnError: false);

            if (type == null)
            {
                var message = string.Format("{0} is not a known type", selection.ToString());
                throw new InvalidOperationException(message);
            }

            if (!typeof(T).IsAssignableFrom(type))
            {
                var message = string.Format("{0} does not inherit from {1}", type.Name, typeof(T).Name);
                throw new InvalidOperationException(message);
            }

            return (T)Activator.CreateInstance(type);
        }
    }
}
