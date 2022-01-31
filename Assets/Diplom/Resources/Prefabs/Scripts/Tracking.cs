using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjRotation
{
    public GameObject _obj;
    public GameObject _defaultObjRotation;
    public bool _trackingX;
    public bool _trackingY;
    public bool _trackingZ;
}

public class Tracking : MonoBehaviour
{
    [field: SerializeField, HideInInspector]
    public bool _isAdditionalSettings { get; set; } = false;
    [field: SerializeField, HideInInspector]
    public float _speedRotation { get; set; }
    [field: SerializeField, HideInInspector]
    private List<ObjRotation> _objList = new List<ObjRotation>();
    [field: SerializeField, HideInInspector]
    private List<string> _objectTrackingTag = new List<string>();
    [field: SerializeField, HideInInspector]
    public List<GameObject> _objTracking = new List<GameObject>();
    public bool _isTracking { get; private set; } = false;

    private void Update()
    {
        
        if (_objTracking.Count == 0)
        {
            _isTracking = false;
            DefaultRotation();
        }
        else
        {
            _isTracking = true;
        }
    }

    private void OnTriggerEnter(Collider collider) => AddTrackingListObj(collider);

    private void OnTriggerStay(Collider collider) => TagValidation(() => TrackingObj(), collider);

    private void OnTriggerExit(Collider collider) => RemoveTrackingListObj(collider);

    private void TagValidation(Action func, Collider collider)
    {

        if (_objectTrackingTag.Count == 1) 
        {

            if (collider.gameObject.CompareTag(_objectTrackingTag[0]))
            {
                func();
            }
        }
        else if (_objectTrackingTag.Count >= 1)
        {

            foreach (var item in _objectTrackingTag)
            {

                if (collider.gameObject.CompareTag(item))
                {
                    func();
                }
            }
        }
    }

    public void RemoveTrackingListObj(Collider collider) => _objTracking.Remove(collider.gameObject);

    public void RemoveTrackingListObj() => _objTracking.Remove(_objTracking[0]);

    private void AddTrackingListObj(Collider collider) => _objTracking.Add(collider.gameObject);

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
                Vector3 direction = (_objTracking[0].transform.position - _objList[i]._obj.transform.position).normalized;
                _objList[i]._obj.transform.rotation = Quaternion.Lerp(_objList[i]._obj.transform.rotation,
                    TrackingRotation(direction, _objList[i]), Time.deltaTime * _speedRotation);
            }
        }
    }

    private Quaternion TrackingRotation(Vector3 Direction, ObjRotation boolean)
    {
        if (boolean._trackingX && !boolean._trackingY && !boolean._trackingZ)       
            return Quaternion.LookRotation(new Vector3(0f, Direction.y, Direction.z));
        else if (boolean._trackingY && !boolean._trackingX && !boolean._trackingZ)  
            return Quaternion.LookRotation(new Vector3(Direction.x, 0f, Direction.z));
        else if (boolean._trackingZ && !boolean._trackingX && !boolean._trackingY)  
            return Quaternion.LookRotation(new Vector3(Direction.x, Direction.y, 0f));
        else if (boolean._trackingX && boolean._trackingY && !boolean._trackingZ)   
            return Quaternion.LookRotation(new Vector3(0f, 0f, Direction.z));
        else if (boolean._trackingX && boolean._trackingZ && !boolean._trackingY)   
            return Quaternion.LookRotation(new Vector3(0f, Direction.y, 0f));
        else if (boolean._trackingY && boolean._trackingZ && !boolean._trackingX)   
            return Quaternion.LookRotation(new Vector3(Direction.x, 0f, 0f));
        else if (boolean._trackingX && boolean._trackingY && boolean._trackingZ)    
            return Quaternion.LookRotation(new Vector3(Direction.x, Direction.y, Direction.z));
        else                                                                        
            return Quaternion.LookRotation(new Vector3(0f, 0f, 0f));
    }
}