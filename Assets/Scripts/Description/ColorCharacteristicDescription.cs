using System;
using Data;
using Identifier;
using Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Descriptions
{
    [Serializable]
    public class ColorCharacteristicDescription : IColorCharacteristicDescription
    {
        [SerializeField] private ColorIdentifier _identifier;
        [SerializeField, BoxGroup("Color")] private Material _color;
        [SerializeField, BoxGroup("Health"), HideLabel] private HealthData _healthData;
        [SerializeField, BoxGroup("Attack"), HideLabel] private AttackData _attackData;
        [SerializeField, BoxGroup("Movement")] private float _speed;

        public int Id => _identifier.Id;
        public HealthData HealthData => _healthData;
        public AttackData AttackData => _attackData;
        public float Speed => _speed;
        public Material Color => _color;
    }
}