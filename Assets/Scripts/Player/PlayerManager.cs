using GamePlay;
using UnityEngine;

namespace DefaultNamespace.Player
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerController playerController;
        [SerializeField] private BorderControllerScene borderControllerScene;
        
        private float _halfWidth, _halfHeight;
        private bool _isGrounded;
        private void Start()
        {
            CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();
            if (circleCollider != null)
            {
                Vector3 coliderSize = circleCollider.bounds.size;
                _halfWidth = coliderSize.x;
                _halfHeight = coliderSize.y;
            }
            else
            {
                Debug.LogWarning("CircleCollider2D not found");
                _halfWidth = 0.5f;
                _halfHeight = 0.5f;
            }
            
            if (playerMovement == null)
            {
                Debug.LogError("PlayerMovement is null");
            }
            
            if (playerController == null)
            {
                Debug.LogError("PlayerController is null");
            }
            
            if (borderControllerScene == null)
            {
                Debug.LogError("PlayerController is null");
            }
        }
        
        public void PlayerService()
        {
            playerMovement?.Move();
            playerController?.CheckSwipe();
            borderControllerScene?.BorderCameraController(_halfWidth, _halfHeight);
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGrounded = true;
                playerMovement?.JumpOnGround();
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGrounded = false;
            }
        }
    }
}