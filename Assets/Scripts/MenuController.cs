using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string LevelToLoad = "Scene1";
    public void PlayGame()
    {
        SceneManager.LoadScene(LevelToLoad);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
