using UnityEngine;
using UnityEngine.UI;

public class ToggleAnimation : MonoBehaviour
{
    
    public Settings _settings;
    public Animator _anim;
    public Toggle _toggle;
    bool value = false;

    private void Start() 
    {
        _toggle.onValueChanged.AddListener(delegate 
        {
            ToggleValueChanged(_toggle);
        });
        if (_anim.gameObject.activeSelf) 
        {
            _anim.SetBool("toggle", _toggle.isOn);
        }
    }

    public void ToggleAnim() 
    {
        if(value) 
        {
            _settings.SaveData();
        }
        value = true;
        if (_anim.gameObject.activeSelf) 
        {
            _anim.SetBool("toggle", _toggle.isOn);
        }
    }

    public void SetToggleState() 
    {
        if (_anim.gameObject.activeSelf) 
        {
            _anim.SetBool("toggle", _toggle.isOn);
        }
    }

    public void ToggleValueChanged(Toggle change)
    {
        _settings.SaveData();
        if (_anim.gameObject.activeSelf) 
        {
            _anim.SetTrigger("anim");
        }
    }
}
