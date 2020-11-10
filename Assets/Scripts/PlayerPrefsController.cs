using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    private const string MASTER_VOLUME_KEY = "masterVolume";
    private const string DIFFICULTY_KEY = "difficultyLevel";

    private const float MIN_VOLUME = 0f;
    private const float MAX_VOLUME = 1f;
    private const int MIN_DIFFICULTY = 0;
    private const int MAX_DIFFICULTY = 3;
    private const float DEFAULT_VOLUME = 0.5f;
    private const int DEFAULT_DIFFICULTY = 1;


    public static bool IsVolumeSet() { return PlayerPrefs.HasKey(MASTER_VOLUME_KEY); }
    
    public static bool IsDifficultySet() { return PlayerPrefs.HasKey(DIFFICULTY_KEY); }

    //setters and getters 
    public static void SetMasterVolume() { PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, DEFAULT_VOLUME); }
    public static  void SetMasterVolume(float volume) 
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        else
            Debug.LogError("masterVolume is out of range");
    }

    public static void SetDifficulty() { PlayerPrefs.SetInt(DIFFICULTY_KEY, DEFAULT_DIFFICULTY); }
    public static void SetDifficulty(int difficulty)
    {
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
            PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
        else
            Debug.LogError("difficultyLevel is out of range");
    }

    public static void SetDefaults()
    {
        SetMasterVolume(DEFAULT_VOLUME);
        SetDifficulty(DEFAULT_DIFFICULTY);
    }

    public static float GetDefaultVolume() { return DEFAULT_VOLUME; }
    public static int GetDefaultDifficulty() { return DEFAULT_DIFFICULTY; }
    public static float GetMasterVolume() { return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY); }
    public static int GetDifficulty() { return PlayerPrefs.GetInt(DIFFICULTY_KEY); }
}
