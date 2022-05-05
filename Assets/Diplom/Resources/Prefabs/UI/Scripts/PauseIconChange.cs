using UnityEngine;
using UnityEngine.UI;

public class PauseIconChange : MonoBehaviour
{
    public GameObject pause, play;
    Image image;
    Toggle toggle;

    private void Start() 
    { 
        image = gameObject.GetComponent<Image>();
        toggle = gameObject.GetComponent<Toggle>();
    }

    public void ChangeSprite() 
    {
        if (toggle.isOn == true) {
            pause.SetActive(false);
            play.SetActive(true);
        }
        else 
        {
            pause.SetActive(true);
            play.SetActive(false);
        }
    }
}
