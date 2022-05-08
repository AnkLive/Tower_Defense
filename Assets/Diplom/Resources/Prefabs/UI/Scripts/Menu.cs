using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public AudioSource music;
    public SafePfers data;

    public void SetScreenVisibility(GameObject obj) => obj.SetActive(true);

    public void SetScreenInvisibility(GameObject obj) => obj.SetActive(false);

    private void Start() {
        SetSound();
    }

    public void SetSound() 
    {
        if(data.MUSIC == 1)
        {
            music.Play();
        }
        else
        {
            music.Pause();
        }
    }

    public void QuitGame() => Application.Quit();

    public void StartLevel(int value) => SceneManager.LoadScene(value);
}
