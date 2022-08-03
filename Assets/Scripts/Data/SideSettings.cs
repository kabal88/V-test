using System;
using System.Collections.Generic;
using Identifier;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class SideSettings
    {
        [SerializeField] private SideIdentifier _sideIdentifier;
        [SerializeField] private List<RandomContainer<BaseUnitCharacteristicsIdentifier>> _baseUnitCharacteristics;
        [SerializeField] private List<RandomContainer<ColorIdentifier>> _colorCharacteristics;
        [SerializeField] private List<RandomContainer<SizeIdentifier>> _sizeCharacteristics;
        [SerializeField] private List<RandomContainer<ShapeIdentifier>> _shapeCharacteristics;

        public int SideID => _sideIdentifier.Id;
        public IEnumerable<RandomContainer<BaseUnitCharacteristicsIdentifier>> BaseUnitCharacteristics =>
            _baseUnitCharacteristics;
        public IEnumerable<RandomContainer<ColorIdentifier>> ColorCharacteristics => _colorCharacteristics;
        public IEnumerable<RandomContainer<SizeIdentifier>> SizeCharacteristics => _sizeCharacteristics;
        public IEnumerable<RandomContainer<ShapeIdentifier>> ShapeCharacteristics => _shapeCharacteristics;
    }
}