using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public List<GameObject> _healthBarList { get; set; } = new List<GameObject>();

    private void Awake() => ObjectManager.addHealthBar += AddObj;

    private void LateUpdate()
    {
        foreach (GameObject c in _healthBarList) c.transform.LookAt(transform.position + c.transform.forward);
    }

    public void AddObj(GameObject obj) => _healthBarList.Add(obj);
}
