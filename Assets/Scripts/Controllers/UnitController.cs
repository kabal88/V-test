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

        public UnitController(UnitModel model, GameObject root, GameObject shape, SpawnData spawnData, Material color, float size)
        {
            _model = model;
            var obj = GameObject.Instantiate(root, spawnData.Position, spawnData.Rotation).GetComponent<UnitView>();
            GameObject.Instantiate(shape, obj.transform);
            _view = obj.GetComponent<UnitView>();
            _view.Init(color,size);
        }
    }
}