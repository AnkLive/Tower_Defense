using UnityEngine;
using UnityEngine.UI;

public class ToggleAnimation : MonoBehaviour
{
    public Animator _anim;
    public Toggle _toggle;

    private void Start() => _toggle = gameObject.GetComponent<Toggle>();

    public void ToggleAnim() 
    {
        _anim.SetBool("toggle", _toggle.isOn);
    }
}
