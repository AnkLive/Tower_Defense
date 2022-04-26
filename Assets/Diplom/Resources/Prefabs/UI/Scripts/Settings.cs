using System;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public event Action settingsIsLoadedEvent;
    public SafePfers savePfers;
    public Toggle music, sound;
    void Awake()
    {
        savePfers.LoadGame();
        music.isOn = LoadDataValue(savePfers.MUSIC);
        sound.isOn = LoadDataValue(savePfers.SOUND);
    }

    void Start()
    {
        savePfers.LoadGame();
        music.isOn = LoadDataValue(savePfers.MUSIC);
        sound.isOn = LoadDataValue(savePfers.SOUND);
        settingsIsLoadedEvent?.Invoke();
    }

    public void SaveData() {
        savePfers.MUSIC = SaveDataValue(music.isOn);
        savePfers.SOUND = SaveDataValue(sound.isOn);
        savePfers.SaveGame();
    }

    private bool LoadDataValue(int value) => value == 1 ? true : false;

    private int SaveDataValue(bool value) => value == true ? 1 : 0;
}
