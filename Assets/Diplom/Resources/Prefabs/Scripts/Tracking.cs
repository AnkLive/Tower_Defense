using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class objRotation
{
    [field: SerializeField, Header("Объект")]
    public GameObject _obj { get; private set; }
    [field: SerializeField, Header("Поворот по умолчанию")]
    public GameObject _defaultObjRotation { get; private set; }
    [field: SerializeField, Header("Поворот по оси Х")]
    public bool _TrackingX { get; private set; }
    [field: SerializeField, Header("Поворот по оси У")]
    public bool _TrackingY { get; private set; }
    [field: SerializeField, Header("Поворот по оси Z")]
    public bool _TrackingZ { get; private set; }
}

public class Tracking : MonoBehaviour
{
    [field: SerializeField, Header("Скорость поворота")]
    public float _speedRotation { get; private set; }
    [field: SerializeField, Header("Список объектов")]
    public List<objRotation> _objList { get; private set; } = new List<objRotation>();
    [field: SerializeField, Header("Таргет объекты")]
    public List<string> _objectTracking { get; private set; } = new List<string>();
    [field: SerializeField]
    public List<GameObject> _objTrackingID { get; private set; } = new List<GameObject>();
    private bool _isTracking = false;

    private void Update()
    {
        if (_objTrackingID.Count == 0)
        {
            _isTracking = false;
            DefaultRotation();
        }
        else
        {
            _isTracking = true;
        }
    }

    private void OnTriggerEnter(Collider collider) => AddListObj(collider);

    private void OnTriggerStay(Collider collider) => TagValidation(() => TrackingObj(), collider);

    private void OnTriggerExit(Collider collider) => RemoveListObj(collider);

    private void TagValidation(Action func, Collider collider)
    {
        if (_objectTracking.Count == 1) 
        {
            if (collider.gameObject.CompareTag(_objectTracking[0]))
            {
                func();
            }
        }
        else if (_objectTracking.Count >= 1)
        {
            foreach (var item in _objectTracking)
            {
                if (collider.gameObject.CompareTag(item))
                {
                    func();
                }
            }
        }
    }

    public void RemoveListObj(Collider collider)
    {
        _objTrackingID.Remove(collider.gameObject);
    }

    public void RemoveListObj()
    {
        _objTrackingID.Remove(_objTrackingID[0]);
    }

    private void AddListObj(Collider collider)
    {
        _objTrackingID.Add(collider.gameObject);
    }

    private void DefaultRotation()
    { 
        for (int i = 0; i < _objList.Count; i++)
        {
            _objList[i]._obj.transform.rotation = Quaternion.Lerp(_objList[i]._obj.transform.rotation,
                _objList[i]._defaultObjRotation.transform.rotation, Time.deltaTime * _speedRotation);
        }
    }

    private void TrackingObj()
    {
        if (_isTracking)
        {
            for (int i = 0; i < _objList.Count; i++)
            {
                Vector3 direction = (_objTrackingID[0].transform.position - _objList[i]._obj.transform.position).normalized;
                _objList[i]._obj.transform.rotation = Quaternion.Lerp(_objList[i]._obj.transform.rotation,
                    TrackingRotation(direction, _objList[i]), Time.deltaTime * _speedRotation);
            }
        }
    }

    private Quaternion TrackingRotation(Vector3 Direction, objRotation boolean)
    {
        if (boolean._TrackingX && !boolean._TrackingY && !boolean._TrackingZ)       
            return Quaternion.LookRotation(new Vector3(0f, Direction.y, Direction.z));
        else if (boolean._TrackingY && !boolean._TrackingX && !boolean._TrackingZ)  
            return Quaternion.LookRotation(new Vector3(Direction.x, 0f, Direction.z));
        else if (boolean._TrackingZ && !boolean._TrackingX && !boolean._TrackingY)  
            return Quaternion.LookRotation(new Vector3(Direction.x, Direction.y, 0f));
        else if (boolean._TrackingX && boolean._TrackingY && !boolean._TrackingZ)   
            return Quaternion.LookRotation(new Vector3(0f, 0f, Direction.z));
        else if (boolean._TrackingX && boolean._TrackingZ && !boolean._TrackingY)   
            return Quaternion.LookRotation(new Vector3(0f, Direction.y, 0f));
        else if (boolean._TrackingY && boolean._TrackingZ && !boolean._TrackingX)   
            return Quaternion.LookRotation(new Vector3(Direction.x, 0f, 0f));
        else if (boolean._TrackingX && boolean._TrackingY && boolean._TrackingZ)    
            return Quaternion.LookRotation(new Vector3(Direction.x, Direction.y, Direction.z));
        else                                                                        
            return Quaternion.LookRotation(new Vector3(0f, 0f, 0f));
    }
}
