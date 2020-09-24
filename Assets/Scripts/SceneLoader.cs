using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] int splashScreenScene = 0;
    [SerializeField] float loadScreenDelay = 3f;

    private int currentScreenIndex;


    // Start is called before the first frame update
    void Start()
    {
        currentScreenIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentScreenIndex == splashScreenScene)
        {
            StartCoroutine(DelayLoadScene());
        }
    }

    private IEnumerator DelayLoadScene()
    {
        yield return new WaitForSeconds(loadScreenDelay);
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(currentScreenIndex + 1);
    }
}
