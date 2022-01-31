using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [field: SerializeField, HideInInspector]

    private List<GameObject> _allEnemyList = new List<GameObject>();

    public void AddListObj(GameObject obj) => _allEnemyList.Add(obj);

    private void DestroyObj(GameObject obj) => Destroy(obj.gameObject);

    public void HealthCheck(GameObject obj)
    {
        RemoveListObj();

        foreach (var item in _allEnemyList)
        {

            if (item.GetComponent<Health>()._isDied)
            {
                obj.GetComponent<Tracking>().RemoveTrackingListObj();
                DestroyObj(item);
            }
        }
    }

    private void RemoveListObj() => _allEnemyList = _allEnemyList.Where(item => item != null).ToList();
}
