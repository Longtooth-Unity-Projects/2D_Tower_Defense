using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] int splashScreenScene = 0;
    [SerializeField] const float defaultLoadSceneDelay = 3f;

    private int currentSceneIndex;


    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == splashScreenScene)
            LoadNextScene(defaultLoadSceneDelay);
    }

    private IEnumerator DelayLoadScene(float delay) { yield return new WaitForSeconds(delay); }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }

    public void LoadNextScene(float delay = defaultLoadSceneDelay)
    {
        StartCoroutine(DelayLoadScene(delay));
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadGameOverScene(float delay = 0f)
    {
        StartCoroutine(DelayLoadScene(delay));
        SceneManager.LoadScene("GameOverScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
