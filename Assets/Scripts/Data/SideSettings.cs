using System;
using System.Collections.Generic;
using Identifier;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Data
{
    [Serializable]
    public class SideSettings
    {
        [SerializeField] private SideIdentifier _sideIdentifier;
        [SerializeField] private int _armySize = 20;
        [SerializeField, TableList] private List<RandomContainer<BaseUnitCharacteristicsIdentifier>> _baseUnitCharacteristics;
        [SerializeField, TableList] private List<RandomContainer<ColorIdentifier>> _colorCharacteristics;
        [SerializeField, TableList] private List<RandomContainer<SizeIdentifier>> _sizeCharacteristics;
        [SerializeField, TableList] private List<RandomContainer<ShapeIdentifier>> _shapeCharacteristics;

        public int SideID => _sideIdentifier.Id;
        public int ArmySize => _armySize; 
        public IEnumerable<RandomContainer<BaseUnitCharacteristicsIdentifier>> BaseUnitCharacteristics =>
            _baseUnitCharacteristics;
        public IEnumerable<RandomContainer<ColorIdentifier>> ColorCharacteristics => _colorCharacteristics;
        public IEnumerable<RandomContainer<SizeIdentifier>> SizeCharacteristics => _sizeCharacteristics;
        public IEnumerable<RandomContainer<ShapeIdentifier>> ShapeCharacteristics => _shapeCharacteristics;
    }
}