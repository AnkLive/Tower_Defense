using System;
using UnityEngine;

public class TowerSelection : MonoBehaviour
{
    public GameManager gameManager;
    public event Action<GameObject> getSpawnPointObj;
    private RaycastHit hit;
    private Ray ray;
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private Animator _controller;

    PauseIconChange change;

    public bool isPauseButtonSelected;

    private void Start() 
    {
        change = gameObject.GetComponent<PauseIconChange>();
    }

    void Update()
    {
        for (var i = 0; i < Input.touchCount; ++i) 
        {
             if (Input.GetTouch(i).phase == TouchPhase.Began) 
             {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.collider.tag);
                    if (!gameManager._isPause || isPauseButtonSelected) {
                        if (hit.collider.CompareTag("TowerSpawnPoint"))
                        {
                            ValueChanged();
                            getSpawnPointObj?.Invoke(hit.collider.gameObject.transform.Find("SpawnPoint").gameObject);
                            SetControllerValue(true);
                            change.ChangeSprite();
                        }
                    }
                }
            }
        }
    }

    public void SetControllerValue(bool value) 
    {
        gameManager.StopGame(value);
        _controller.SetBool("isActive", value);
    }

    public void SetBoolValue() 
    {
        _controller.SetBool("isActive", false);
    }

    public void SetPauseButtonValue(bool value) {
        isPauseButtonSelected = value;
    }

    void ValueChanged()
    {
        _controller.SetTrigger("anim");
    }
}
