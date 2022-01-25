using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBarLookCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject lookCamera;
    public List<GameObject> healthBarList = new List<GameObject>();
    void Start()
    {
        healthBarList.AddRange(GameObject.FindGameObjectsWithTag("HealthBar"));
    }
    void LateUpdate()
    {
        foreach (GameObject c in healthBarList)
        {
            c.transform.LookAt(transform.position + c.transform.forward);
        }
    }
}
