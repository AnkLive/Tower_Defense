using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [field: SerializeField]
    public List<GameObject> _healthBarList { get; set; } = new List<GameObject>();

    private void Start() 
    {
        TowerSpawn.addHealthBarTowers += AddListObj;
        EnemySpawn.addHealthBar += AddListObj;
    }

    private void LateUpdate()
    {
        RemoveListObj();

        foreach (GameObject obj in _healthBarList) 
        {

            if (obj != null) 
            {
                obj.transform.LookAt(transform.position + obj.transform.forward);
            }
        }
    }

    public void RemoveListObj() => _healthBarList = _healthBarList.Where(item => item != null).ToList();

    public void AddListObj(GameObject obj) => _healthBarList.Add(obj);
    private void OnDisable() 
    {
        TowerSpawn.addHealthBarTowers -= AddListObj;
        EnemySpawn.addHealthBar -= AddListObj;
    }
}
