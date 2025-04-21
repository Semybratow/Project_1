using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class UILayerMenu : MonoBehaviour
    {
        public void OnStartGameClick(int indexScene)
        { 
            Debug.Log("Start Game");
            SceneManager.LoadScene(indexScene);
        }
    }
}