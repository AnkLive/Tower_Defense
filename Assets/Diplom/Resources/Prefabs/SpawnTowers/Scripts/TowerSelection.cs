using UnityEngine;

public class TowerSelection : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;
    [SerializeField]
    private Camera Camera;
    [SerializeField]
    private Animator controller;
    void Update()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            ray = Camera.ScreenPointToRay(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("TowerSpawn"))
                    {
                        controller.SetBool("isActive", true);
                    } 
                    else
                    {
                        CloseMenuSelectionTowers();
                    }
                }
            }
        }
    }

    //some text
    public void CloseMenuSelectionTowers()
    {
        controller.SetBool("isActive", false);
    }
}
