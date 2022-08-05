using Data;
using Interfaces;
using UnityEngine;

namespace Models
{
    public class UnitModel
    {
        private float _baseTimeBetweenAttack;
        public bool IsActive { get; private set; }
        public bool IsAlive => CurrentHealth > 0;
        public int Side { get; }
        public float MaxHealth { get; }
        public float CurrentHealth { get; private set; }
        public float Speed { get; }
        public float Attack { get;  }
        public float AttackSpeed { get;  }
        public float AttackDistance { get; }
        public float TimeBetweenAttack => _baseTimeBetweenAttack / AttackSpeed;
        public ITarget Target { get; private set; }
        public Vector3 Position { get; private set; }

        public UnitModel(HealthData healthData, AttackData attackData, float speed, int side, float baseTimeBetweenAttack)
        {
            MaxHealth = healthData.MaxHealth;
            CurrentHealth = healthData.CurrentHealth;
            Speed = speed;
            Side = side;
            Attack = attackData.Attack;
            AttackSpeed = attackData.AttackSpeed;
            AttackDistance = attackData.AttackDistance;
            _baseTimeBetweenAttack = baseTimeBetweenAttack;
        }

        public void SetIsActive(bool value)
        {
            IsActive = value;
        }

        public void SetTarget(ITarget target)
        {
            Target = target;
        }

        public void SetPosition(Vector3 position)
        {
            Position = position;
        }

        public void SetCurrentHealth(float value)
        {
            CurrentHealth = value;
        }
    }
}