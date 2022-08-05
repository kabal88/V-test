using DG.Tweening;
using Tweens;
using UnityEngine;

namespace Views
{
    public class DeadAnimationHolder : BaseParticleAnimation
    {
        [SerializeField] private MoveParams _moveParams;
        [SerializeField] private Transform _meshTransform;

        private Tween _tween;

        public override void Play()
        {
            base.Play();
            _tween = _meshTransform.DOLocalMove(_moveParams.Target, _moveParams.Duration)
                .SetEase(_moveParams.Ease);
        }

        private void OnDestroy()
        {
            _tween.Kill();
        }
    }
}