using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void ReloadCurrentScene()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);
    }

    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        int totalAmountOfScenes = SceneManager.sceneCountInBuildSettings;

        if (nextSceneIndex == totalAmountOfScenes)
        {
            nextSceneIndex = 1;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
