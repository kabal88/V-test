using UnityEngine;

namespace Views
{
    public class UnitView : MonoBehaviour
    {
        private ColorHolder _colorHolder;
        
        public void Init(Material color)
        {
            _colorHolder = GetComponentInChildren<ColorHolder>(true);
            _colorHolder.SetColor(color);
        }
    }
}