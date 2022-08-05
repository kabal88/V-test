using System;
using Data;
using Identifier;
using Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Descriptions
{
    [Serializable]
    public class BaseUnitCharacteristicDescription : IBaseUnitCharacteristicDescription
    {
        [SerializeField] private BaseUnitCharacteristicsIdentifier _identifier;
        [SerializeField, BoxGroup("Prefab"), AssetsOnly] private GameObject _rootPrefab;
        [SerializeField, BoxGroup("Health"), HideLabel] private HealthData _healthData;
        [SerializeField, BoxGroup("Attack"), HideLabel] private AttackData _attackData;
        [SerializeField, BoxGroup("Attack")] private float _timeBetweenAttack;
        [SerializeField, BoxGroup("Movement")] private float _speed;

        public int Id => _identifier.Id;
        public float Speed => _speed;
        public float BaseTimeBetweenAttack => _timeBetweenAttack;
        public HealthData HealthData => _healthData;
        public AttackData AttackData => _attackData;
        public GameObject RootPrefab => _rootPrefab;
    }
}