using UnityEngine;

namespace Utilities
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteFlipper : MonoBehaviour
    {
        private const float threshold = 0.1f;
        
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Collider2D[] _colliders;
        private SpriteRenderer _spriteRenderer;

        private bool _wasFlippedAtStart;
        private Vector2[] _colliderOffsets;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _wasFlippedAtStart = _spriteRenderer.flipX;
            
            _colliderOffsets = new Vector2[_colliders.Length];
            for (var i = 0; i < _colliders.Length; i++) _colliderOffsets[i] = _colliders[i].offset;
        }

        private void Update()
        {
            if (_rigidbody2D == null) return;

            var velocityX = _rigidbody2D.velocity.x;
            if (velocityX < -threshold)
            {
                if (_wasFlippedAtStart) ResetFlip();
                else Flip();
            }
            else if (velocityX > threshold)
            {
                if (_wasFlippedAtStart) Flip();
                else ResetFlip();
            }
        }

        private void Flip()
        {
            _spriteRenderer.flipX = true;
                    
            for (var i = 0; i < _colliders.Length; i++)
            {
                var offset = _colliderOffsets[i];
                offset.x = -_colliderOffsets[i].x;
                _colliders[i].offset = offset;
            }
        }

        private void ResetFlip()
        {
            _spriteRenderer.flipX = false;

            for (var i = 0; i < _colliders.Length; i++)
            {
                _colliders[i].offset = _colliderOffsets[i];
            }
        }
    }
}