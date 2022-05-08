using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static event Action<GameObject> isRemoveObjAction;
    public event Action<int, int> isDiedObjAction;
    public event Action isWinAction;
    [SerializeField, HideInInspector] public List<GameObject> _allEnemiesList = new List<GameObject>();
    [SerializeField, HideInInspector] public List<GameObject> _allTowersList = new List<GameObject>();
    public ParticleSystem _explosionEffect;
    public AudioSource _explosionSound;
    bool isLastWaveBool;

    private void Start() 
    {
        EnemySpawn.isLastWaveAction += isLastWave;
        Health.isDiedAction += HealthCheck;
    }

    public void AddListObj(List<GameObject> list, GameObject obj) => list.Add(obj);

    public void HealthCheck(GameObject obj)
    {
        if (obj.GetComponent<Health>()._isDied)
        {
            isRemoveObjAction?.Invoke(obj);
            isDiedObjAction?.Invoke(obj.GetComponent<EnemyHealth>()._rewardForDestruction, obj.GetComponent<EnemyHealth>()._scoreForDestruction);
            _allEnemiesList.Remove(obj);
            _allTowersList.Remove(obj);
            Destroy(obj);
            if (PlayerPrefs.GetInt("sound") == 1) 
            {
                _explosionSound.Play();
            }
            Vector3 pos = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
            var exp = Instantiate(_explosionEffect, pos, Quaternion.identity);
            exp.Play();
            Destroy(exp.gameObject, 3f);
        }
        if (isLastWaveBool) {
            if (_allEnemiesList.Count == 0) 
            {
                isWinAction?.Invoke();
                isLastWaveBool = false;
                EnemySpawn.isLastWaveAction -= isLastWave;
                Health.isDiedAction -= HealthCheck;
            }
        }
    }

    private void CheckNullObjList() 
    {
        _allEnemiesList.RemoveAll(item => item == null);
        _allTowersList.RemoveAll(item => item == null);
    }

    public void isLastWave(bool value) {
        isLastWaveBool = value;
        CheckNullObjList();
        if (_allEnemiesList.Count == 0) 
        {
            isWinAction?.Invoke();
            isLastWaveBool = false;
            EnemySpawn.isLastWaveAction -= isLastWave;
            Health.isDiedAction -= HealthCheck;
        }
        
    }
}
