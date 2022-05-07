using UnityEngine;

public class SafePfers : MonoBehaviour
{
    public int LEVEL_1, LEVEL_2, LEVEL_3, MUSIC, SOUND, TOTAL_SCORE, BEST_RESULT;

    public void SaveGame() 
    {
        PlayerPrefs.SetInt("level_1", LEVEL_1);
        PlayerPrefs.SetInt("level_2", LEVEL_2);
        PlayerPrefs.SetInt("level_3", LEVEL_3);
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
        LEVEL_1 = PlayerPrefs.GetInt("level_1");
        LEVEL_2 = PlayerPrefs.GetInt("level_2");
        LEVEL_3 = PlayerPrefs.GetInt("level_3");
        MUSIC = PlayerPrefs.GetInt("music");
        SOUND = PlayerPrefs.GetInt("sound");
        TOTAL_SCORE = PlayerPrefs.GetInt("total_score");
        BEST_RESULT = PlayerPrefs.GetInt("best_result");
    }
}
