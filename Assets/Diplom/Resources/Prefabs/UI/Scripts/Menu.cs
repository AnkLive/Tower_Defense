using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public AudioSource music;
    public SafePfers data;
    public bool _startDimming;
    [field: SerializeField] public Animator _dimming { get; set; }


    public void SetScreenVisibility(GameObject obj) => obj.SetActive(true);

    public void SetScreenInvisibility(GameObject obj) => obj.SetActive(false);

    private void Start() 
    {
        SetSound(data.MUSIC);
        if(_startDimming) 
        {
            SetDimming(false);
        }
    }

    public void SetDimming(bool value) 
    {
        _dimming.SetTrigger("anim");
        _dimming.SetBool("isDimming", value);
    }


    public void SetSound(Toggle toggle) 
    {
        if(toggle.isOn == true)
        {
            music.Play();
        }
        else
        {
            music.Pause();
        }
    }

    public void SetSound(int value) 
    {
        if(value == 1)
        {
            music.Play();
        }
        else
        {
            music.Pause();
        }
    }

    public void QuitGame() => Application.Quit();

    public void StartLevel(int value) => StartCoroutine(Wait(0.75f, value));

    public IEnumerator Wait(float seconds, int value)
    {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(value);
    }
}
