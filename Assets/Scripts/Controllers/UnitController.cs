using Data;
using Models;
using UnityEngine;
using Views;

namespace Controllers
{
    public class UnitController
    {
        private UnitModel _model;
        private UnitView _view;

        public UnitController(UnitModel model, GameObject prefab, SpawnData spawnData, Material color, float size)
        {
            _model = model;
            _view = GameObject.Instantiate(prefab, spawnData.Position, spawnData.Rotation).GetComponent<UnitView>();
            _view.Init(color);
        }
    }
}