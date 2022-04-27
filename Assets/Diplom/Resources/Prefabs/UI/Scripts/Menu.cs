using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    AudioSource music, sound;

    public void SetScreenVisibility(GameObject obj) => obj.SetActive(true);

    public void SetScreenInvisibility(GameObject obj) => obj.SetActive(false);

    public void SetSound(bool value, AudioSource sound) 
    {
        if(value)
        {
            sound.Play();
        }
        else
        {
            sound.Pause();
        }
    }

    public void QuitGame() => Application.Quit();

    public void StartLevel(int value) => SceneManager.LoadScene(value);
}
