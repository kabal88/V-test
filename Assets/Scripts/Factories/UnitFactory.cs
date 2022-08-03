using System.Linq;
using Controllers;
using Data;
using Interfaces;
using Libraries;
using Models;
using Services;
using Systems;
using Unity.Mathematics;
using UnityEngine;

namespace Factories
{
    public class UnitFactory
    {
        private Library _library;

        public UnitFactory(Library library)
        {
            _library = library;
        }

        public UnitController CreateRandomUnit(int side)
        {
          var spawnData =  ServiceLocator.Get<SpawnService>()
                .GetObjectsByPredicate(point => point.Side == side && point.IsEmpty == false).FirstOrDefault()!.Data;
            return CreateUnit(0, 0, 0, 0, side, spawnData);
        }

        private UnitController CreateUnit(int baseUnitID, int colorID, int sizeID, int shapeID, int side,
            SpawnData spawnData)
        {
            var baseDescription = _library.GetUnitCharacteristicsDescription(baseUnitID);
            var colorDescription = _library.GetUnitCharacteristicsDescription(colorID);
            var sizeDescription = _library.GetUnitCharacteristicsDescription(sizeID);
            var shapeDescription = _library.GetUnitCharacteristicsDescription(shapeID);

            var healthData = CalculateHealthData(baseDescription.HealthData, colorDescription.HealthData,
                sizeDescription.HealthData, shapeDescription.HealthData);
            var attackData = CalculateAttackData(baseDescription.AttackData, colorDescription.AttackData,
                sizeDescription.AttackData, shapeDescription.AttackData);
            var speed = baseDescription.Speed + colorDescription.Speed + sizeDescription.Speed + shapeDescription.Speed;

            Material color;
            GameObject prefab;
            float size;

            if (colorDescription is IColorCharacteristicDescription colorData)
            {
                color = colorData.Color;
            }
            else
            {
                color = default;
            }

            if (shapeDescription is IShapeCharacteristicDescription shapeData)
            {
                prefab = shapeData.Prefab;
            }
            else
            {
                prefab = default;
            }

            if (sizeDescription is ISizeCharacteristicDescription sizeData)
            {
                size = sizeData.Size;
            }
            else
            {
                size = 1f;
            }

            var model = new UnitModel(healthData, attackData, speed, side);

            return new UnitController(model, prefab, spawnData, color, size);
        }

        private HealthData CalculateHealthData(params HealthData[] healthParams)
        {
            var maxHealth = 0f;
            var currentHealth = 0f;

            for (var i = 0; i < healthParams.Length; i++)
            {
                maxHealth += healthParams[i].MaxHealth;
                currentHealth += healthParams[i].CurrentHealth;
            }

            return new HealthData { MaxHealth = maxHealth, CurrentHealth = currentHealth };
        }

        private AttackData CalculateAttackData(params AttackData[] attackParams)
        {
            var attack = 0f;
            var attackSpeed = 0f;

            for (var i = 0; i < attackParams.Length; i++)
            {
                attack += attackParams[i].Attack;
                attackSpeed += attackParams[i].AttackSpeed;
            }

            return new AttackData { Attack = attack, AttackSpeed = attackSpeed };
        }
    }
}