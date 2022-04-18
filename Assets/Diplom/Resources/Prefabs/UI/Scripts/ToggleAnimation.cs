using UnityEngine;
using UnityEngine.UI;

public class ToggleAnimation : MonoBehaviour
{
    public Settings _settings;
    public Transform _checkmark;
    public Animator _anim;
    public Toggle _toggle;

    private void Start() 
    {
        _settings.settingsIsLoadedEvent += StartPosition;
    }

    public void ToggleAnim() 
    {
        _settings.SaveData();
        _anim.SetBool("toggle", _toggle.isOn);
    }

    public void StartPosition()
    {
        Debug.Log(_toggle.isOn);
        if (_toggle.isOn) 
        {
            _checkmark.transform.position = _checkmark.transform.position + new Vector3(18f, 0f, 0f);
        }
        else 
        {
            _checkmark.transform.position = _checkmark.transform.position + new Vector3(-18f, 0f, 0f);
        }
    }
}
