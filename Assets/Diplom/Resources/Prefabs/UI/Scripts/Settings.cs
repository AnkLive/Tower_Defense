using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public SafePfers savePfers;
    public Toggle music, sound;
    void Awake()
    {
        savePfers.LoadGame();
        music.isOn = LoadData(savePfers.MUSIC);
        sound.isOn = LoadData(savePfers.SOUND);
    }

    void Start()
    {
        savePfers.LoadGame();
        music.isOn = LoadData(savePfers.MUSIC);
        sound.isOn = LoadData(savePfers.SOUND);
    }

    private bool LoadData(int value) => value == 1 ? true : false;
}
