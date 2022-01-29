using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [field: SerializeField, HideInInspector]
    public GameObject _ref { get; set; }
    [field: SerializeField, HideInInspector]
    public float _countDamage { get; set; }
    [field: SerializeField, HideInInspector]
    public float _cooldown { get; set; }
    public float _timeStamp { get; private set; }
    public List<GameObject> _objList { get; set; } = new List<GameObject>();
    private void Start() => _timeStamp = _cooldown;

    private void Update() => IsDamage(gameObject.GetComponent<Tracking>()._objTracking);

    private void IsDamage(List<GameObject> objList)
    {
        _objList = objList;

        if (_timeStamp <= Time.time)
        {
            _objList[0].GetComponent<Health>().TakeDamage(_countDamage);
            _ref.GetComponent<EnemyManager>().HealthCheck(gameObject);
            _timeStamp = Time.time + _cooldown;
        }
    }
}
