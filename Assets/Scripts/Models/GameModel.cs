using System;
using System.Collections.Generic;
using System.Linq;
using Controllers;
using Data;
using Interfaces;

namespace Models
{
    public class GameModel : IRepository<UnitController>
    {
        private List<UnitController> _unitsOnField;
        
        public List<SideSettings> SideRandomSettings { get; }
        public IEnumerable<UnitController> UnitsOnField => _unitsOnField;


        public GameModel( List<SideSettings> sideRandomSettings)
        {
            SideRandomSettings = sideRandomSettings;
            _unitsOnField = new List<UnitController>();
        }

        public void RegisterObject(UnitController obj)
        {
            _unitsOnField.Add(obj);
        }

        public void UnRegisterObject(UnitController obj)
        {
            _unitsOnField.Remove(obj);
        }

        public IEnumerable<UnitController> GetObjectsByPredicate(Func<UnitController, bool> predicate)
        {
            return UnitsOnField.Where(predicate);
        }

        public void ClearUnitsList()
        {
            _unitsOnField.Clear();
        }
    }
}