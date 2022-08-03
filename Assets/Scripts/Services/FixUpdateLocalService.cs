using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Services
{
    public sealed class FixUpdateLocalService : IFixUpdateService
    {
        private readonly List<IFixUpdatable> _fixUpdatables;

        public FixUpdateLocalService()
        {
            _fixUpdatables = new List<IFixUpdatable>();
        }

        public void RegisterObject(IFixUpdatable obj)
        {
            _fixUpdatables.Add(obj);
        }

        public void UnRegisterObject(IFixUpdatable obj)
        {
            _fixUpdatables.Remove(obj);
        }

        public IEnumerable<IFixUpdatable> GetObjectsByPredicate(Func<IFixUpdatable, bool> predicate)
        {
            return _fixUpdatables.Where(predicate);
        }

        public bool TryGetObject(out IFixUpdatable obj)
        {
            obj = _fixUpdatables.FirstOrDefault();
            return obj != null;
        }

        public void FixedUpdateLocal()
        {
            foreach (var updatable in _fixUpdatables)
            {
                updatable.FixedUpdateLocal();
            }
        }
    }
}