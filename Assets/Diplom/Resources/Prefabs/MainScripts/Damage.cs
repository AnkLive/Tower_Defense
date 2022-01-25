using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [field: SerializeField, Header("������ �� ������ ���� ������")]
    public GameObject _ref { get; set; }
    [field: SerializeField, Header("���������� ���������� �����")]
    public float _countDamage { get; set; }
    [field: SerializeField, Header("����� �����������")]
    private float _cooldown { get; set; }
    private float _timeStamp;
    public List<GameObject> _objList { get; set; } = new List<GameObject>();
    private void Start() => _timeStamp = _cooldown;

    private void Update() => IsDamage(gameObject.GetComponent<Tracking>()._objTrackingID);

    private void IsDamage(List<GameObject> objList)
    {
        _objList = objList;
        if (_timeStamp <= Time.time)
        {
            _objList[0].GetComponent<Health>().TakeDamage(_countDamage);
            _timeStamp = Time.time + _cooldown;
        }
        _ref.GetComponent<EnemyManager>().HealthCheck(gameObject);
    }
}

