using System;
using UnityEngine;
using UnityEngine.UI;
namespace Menu
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private int _indexGameScene;
        [SerializeField] private UILayerMenu _uiLayerMenu;
        [SerializeField] private Button _startGameButton;
        private void Start()
        {
            if (_uiLayerMenu == null)
            {
                Debug.LogError("UILayerMenu is null");
                return;
            }
            
            if (_startGameButton == null)
            {
               Debug.LogError("StartGameButton is null");
               return;
            }

            Debug.Log("All Menu services loaded");

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Start Game");
                
            }
            
            _startGameButton.onClick.AddListener( () =>
            {
                _uiLayerMenu.OnStartGameClick(_indexGameScene);
            });
        }
    }
}