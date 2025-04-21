using UnityEngine;

namespace GamePlay
{
    public class SpawnerPlatform : MonoBehaviour
    {   
        private Camera _mainCamera;
        
        [SerializeField] private GameObject _platformPrefab;
        private float _randomMinPositionX, _randomMaxPositionX;
        private Vector2 _platformToSpawn;
        private float _randomPosition;
        [SerializeField] private float _spawnDelay;
        private float _nextToSpawn = 0.0f;
        
        [SerializeField] private int _maxSpawnCount;
        private int _currentSpawnCount = 0;
        private float _platformWidth, _halfWidth;
        [SerializeField] private float _minWidthPlatform, _maxWidthPlatform, _startPositionY, _verticalGap;
        private float _currentPlatformGap;

        private void Start()
        {
            _mainCamera = Camera.main;
            _currentPlatformGap = _startPositionY;
        }
        
        public void PlatformToSpawn()
        {
            if (Time.time >= _nextToSpawn)
            {
                if (_currentSpawnCount >= _maxSpawnCount)
                {
                    return;
                }
                _nextToSpawn = Time.time + _spawnDelay;
                
                _platformWidth = Random.Range(_minWidthPlatform, _maxWidthPlatform);
                
                Vector3 minBounds = _mainCamera.ScreenToWorldPoint(new Vector3(0, 0));
                Vector3 maxBounds = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
                
                _halfWidth = _platformWidth / 2;
                _randomMinPositionX = minBounds.x + _halfWidth;
                _randomMaxPositionX = maxBounds.x - _halfWidth;
                _randomPosition = Random.Range(_randomMinPositionX, _randomMaxPositionX);
                
                _currentPlatformGap += _verticalGap;
                _platformToSpawn = new Vector2(_randomPosition, _currentPlatformGap);
                
                GameObject newPlatform = Instantiate(_platformPrefab, _platformToSpawn, Quaternion.identity);
                _currentSpawnCount++;

                WidthPlatform(newPlatform);
            }
        }

        private void WidthPlatform(GameObject platform)
        {
            BoxCollider2D boxCollider2D = platform.GetComponent<BoxCollider2D>();
            boxCollider2D.size = new Vector2(_platformWidth, 1f);
                
            Debug.Log($"{_platformWidth}");
                
            SpriteRenderer spriteRenderer = platform.GetComponent<SpriteRenderer>();
               
            if (spriteRenderer != null)
            {
                float scaleX = _platformWidth ;
                Vector3 currentScale = platform.transform.localScale;
                platform.transform.localScale = new Vector3(scaleX * currentScale.x, currentScale.y, currentScale.z);
                    
                Debug.Log($"{scaleX}");
            }
        }
    }
}