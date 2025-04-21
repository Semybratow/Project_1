using UnityEngine;

namespace DefaultNamespace.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private float _moveDistance;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _moveSpeed;
        
        private Rigidbody2D _rb;
        private Vector2 _currentSwipeDirection;

        private void Start()
        {
            _rb = GetComponentInParent<Rigidbody2D>();
            if (playerController != null && _rb != null)
            {
                playerController.SwipeInput += OnSwipeDetected;
            }
            else
            {
                Debug.LogError("No player controller attached");
            }
        }

        public void Move()
        {
            if (_currentSwipeDirection != Vector2.zero)
            {
                if (_currentSwipeDirection == Vector2.left || _currentSwipeDirection == Vector2.right)
                {
                    _rb.AddForce((Vector2.up + _currentSwipeDirection * 0.5f) * _jumpForce, ForceMode2D.Impulse);
                   // _rb.linearVelocity = new Vector2(_currentSwipeDirection.x * _moveSpeed, _rb.linearVelocity.y);
                    Debug.Log($"Swiped {_rb.linearVelocity}");
                }
                else if (_currentSwipeDirection == Vector2.up || _currentSwipeDirection == Vector2.down)
                {
                    _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                    Debug.Log("Jumped");
                }
                _currentSwipeDirection = Vector2.zero;
            }
        }
        
        private void OnSwipeDetected(Vector2 direction)
        {
            _currentSwipeDirection = direction;
        }

        public void JumpOnGround()
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}