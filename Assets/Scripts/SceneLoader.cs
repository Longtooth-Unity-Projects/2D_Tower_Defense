using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] int splashScreenScene = 0;
    [SerializeField] float loadSceneDelay = 3f;

    private int currentSceneIndex;


    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == splashScreenScene)
        {
            StartCoroutine(DelayLoadScene());
        }
    }

    private IEnumerator DelayLoadScene()
    {
        yield return new WaitForSeconds(loadSceneDelay);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");

    }
}
