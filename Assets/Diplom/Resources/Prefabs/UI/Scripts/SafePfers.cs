using UnityEngine;

public class SafePfers : MonoBehaviour
{
    public int MUSIC, SOUND, TOTAL_SCORE, BEST_RESULT;

    public void SaveGame() 
    {
        PlayerPrefs.SetInt("music", MUSIC);
        PlayerPrefs.SetInt("sound", SOUND);
        PlayerPrefs.SetInt("total_score", TOTAL_SCORE);
        PlayerPrefs.SetInt("best_result", BEST_RESULT);
        PlayerPrefs.Save();
    }

    public void SaveSettings() 
    {
        PlayerPrefs.SetInt("music", MUSIC);
        PlayerPrefs.SetInt("sound", SOUND);
        PlayerPrefs.Save();
    }

    public void LoadGame() 
    {
        MUSIC = PlayerPrefs.GetInt("music");
        SOUND = PlayerPrefs.GetInt("sound");
        TOTAL_SCORE = PlayerPrefs.GetInt("total_score");
        BEST_RESULT = PlayerPrefs.GetInt("best_result");
    }
}
