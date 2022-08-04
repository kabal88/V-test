using UnityEngine;

namespace Views
{
    public class UnitView : MonoBehaviour
    {
        private ColorHolder _colorHolder;
        private SizeHolder _sizeHolder;

        public void Init(Material color, float size)
        {
            _colorHolder = GetComponentInChildren<ColorHolder>();
            _sizeHolder = GetComponentInChildren<SizeHolder>();
            _colorHolder.SetColor(color);
            _sizeHolder.SetSize(size);
        }
    }
}