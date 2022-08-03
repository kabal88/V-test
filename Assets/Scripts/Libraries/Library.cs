using System;
using System.Collections.Generic;
using System.Linq;
using Descriptions;
using Interfaces;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;


namespace Libraries
{
    [Serializable]
    public sealed class Library
    {
        [SerializeField] private List<Description> Descriptions = new();
        
        private Dictionary<int, IGameDescription> _gameDescriptions = new();
        private Dictionary<int, IUnitCharacteristicsDescription> _unitCharacteristicsDescriptions = new();


        public void Init()
        {
            foreach (var description in Descriptions)
            {
                switch (description.GetDescription)
                {
                    case IGameDescription data:
                        _gameDescriptions.Add(description.GetDescription.Id, data);
                        break;
                    case IUnitCharacteristicsDescription data:
                        _unitCharacteristicsDescriptions.Add(description.GetDescription.Id,data);
                        break;
                }
            }
        }
        
#if UNITY_EDITOR
        
        /// <summary>
        /// Work ONLY from Editor. Use after adding new Description to project. 
        /// </summary>
        [Button(ButtonSizes.Large), GUIColor(0.5f, 0.8f, 1f), PropertyTooltip("Click after adding new Description to project.")]
        public void CollectAllDescriptions()
        {
            Descriptions = AssetDatabase.FindAssets("t:Description")
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(AssetDatabase.LoadAssetAtPath<Description>).ToList();
        }
        
#endif
        public IGameDescription GetGameDescription(int id)
        {
            if (_gameDescriptions.TryGetValue(id, out var needed))
            {
                return needed;
            }
            throw new Exception($"Game description with id {id} not found");
        }

        public IUnitCharacteristicsDescription GetUnitCharacteristicsDescription(int id)
        {
            if (_unitCharacteristicsDescriptions.TryGetValue(id, out var needed))
            {
                return needed;
            }
            throw new Exception($"Unit Characteristics description with id {id} not found");
        }
    }
}