using System;
using System.Collections.Generic;
using Data;
using Identifier;
using Interfaces;
using Models;
using UnityEngine;

namespace Descriptions
{
    [Serializable]
    public class GameDescription : IGameDescription
    {
        [SerializeField] private GameIdentifier _id;

        [SerializeField] private List<SideSettings> SideSettings;

        public int Id => _id.Id;
        public GameModel Model => new GameModel();
    }
}