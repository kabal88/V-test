using System;
using UnityEngine;

namespace Views
{
    public class UnitView : MonoBehaviour
    {
        public Action Callback; //todo: delete
        
        private ColorHolder _colorHolder;
        private SizeHolder _sizeHolder;
        private NavMeshAgentHolder _navMeshAgentHolder;
        private AttackAnimationHolder _attackAnimationHolder;
        private HitAnimationHolder _hitAnimationHolder;
        private DeadAnimationHolder _deadAnimationHolder;

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
            _hitAnimationHolder = GetComponentInChildren<HitAnimationHolder>();
            _deadAnimationHolder = GetComponentInChildren<DeadAnimationHolder>();
            _navMeshAgentHolder.SetActive(true);
        }

        public void SetTarget(Vector3 target)
        {
            _navMeshAgentHolder.SetTarget(target);
        }

        public void PlayAttackAnimation()
        {
            _attackAnimationHolder.Play();
        }

        public void PlayDeadAnimation()
        {
            _deadAnimationHolder.Play();
            _navMeshAgentHolder.SetActive(false);
        }

        public void PlayHitedAnimation()
        {
            _hitAnimationHolder.Play();
        }

        private void OnDrawGizmos() //todo: delete
        {
            Callback?.Invoke();
        }
    }
}