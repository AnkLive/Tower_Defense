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

    void Update()
    {

        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            if (Input.GetMouseButtonDown(0))
            {

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("TowerSpawnPoint"))
                    {
                        ValueChanged();
                        getSpawnPointObj?.Invoke(hit.collider.gameObject.transform.Find("SpawnPoint").gameObject);
                        SetControllerValue(true);
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

    public void SetBoolValue(bool value) 
    {
        _controller.SetBool("isActive", value);
    }

    

    void ValueChanged()
    {
        _controller.SetTrigger("anim");
    }
}
