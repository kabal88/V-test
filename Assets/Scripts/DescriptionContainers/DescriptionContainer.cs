﻿using Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;
using Descriptions;


namespace DescriptionContainers
{
    public class DescriptionContainer<T> : Description where T : IDescription
    {
        [SerializeField, HideLabel] private T description;

        public override IDescription GetDescription => description;
    }
}