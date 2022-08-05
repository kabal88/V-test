using UnityEngine;
using UnityEngine.AI;

namespace Views
{
    public class NavMeshAgentHolder : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;

        public void SetSpeed(float speed)
        {
            _agent.speed = speed;
        }

        public void SetSize(float size)
        {
            _agent.radius = size;
        }
        
        public void SetTarget(Vector3 target)
        {
            _agent.destination = target;
        }
    }
}