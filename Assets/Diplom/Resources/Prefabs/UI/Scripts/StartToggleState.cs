using UnityEngine;
using UnityEngine.UI;

public class StartToggleState : MonoBehaviour
{

    public Settings _settings;
    public Toggle _toggle;
    private void Start() 
    {
        StartPosition();
    }

public void StartPosition()
    {
        if (_toggle.isOn) 
        {
            gameObject.transform.localPosition = new Vector2(18f, 0f);
        }
        else 
        {
            gameObject.transform.localPosition = new Vector2(-18f, 0f);
        }
    }
}
