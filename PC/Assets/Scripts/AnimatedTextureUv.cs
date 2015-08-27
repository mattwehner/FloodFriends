using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class AnimatedTextureUv : MonoBehaviour
    {

        private int _uvTieX = 6;
        private int _uvTieY = 8;
        private float _fps = 10.0f;

        private Vector2 _size;
        private Renderer _myRenderer;

        void Awake()
        {
            _myRenderer = GetComponent<Renderer>();
        }

        void Start()
        {
            _size = new Vector2(1.0f / _uvTieX, 1.0f / _uvTieY);
            
            if (_myRenderer == null)
                enabled = false;
        }

        void FixedUpdate()
        {
            int index = (int)(Time.timeSinceLevelLoad * _fps) % (_uvTieX * _uvTieY);

                int uIndex = index % _uvTieX;
                int vIndex = index / _uvTieY;

                Vector2 offset = new Vector2(uIndex * _size.x, 1.0f - _size.y - vIndex * _size.y);

                _myRenderer.material.SetTextureOffset("_MainTex", offset);
                _myRenderer.material.SetTextureScale("_MainTex", _size);
        }
    }
}
