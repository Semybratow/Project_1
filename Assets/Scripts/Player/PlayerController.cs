using UnityEngine;

namespace DefaultNamespace.Player
{
    public class PlayerController : MonoBehaviour
    {
        public event OnSwipeInput SwipeInput;
        public delegate void OnSwipeInput(Vector2 swipeDirection);
    
        private Vector2 _tapPosition;
        private Vector2 _swipeDirection;
    
        [SerializeField] private float deadZone; 
    
        private bool _isSwiped;
        
        public void CheckSwipe()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    _isSwiped = true;
                    _tapPosition = Input.GetTouch(0).position;
                }
                else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    if (_isSwiped)
                    {
                      StartSwipe(touch.position);   
                    }
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    ResetSwipe();
                }
            }
        }
        
        private void StartSwipe(Vector2 currentPosition)
        {
            _swipeDirection = currentPosition - _tapPosition;
            if (_swipeDirection.magnitude > deadZone)
            {
                if (SwipeInput != null)
                {
                    if (Mathf.Abs(_swipeDirection.x) > Mathf.Abs(_swipeDirection.y))
                    {
                        SwipeInput(_swipeDirection.x > 0 ? Vector2.right : Vector2.left);
                    }
                    else
                    {
                        SwipeInput(_swipeDirection.y > 0 ? Vector2.up : Vector2.down);
                    }
                    _tapPosition = currentPosition;
                } 
            }
        }
        
        private void ResetSwipe()
        {
            _isSwiped = false;
            _tapPosition = Vector2.zero;
            _swipeDirection = Vector2.zero;
        }
    }
}