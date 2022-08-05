using System.Collections.Generic;
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
        

        public UnitController CreateUnit(UnitConfig config, ISpawnPoint spawnPoint)
        {
            return CreateUnit(config.BaseUnitID, config.ColorID, config.SizeID, config.ShapeID, config.SideID,
                spawnPoint);
        }

        public UnitController CreateUnit(int baseUnitID, int colorID, int sizeID, int shapeID, int side,
            ISpawnPoint spawnPoint)
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
            GameObject root;
            GameObject shape;
            float size;
            float baseTimeBetweenAttack;
            SpawnData spawnData;

            if (baseDescription is IBaseUnitCharacteristicDescription baseData)
            {
                root = baseData.RootPrefab;
                baseTimeBetweenAttack = baseData.BaseTimeBetweenAttack;
            }
            else
            {
                baseTimeBetweenAttack = 0;
                root = default;
            }

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
                shape = shapeData.Prefab;
            }
            else
            {
                shape = default;
            }

            if (sizeDescription is ISizeCharacteristicDescription sizeData)
            {
                size = sizeData.Size;
            }
            else
            {
                size = 1f;
            }

            if (spawnPoint != null)
            {
                spawnData = spawnPoint.Data;
                spawnPoint.SetIsEmpty(false);
            }
            else
            {
                spawnData = new SpawnData { Position = Vector3.zero, Rotation = quaternion.identity };
            }

            var model = new UnitModel(healthData, attackData, speed, side, baseTimeBetweenAttack);
            var unit = new UnitController(model, root, shape, spawnData, color, size);

            return unit;
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
            var attackDistance = 0f;

            for (var i = 0; i < attackParams.Length; i++)
            {
                attack += attackParams[i].Attack;
                attackSpeed += attackParams[i].AttackSpeed;
                attackDistance += attackParams[i].AttackDistance;
            }

            return new AttackData { Attack = attack, AttackSpeed = attackSpeed , AttackDistance = attackDistance};
        }
    }
}