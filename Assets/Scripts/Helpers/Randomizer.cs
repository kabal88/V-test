using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Identifier;
using Random = UnityEngine.Random;

namespace Helpers
{
    public static class Randomizer
    {
        /// <summary>
        /// Random enum value. First member (usually "None") exclude.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T RandomEnumValue<T>() where T : Enum
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(Random.Range(1, v.Length));
        }

        /// <summary>
        /// Random int value in range
        /// </summary>
        /// <param name="min">inclusive</param>
        /// <param name="max">inclusive</param>
        /// <returns></returns>
        public static int RandomInt(int min, int max)
        {
            return Random.Range(min, max + 1);
        }

        /// <summary>
        /// Random ID with weight usage
        /// </summary>
        /// <param name="config">all IdentifierContainers with weight</param>
        /// <returns></returns>
        public static int RandomID<T>(this IEnumerable<RandomContainer<T>> config) where T : IdentifierContainer
        {
            var array = config.ToArray();
            var totalWeight = 0f;
            var result = 0;

            for (var i = 0; i < array.Length; i++)
            {
                totalWeight += array[i].Weight;
            }

            var randomWeight = Random.Range(0f, totalWeight);

            var currentWeight = 0f;
            for (var i = 0; i < array.Length; i++)
            {
                currentWeight += array[i].Weight;
                if (randomWeight < currentWeight)
                {
                    result = array[i].Identifier.Id;
                    break;
                }
            }

            return result;
        }
    }
}