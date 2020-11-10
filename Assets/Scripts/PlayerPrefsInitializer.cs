using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefsController.IsDifficultySet()) { PlayerPrefsController.SetDifficulty(); }
        if (!PlayerPrefsController.IsVolumeSet()) { PlayerPrefsController.SetMasterVolume(); }
    }

}
