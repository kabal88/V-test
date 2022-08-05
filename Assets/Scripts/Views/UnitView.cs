using UnityEngine;

namespace Views
{
    public class UnitView : MonoBehaviour
    {
        private ColorHolder _colorHolder;
        private SizeHolder _sizeHolder;
        private NavMeshAgentHolder _navMeshAgentHolder;
        private AttackAnimationHolder _attackAnimationHolder;

        public Vector3 Position => transform.position;

        public void Init(Material color, float size, float speed)
        {
            _colorHolder = GetComponentInChildren<ColorHolder>();
            _sizeHolder = GetComponentInChildren<SizeHolder>();
            _navMeshAgentHolder = GetComponentInChildren<NavMeshAgentHolder>();
            _navMeshAgentHolder.SetSpeed(speed);
            _navMeshAgentHolder.SetSize(size / 2);
            _colorHolder.SetColor(color);
            _sizeHolder.SetSize(size);
            _attackAnimationHolder = GetComponentInChildren<AttackAnimationHolder>();
        }

        public void SetTarget(Vector3 target)
        {
            _navMeshAgentHolder.SetTarget(target);
        }

        public void PlayHitAnimation()
        {
            _attackAnimationHolder.Play();
        }
    }
}