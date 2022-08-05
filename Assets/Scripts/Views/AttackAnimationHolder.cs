using UnityEngine;

namespace Views
{
    public class AttackAnimationHolder : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _attackParticles;

        public void Play()
        {
            _attackParticles.Play();
        }
    }
}