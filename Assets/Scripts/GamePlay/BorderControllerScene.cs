using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GamePlay
{
    public class BorderControllerScene : MonoBehaviour
    {
        private Camera _mainCamera;
        private float _randomPosition;
        private void Start()
        {
            _mainCamera = Camera.main;
        }
        
        public void BorderCameraController(float halfWidth, float halfHeight)
        {
            
            Vector3 minBounds = _mainCamera.ScreenToWorldPoint(new Vector3(0, 0));
            Vector3 maxBounds = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

            float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
            float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);

            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
        
        public void BorderCameraControllerPlatform(GameObject platform, float halfWidth)
        {
            
            Vector3 minBounds = _mainCamera.ScreenToWorldPoint(new Vector3(0, 0));
            Vector3 maxBounds = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            
            float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
            
            platform.transform.position = new Vector3(clampedX, transform.position.y);
        }
    }
}