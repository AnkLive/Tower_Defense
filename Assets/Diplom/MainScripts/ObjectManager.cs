using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static event Action<GameObject> isRemoveObjAction;
    [field: SerializeField, HideInInspector]
    private List<GameObject> _allEnemiesList = new List<GameObject>();
    [field: SerializeField, HideInInspector]
    private List<GameObject> _allTowersList = new List<GameObject>();
    public ParticleSystem _explosion;

    private void Awake() => Health.isDiedAction += HealthCheck;

    public void AddListObj(GameObject obj) => _allEnemiesList.Add(obj);

    private void DestroyObj(GameObject obj) => Destroy(obj.gameObject);

    public void HealthCheck(GameObject obj)
    {
        RemoveListObj();
        
        if (obj.GetComponent<Health>()._isDied)
        {
            Vector3 pos = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
            var exp = Instantiate(_explosion, pos, Quaternion.identity);
            exp.Play();
            Destroy(exp, 1f);
            isRemoveObjAction?.Invoke(obj);
            DestroyObj(obj);
        }
    }

    private void RemoveListObj() => _allEnemiesList = _allEnemiesList.Where(item => item != null).ToList();
}