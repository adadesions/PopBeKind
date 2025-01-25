using UnityEngine;
using UnityEngine.SceneManagement;

namespace TitleScene.Scripts
{
    public class LoadManager : MonoBehaviour
    {
        public void ExitGame()
        {
            Application.Quit();
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
