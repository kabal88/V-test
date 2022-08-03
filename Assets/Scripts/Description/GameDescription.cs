using System;
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

        public int Id => _id.Id;
        public GameModel Model => new GameModel();
    }
}