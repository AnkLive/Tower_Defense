using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public static event Action<GameObject> addHealthBar;
    [SerializeField] public ObjectManager _objectManager { get; set; }
    [SerializeField] public GameObject _spawn { get; set; }
    [SerializeField] public WaveManager _waveManager { get; set; }
    private List<Wave> _waveList = new List<Wave>();
    private float _timeStamp;
    private int _numberOWave = 0;
    private bool _startNextWave = true;

    private void Awake() => _waveList = _waveManager._wavesList;

    private void Update()
    {

        if (_numberOWave < _waveList.Count)
        {
            TimeBetweenWaves();
        }
    }

    private void StartCoroutine() => StartCoroutine(SpawnEnemy(_waveList[_numberOWave]._timeBetweenEnemy));

    private void TimeBetweenWaves()
    {

        if (_timeStamp <= Time.time && _startNextWave)
        {
            StartCoroutine();
            _startNextWave = false;
            _timeStamp = Time.time + _waveManager._timeBetweenWaves;
        }
    }

    IEnumerator SpawnEnemy(float seconds)
    {
        int _numberOfEnemy = 0;

        while (_numberOfEnemy <  _waveList[_numberOWave]._enemyCount)
        {
            GameObject obj = Instantiate(Resources.Load<GameObject>(_waveList[_numberOWave]._enemyName.ToString()));
            //_objectManager?.AddListObj(_objectManager._allEnemiesList, obj);
            addHealthBar?.Invoke(obj.transform.Find("HealthBar").gameObject);
            obj.transform.position = new Vector3(
                _spawn.transform.position.x,
                _spawn.transform.position.y + 1f,
                _spawn.transform.position.z
            );
            _numberOfEnemy++;
            yield return new WaitForSeconds(seconds);
        }
        _numberOWave++;
        _startNextWave = true;
    }
}
