using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public delegate void isRemoveObjDelegate(GameObject obj);
    public static isRemoveObjDelegate isRemoveObjAction;
    [field: SerializeField, HideInInspector]
    private List<GameObject> _allEnemyList = new List<GameObject>();

    private void Awake() => Health.isDiedAction += HealthCheck;

    public void AddListObj(GameObject obj) => _allEnemyList.Add(obj);

    private void DestroyObj(GameObject obj) => Destroy(obj.gameObject);

    public void HealthCheck(GameObject obj)
    {
        RemoveListObj();
        if (obj.GetComponent<Health>()._isDied)
        {
            isRemoveObjAction?.Invoke(obj);
            DestroyObj(obj);
        }
    }

    private void RemoveListObj() => _allEnemyList = _allEnemyList.Where(item => item != null).ToList();
}
