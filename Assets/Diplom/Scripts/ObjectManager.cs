using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static event Action<GameObject> isRemoveObjAction;
    public event Action<int, int> isDiedObjAction;
    public event Action isWinAction;
    [SerializeField, HideInInspector] public List<GameObject> _allEnemiesList = new List<GameObject>();
    [SerializeField, HideInInspector] public List<GameObject> _allTowersList = new List<GameObject>();
    public ParticleSystem _explosion;
    bool isLastWaveBool;

    private void Awake() 
    {
        EnemySpawn.isLastWaveAction += isLastWave;
        Health.isDiedAction += HealthCheck;
    }

    public void AddListObj(List<GameObject> list, GameObject obj) => list.Add(obj);

    public void HealthCheck(GameObject obj)
    {
        
        if (obj.GetComponent<Health>()._isDied)
        {
            Destroy(obj);
            Vector3 pos = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
            var exp = Instantiate(_explosion, pos, Quaternion.identity);
            exp.Play();
            Destroy(exp.gameObject, 3f);
            isRemoveObjAction?.Invoke(obj);
            isDiedObjAction?.Invoke(obj.GetComponent<EnemyHealth>()._rewardForDestruction, obj.GetComponent<EnemyHealth>()._scoreForDestruction);
            
        }
        CheckNullObjList();
    }

    private void CheckNullObjList() 
    {
        _allEnemiesList.RemoveAll(item => item == null);
        _allTowersList.RemoveAll(item => item == null);
        if (isLastWaveBool) {
            if (_allEnemiesList.Count == 0) 
            {
                isWinAction?.Invoke();
            }
        }
    }

    public void isLastWave(bool value) {
         CheckNullObjList();
        if (!_allEnemiesList.Any()) 
        {
            isWinAction?.Invoke();
        }
        
    }
}
