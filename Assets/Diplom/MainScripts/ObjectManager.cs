using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static event Action<GameObject> addHealthBar;
    public static event Action<GameObject> isRemoveObjAction;
    [field: SerializeField, HideInInspector]
    private List<GameObject> _allEnemiesList = new List<GameObject>();
    [field: SerializeField, HideInInspector]
    private List<GameObject> _allTowersList = new List<GameObject>();

    private void Awake() => Health.isDiedAction += HealthCheck;

    public void AddListObj(GameObject obj) => _allEnemiesList.Add(obj);

    private void DestroyObj(GameObject obj) => Destroy(obj.gameObject);

    public void HealthCheck(GameObject obj)
    {
        RemoveListObj();
        
        if (obj.GetComponent<Health>()._isDied)
        {
            isRemoveObjAction?.Invoke(obj);
            DestroyObj(obj);
            addHealthBar?.Invoke(obj);
        }
    }

    private void RemoveListObj() => _allEnemiesList = _allEnemiesList.Where(item => item != null).ToList();
}
