using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace DefaultNamespace
{
    public class BootstrapEntryPoint : MonoBehaviour
    {
        [SerializeField] private int fps = 60;
        private IEnumerator Start()
        {
            var loadingDuration = 3f;
            while (loadingDuration > 0f)
            {
                loadingDuration -= Time.deltaTime;
                Debug.Log("Loading...");
                yield return null;
            }
            
            Application.targetFrameRate = fps;
            
            Debug.Log("All application services finished");
            
            SceneManager.LoadScene("MainMenu");
        }
    }
}