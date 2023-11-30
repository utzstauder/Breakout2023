using System;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private const string MainVolumeKey = "mainVolume";

    [SerializeField]
    private float volume = 0.5f;

    private void Awake()
    {
        volume = GetVolumeFromSettings();
    }

    private void OnApplicationQuit()
    {
        SaveVolumeToSettings(volume);
    }

    void SaveVolumeToSettings(float value)
    {
        PlayerPrefs.SetFloat(MainVolumeKey, value);
    }
    
    float GetVolumeFromSettings()
    {
        return PlayerPrefs.GetFloat(MainVolumeKey, 0.5f);
    }
}