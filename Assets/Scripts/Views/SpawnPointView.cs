using System.Linq;
using Data;
using Identifier;
using Interfaces;
using UnityEditor;
using UnityEngine;

namespace Views
{
    public class SpawnPointView : MonoBehaviour, ISpawnPoint
    {
        [SerializeField] private SideIdentifier _side;
        private readonly float _radius = 0.1f;
        public bool IsEmpty { get; private set; }

        public int Side => _side.Id;

        public SpawnData Data { get; private set; }

        public void SetIsEmpty(bool value)
        {
            IsEmpty = value;
        }

        public void Init()
        {
            Data = new SpawnData { Position = transform.position, Rotation = transform.rotation };
            IsEmpty = true;
        }

#if UNITY_EDITOR


        public void OnDrawGizmos()
        {
            Handles.color = new Color(0, 1, 0, 0.7f);
            var position = transform.position;
            Handles.DrawSolidDisc(position, Vector3.up, _radius);

            if (_side != null)
            {
                Handles.color = new Color(1f, 0.7f, 0.1f, 1);
                Handles.Label(position, _side.name.LastOrDefault().ToString());
            }
            else
            {
                Handles.color = new Color(1f, 0.7f, 0.1f, 1);
                Handles.Label(position, "NONE");
            }
        }
    }
#endif

}