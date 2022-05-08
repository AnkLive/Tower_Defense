using UnityEngine;
using UnityEngine.UI;

public class PauseIconChange : MonoBehaviour
{
    public GameObject pause, play;
    public GameManager isPause;

    public void ChangeSprite() 
    {
        if (isPause._isPause) {
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
