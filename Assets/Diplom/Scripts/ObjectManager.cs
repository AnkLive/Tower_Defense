using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static event Action<GameObject> isRemoveObjAction;
    public event Action<int> isDiedObjAction;
    [SerializeField, HideInInspector] public List<GameObject> _allEnemiesList = new List<GameObject>();
    [SerializeField, HideInInspector] public List<GameObject> _allTowersList = new List<GameObject>();
    public ParticleSystem _explosion; //��������� ����������

    private void Awake() => Health.isDiedAction += HealthCheck;

    public void AddListObj(List<GameObject> list, GameObject obj) => list.Add(obj);

    private void DestroyObj(GameObject obj) => Destroy(obj.gameObject);

    public void HealthCheck(GameObject obj)
    {
        
        if (obj.GetComponent<Health>()._isDied)
        {
            Debug.Log("!!!!!!");
            Vector3 pos = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
            var exp = Instantiate(_explosion, pos, Quaternion.identity);
            exp.Play();
            Destroy(exp.gameObject, 1f);
            isRemoveObjAction?.Invoke(obj);
            //isDiedObjAction?.Invoke(obj.GetComponent<EnemyHealth>()._rewardForDestruction);
            DestroyObj(obj);
        }
        CheckNullObjList();
    }

    private void CheckNullObjList() 
    {
        _allEnemiesList.RemoveAll(item => item == null);
        _allTowersList.RemoveAll(item => item == null);
    }
}
