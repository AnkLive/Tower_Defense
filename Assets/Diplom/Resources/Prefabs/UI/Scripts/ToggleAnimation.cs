using System;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAnimation : MonoBehaviour
{
    
    public Settings _settings;
    public Animator _anim;
    public Toggle _toggle;

    private void Start() {
        _anim.SetBool("toggle", _toggle.isOn);
        _toggle.onValueChanged.AddListener(delegate {
                ToggleValueChanged(_toggle);
            });
    }

    public void ToggleAnim() 
    {
        _settings.SaveData();
        _anim.SetBool("toggle", _toggle.isOn);
    }

    void ToggleValueChanged(Toggle change)
    {
        _settings.SaveData();
        _anim.SetTrigger("anim");
    }
}
