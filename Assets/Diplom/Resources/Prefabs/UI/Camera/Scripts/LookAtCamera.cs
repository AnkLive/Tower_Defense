using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public List<GameObject> _healthBarList { get; private set; } = new List<GameObject>();

    void Start() => _healthBarList.AddRange(GameObject.FindGameObjectsWithTag("HealthBar"));

    void LateUpdate()
    {

        foreach (GameObject c in _healthBarList)
        {
            c.transform.LookAt(transform.position + c.transform.forward);
        }
    }
}
