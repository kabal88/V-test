using Data;

namespace Models
{
    public class UnitModel
    {
        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; private set; }
        public float Speed { get; private set; }
        public float Attack { get; private set; }
        public float AttackSpeed { get; private set; }

        public UnitModel(HealthData healthData, AttackData attackData, float speed)
        {
            MaxHealth = healthData.MaxHealth;
            CurrentHealth = healthData.CurrentHealth;
            Speed = speed;
            Attack = attackData.Attack;
            AttackSpeed = attackData.AttackSpeed;
        }
    }
}