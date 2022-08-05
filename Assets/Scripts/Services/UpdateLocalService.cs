using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Services
{
    public sealed class UpdateLocalService : IUpdateService
    {
        private readonly List<IUpdatable> _updatables;

        private Queue<IUpdatable> _updatablesForAdding;
        private Queue<IUpdatable> _updatablesForRemoving;

        public UpdateLocalService()
        {
            _updatables = new List<IUpdatable>();
            _updatablesForAdding = new Queue<IUpdatable>();
            _updatablesForRemoving = new Queue<IUpdatable>();
        }

        public void RegisterObject(IUpdatable updatable)
        {
            // _updatablesForAdding.Enqueue(updatable);
            _updatables.Add(updatable);
        }

        public void UnRegisterObject(IUpdatable updatable)
        {
            // _updatablesForRemoving.Enqueue(updatable);
            _updatables.Remove(updatable);
        }

        public IEnumerable<IUpdatable> GetObjectsByPredicate(Func<IUpdatable, bool> predicate)
        {
            return _updatables.Where(predicate);
        }

        public void UpdateLocal(float deltaTime)
        {
            // for (var i = 0; i < _updatablesForAdding.Count; i++)
            // {
            //     _updatables.Add(_updatablesForAdding.Dequeue());
            // }
            //
            // for (var i = 0; i < _updatablesForRemoving.Count; i++)
            // {
            //     _updatables.Remove(_updatablesForRemoving.Dequeue());
            // }

            for (var index = 0; index < _updatables.Count; index++)
            {
                var updatable = _updatables[index];
                updatable.UpdateLocal(deltaTime);
            }
        }
    }
}