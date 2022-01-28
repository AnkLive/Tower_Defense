using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjRotation
{
    [field: SerializeField, HideInInspector]
    public GameObject _obj;
    [field: SerializeField, HideInInspector]
    public GameObject _defaultObjRotation { get; set; }
    [field: SerializeField, HideInInspector]
    public bool _trackingX { get; set; }
    [field: SerializeField, HideInInspector]
    public bool _trackingY { get; set; }
    [field: SerializeField, HideInInspector]
    public bool _trackingZ { get; set; }
}

public class Tracking : MonoBehaviour
{
    [field: SerializeField, HideInInspector]
    public float _speedRotation { get; set; }
    [field: SerializeField, Header("������ ��������")]
    public List<ObjRotation> _objList = new List<ObjRotation>();
    [field: SerializeField, Header("������ �������")]
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

[CustomEditor(typeof(Tracking))]
[CanEditMultipleObjects]
public class TrackingCustomEditor : Editor
{

    public override void OnInspectorGUI()
    {
        Tracking tracking = (Tracking)target;
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("��������������", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        tracking._speedRotation = EditorGUILayout.FloatField("�������� ��������", tracking._speedRotation);

        EditorGUILayout.PropertyField(serializedObject.FindProperty("_objList"), new GUIContent("������ ��������� ��������"), true);
        /*tracking._isShields = EditorGUILayout.Toggle("����", tracking._isShields);

        if  (tracking._isShields) tracking._amountOfShields = EditorGUILayout.FloatField(" ", tracking._amountOfShields);
        else tracking._amountOfShields = 0; */

        if (GUI.changed)
        {
            EditorUtility.SetDirty(tracking);
            EditorSceneManager.MarkSceneDirty(tracking.gameObject.scene);
        }
    }
}
