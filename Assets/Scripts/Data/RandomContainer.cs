using System;
using Identifier;

namespace Data
{
    [Serializable]
    public struct RandomContainer<T> where T : IdentifierContainer
    {
        public T Identifier;
        public float Weight;
    }
}