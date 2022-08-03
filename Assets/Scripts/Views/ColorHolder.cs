using UnityEngine;

namespace Views
{
    public class ColorHolder : MonoBehaviour
    {
        private Renderer _renderer;

        public void SetColor(Material color)
        {
            _renderer.material = color;
        }
    }
}