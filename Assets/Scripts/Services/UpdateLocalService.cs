using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Services
{
    public sealed class UpdateLocalService : IUpdateService
    {
        private readonly List<IUpdatable> _updatables;
        
        public UpdateLocalService()
        {
            _updatables = new List<IUpdatable>();
        }

        public void RegisterObject(IUpdatable updatable)
        {
            _updatables.Add(updatable);
        }

        public void UnRegisterObject(IUpdatable updatable)
        {
            _updatables.Remove(updatable);
        }

        public IEnumerable<IUpdatable> GetObjectsByPredicate(Func<IUpdatable, bool> predicate)
        {
            return _updatables.Where(predicate);
        }

        public void UpdateLocal(float deltaTime)
        {
            for (var index = 0; index < _updatables.Count; index++)
            {
                _updatables[index].UpdateLocal(deltaTime);
            }
        }
    }
}