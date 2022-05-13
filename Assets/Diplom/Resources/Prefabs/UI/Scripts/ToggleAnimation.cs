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
        _anim.SetBool("toggle", _toggle.isOn);
    }

    public void ToggleAnim() 
    {
        if(value) 
        {
            _settings.SaveData();
        }
        value = true;
        _anim.SetBool("toggle", _toggle.isOn);
    }

    public void SetToggleState() 
    {
        _anim.SetBool("toggle", _toggle.isOn);
    }

    public void ToggleValueChanged(Toggle change)
    {
        _settings.SaveData();
        _anim.SetTrigger("anim");
    }
}
