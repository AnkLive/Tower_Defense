using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [field: SerializeField, HideInInspector]
    public GameObject _spawn { get; set; }
    [field: SerializeField, HideInInspector]
    public WaveManager _waveManager { get; set; }
    private List<string> _enemyListName = new List<string>();
    private List<int> _enemyListCount = new List<int>();
    private List<float> _enemyListTimeBetween = new List<float>();
    private float _timeStamp;
    private int _numberOWave = 0;
    private bool _startNextWave = true;

    private void Awake()
    {
        
        for (int i = 0; i < _waveManager._wavesList.Count; i++)
        {
            _enemyListName.Add(_waveManager._wavesList[i]._enemyName.ToString());
            _enemyListCount.Add(_waveManager._wavesList[i]._enemyCount);
            _enemyListTimeBetween.Add(_waveManager._wavesList[i]._timeBetweenEnemy);
        }
    }

    private void Update()
    {

        if (_numberOWave < _enemyListCount.Count)
        {
            TimeBetweenWaves();
        }
    }

    private void StartCoroutine() => StartCoroutine(SpawnEnemy(_enemyListTimeBetween[_numberOWave]));

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

        while (_numberOfEnemy < _enemyListCount[_numberOWave])
        {
            GameObject obj = Instantiate(Resources.Load<GameObject>(_enemyListName[_numberOWave]));
            gameObject.GetComponent<ObjectManager>().AddListObj(obj);
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
