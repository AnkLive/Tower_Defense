using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tracking : MonoBehaviour, IEventSubscription
{
    public event Action<GameObject> isDamageAction;
    public event Action<bool> isTrackingAction;
    public abstract float _speedRotation { get; set; }
    public abstract string _objectTrackingTag { get; set; }
    public abstract List<ObjRotation> _objList { get; set; }
    public abstract List<GameObject> _objTracking { get; set; }
    public bool _isTracking = false;

    public void ListInitialization() 
    {
        _objList = new List<ObjRotation>();
        _objTracking = new List<GameObject>();
    }

    public void checkListTracking() 
    {
        isTrackingAction?.Invoke(_isTracking);
        if (_objTracking.Count == 0)
        {
            _isTracking = false;
            DefaultRotation();
        }
        else if (_objTracking.Count > 0 && _objTracking[0] == null) 
        {
            CheckNullObjToList();
        }
        else if (_objTracking.Count > 0 && _objTracking[0] != null)
        {
            _isTracking = true;
        }
    }

    public void CheckTagObj(GameObject obj)
    {
        
        if (obj.CompareTag(_objectTrackingTag))
        {
            TrackingObj();
        }
    }

    public void RemoveTrackingListObj() => _objTracking.Remove(_objTracking[0]);

    public void RemoveTrackingListObj(GameObject obj) => _objTracking.Remove(obj);

    public void CheckNullObjToList() => _objTracking.RemoveAll(item => item == null);

    public void AddTrackingListObj(GameObject obj) => _objTracking.Add(obj);

    public void DefaultRotation()
    {
        
        for (int i = 0; i < _objList.Count; i++)
        {
            _objList[i].obj.transform.rotation = Quaternion.Lerp(_objList[i].obj.transform.rotation,
                _objList[i].defaultObjRotation.transform.rotation, Time.deltaTime * _speedRotation);
        }
    }

    public void TrackingObj()
    {
        
        if (_objTracking.Count > 0 && _isTracking) 
        {
            isDamageAction?.Invoke(_objTracking[0]);
            
            for (int i = 0; i < _objList.Count; i++)
            {
                if (_objTracking.Count > 0 && _objTracking[0] != null) {
                Vector3 direction = (_objTracking[0].transform.position - _objList[i].obj.transform.position).normalized;
                _objList[i].obj.transform.rotation = Quaternion.Lerp(_objList[i].obj.transform.rotation,
                    TrackingRotation(direction, _objList[i]), Time.deltaTime * _speedRotation);
                }
            }  
        }
    }

    public Quaternion TrackingRotation(Vector3 Direction, ObjRotation boolean)
    {
        if (boolean.trackingX && !boolean.trackingY && !boolean.trackingZ)       
            return Quaternion.LookRotation(new Vector3(0f, Direction.y, Direction.z));
        else if (boolean.trackingY && !boolean.trackingX && !boolean.trackingZ)  
            return Quaternion.LookRotation(new Vector3(Direction.x, 0f, Direction.z));
        else if (boolean.trackingZ && !boolean.trackingX && !boolean.trackingY)  
            return Quaternion.LookRotation(new Vector3(Direction.x, Direction.y, 0f));
        else if (boolean.trackingX && boolean.trackingY && !boolean.trackingZ)   
            return Quaternion.LookRotation(new Vector3(0f, 0f, Direction.z));
        else if (boolean.trackingX && boolean.trackingZ && !boolean.trackingY)   
            return Quaternion.LookRotation(new Vector3(0f, Direction.y, 0f));
        else if (boolean.trackingY && boolean.trackingZ && !boolean.trackingX)   
            return Quaternion.LookRotation(new Vector3(Direction.x, 0f, 0f));
        else if (boolean.trackingX && boolean.trackingY && boolean.trackingZ)    
            return Quaternion.LookRotation(new Vector3(Direction.x, Direction.y, Direction.z));
        else                                                                        
            return Quaternion.LookRotation(new Vector3(0f, 0f, 0f));
    }

    public virtual void Subscribe() => ObjectManager.isRemoveObjAction += RemoveTrackingListObj;

    public virtual void Unsubscribe() => ObjectManager.isRemoveObjAction -= RemoveTrackingListObj;
}