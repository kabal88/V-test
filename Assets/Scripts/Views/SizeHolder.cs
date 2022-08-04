using UnityEngine;

namespace Views
{
    public class SizeHolder : MonoBehaviour
    {
        [SerializeField] private Transform _meshTransform;
        public void SetSize(float size)
        {
            _meshTransform.localScale = new Vector3(size,size,size);
            var position = _meshTransform.localPosition;
            position.y = size / 2;
            _meshTransform.localPosition = position;
        }
    }
}