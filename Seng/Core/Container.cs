using Seng.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seng.Core
{
    public sealed class Container
    {
        private enum RegistrationMode
        {
            Type,
            Instance,
            LazyInstance
        }

        private static Container _current;
        private Dictionary<Type, Func<object>> _constructors;
        private Dictionary<Type, object> _instances;
        private Dictionary<Type, Lazy<object>> _lazyInstances;
        private Dictionary<Type, RegistrationMode> _registrationTypes;

        public static Container Current
        {
            get
            {
                if (_current == null)
                    _current = new Container();
                return _current;
            }
        }

        public Container()
        {
            _constructors = new Dictionary<Type, Func<object>>();
            _instances = new Dictionary<Type, object>();
            _lazyInstances = new Dictionary<Type, Lazy<object>>();
            _registrationTypes = new Dictionary<Type, RegistrationMode>();
        }

        public void RegisterLazyInstance<T>(Func<T> constructor)
        {
            _lazyInstances.AddOrSet(typeof(T), new Lazy<object>(() => constructor));
            _registrationTypes.AddOrSet(typeof(T), RegistrationMode.LazyInstance);
        }

        public void RegisterInstance<T>(T instance)
        {
            _instances.AddOrSet(typeof(T), instance);
            _registrationTypes.AddOrSet(typeof(T), RegistrationMode.Instance);
        }

        public void RegisterType<T>(Func<T> constructor)
        {
            _constructors.AddOrSet(typeof(T), () => constructor);
            _registrationTypes.AddOrSet(typeof(T), RegistrationMode.Type);
        }

        public T Resolve<T>()
        {
            var type = typeof(T);
            if (!_registrationTypes.ContainsKey(type))
                return (T)TryResolve(type);

            return (T)GetRegistered(type);
        }

        private object GetRegistered(Type type)
        {
            switch (_registrationTypes[type])
            {
                case RegistrationMode.Instance:
                    return _instances[type];
                case RegistrationMode.Type:
                    return _constructors[type].Invoke();
                case RegistrationMode.LazyInstance:
                    return _lazyInstances[type].Value;
            }

            return null;
        }

        private object TryResolve(Type type)
        {
            var ctors = type.GetConstructors().OrderByDescending(x => x.GetParameters().Length);

            foreach (var ctor in ctors)
            {
                var isValid = true;

                foreach (var param in ctor.GetParameters())
                {
                    if (!_registrationTypes.ContainsKey(param.ParameterType))
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    var parameter = ctor.GetParameters();
                    _registrationTypes.AddOrSet(type, RegistrationMode.Type);

                    if (parameter.Length == 0)
                    {
                        _constructors.AddOrSet(type, () => Activator.CreateInstance(type));
                    }
                    else
                    {
                        var args = parameter.Select(x => GetRegistered(x.ParameterType)).ToArray();
                        _constructors.AddOrSet(type, () => Activator.CreateInstance(type, args));
                    }

                    return _constructors[type].Invoke();
                }
            }

            return null;
        }

        public void Dispose()
        {
            foreach (var instance in _instances.Where(x => x.Value is IDisposable))
                ((IDisposable)instance.Value).Dispose();

            foreach (var instance in _lazyInstances.Where(x => x.Value.IsValueCreated && x.Value.Value is IDisposable))
                ((IDisposable)instance.Value.Value).Dispose();

            _constructors = null;
            _instances = null;
            _lazyInstances = null;
            _registrationTypes = null;
        }
    }
}
