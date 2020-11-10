using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider difficultySlider;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        GameMusicPlayer musicPlayer = FindObjectOfType<GameMusicPlayer>();
        if (musicPlayer)
            musicPlayer.SetVolume(volumeSlider.value);
        else
            Debug.LogWarning("No music player found.");
    }

    public void SetDefaults()
    {
        volumeSlider.value = PlayerPrefsController.GetDefaultVolume();
        difficultySlider.value = PlayerPrefsController.GetDefaultDifficulty();
    }

    public void SaveAndLoadMainMenu()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(Mathf.RoundToInt(difficultySlider.value));
        FindObjectOfType<SceneLoader>().LoadMainMenu();
    }
}
