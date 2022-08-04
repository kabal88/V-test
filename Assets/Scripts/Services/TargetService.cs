using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Services
{
    public class TargetService : IRepository<ITarget>
    {
        private List<ITarget> _targets = new();

        public void RegisterObject(ITarget obj)
        {
            _targets.Add(obj);
        }

        public void UnRegisterObject(ITarget obj)
        {
            _targets.Remove(obj);
        }

        public IEnumerable<ITarget> GetObjectsByPredicate(Func<ITarget, bool> predicate)
        {
            return _targets.Where(predicate);
        }
    }
}