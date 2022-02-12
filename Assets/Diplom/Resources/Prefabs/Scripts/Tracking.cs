using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjRotation
{
    public GameObject obj;
    public GameObject defaultObjRotation;
    public bool trackingX;
    public bool trackingY;
    public bool trackingZ;
}

public class Tracking : MonoBehaviour
{
    public event Action<GameObject> isDamageAction;
    [field: SerializeField, HideInInspector] public float _speedRotation { get; set; }
    [field: SerializeField, HideInInspector] public string _objectTrackingTag { get; set; }
    [field: SerializeField, HideInInspector] public List<ObjRotation> _objList = new List<ObjRotation>();
    [field: SerializeField, HideInInspector] public List<GameObject> _objTracking = new List<GameObject>();
    private bool _isTracking = false;

    private void Awake() => ObjectManager.isRemoveObjAction += RemoveTrackingListObj;

    private void OnDisable() => ObjectManager.isRemoveObjAction -= RemoveTrackingListObj;

    private void Update()
    {

        if (_objTracking.Count == 0)
        {
            _isTracking = false;
            DefaultRotation();
        }
        else if (_objTracking.Count > 0 && _objTracking[0] == null) 
        {
            CheckNullObjToList();
        }
        else
        {
            _isTracking = true;
        }
    }

    private void OnTriggerEnter(Collider collider) => AddTrackingListObj(collider.gameObject);

    private void OnTriggerStay(Collider collider) => CheckTagObj(collider.gameObject);

    private void OnTriggerExit(Collider collider) => RemoveTrackingListObj();

    private void CheckTagObj(GameObject obj)
    {
        
        if (obj.CompareTag(_objectTrackingTag))
        {
            TrackingObj();
        }
    }

    public void RemoveTrackingListObj() => _objTracking.Remove(_objTracking[0]);

    public void RemoveTrackingListObj(GameObject obj) => _objTracking.Remove(obj);

    private void CheckNullObjToList() => _objTracking.RemoveAll(item => item == null);

    private void AddTrackingListObj(GameObject obj) => _objTracking.Add(obj);

    private void DefaultRotation()
    {
        
        for (int i = 0; i < _objList.Count; i++)
        {
            _objList[i].obj.transform.rotation = Quaternion.Lerp(_objList[i].obj.transform.rotation,
                _objList[i].defaultObjRotation.transform.rotation, Time.deltaTime * _speedRotation);
        }
    }

    private void TrackingObj()
    {
        

        if (_objTracking.Count > 0 && _isTracking) 
        {
            isDamageAction?.Invoke(_objTracking[0]);
            
            for (int i = 0; i < _objList.Count; i++)
            {
                Vector3 direction = (_objTracking[0].transform.position - _objList[i].obj.transform.position).normalized;
                _objList[i].obj.transform.rotation = Quaternion.Lerp(_objList[i].obj.transform.rotation,
                    TrackingRotation(direction, _objList[i]), Time.deltaTime * _speedRotation);
            }  
        }
    }

    private Quaternion TrackingRotation(Vector3 Direction, ObjRotation boolean)
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
}