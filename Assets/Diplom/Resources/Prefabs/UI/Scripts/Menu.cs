using UnityEngine;

public class MainMenu : MonoBehaviour
{
    AudioSource music, sound;
    private void SetScreenVisibility(GameObject obj1, GameObject obj2) {
        obj1.SetActive(true);
        obj1.SetActive(false);
    }

    private void SetSound(bool value, ref AudioSource sound) {
        if(value)
        {
            sound.Play();
        }
        else
        {
            sound.Pause();
        }
    }

    private void QuitGame() => Application.Quit();
}
