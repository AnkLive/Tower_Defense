using System;
using UnityEditor;
using UnityEditor.SceneManagement;
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
    public float _speedRotation { get; set; }
    [field: SerializeField, HideInInspector]
    private List<ObjRotation> _objList = new List<ObjRotation>();
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

[CustomEditor(typeof(Tracking)), CanEditMultipleObjects]
public class TrackingCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Tracking tracking = (Tracking)target;
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("Характеристики", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        tracking._speedRotation = EditorGUILayout.FloatField("Скорость поворота", tracking._speedRotation);


        EditorGUILayout.PropertyField(serializedObject.FindProperty("_objList"), new GUIContent("Список доступных объектов"), true);
        /*tracking._isShields = EditorGUILayout.Toggle("Щиты", tracking._isShields);

        if  (tracking._isShields) tracking._amountOfShields = EditorGUILayout.FloatField(" ", tracking._amountOfShields);
        else tracking._amountOfShields = 0; */

        if (GUI.changed)
        {
            EditorUtility.SetDirty(tracking);
            EditorSceneManager.MarkSceneDirty(tracking.gameObject.scene);
        }
    }
}

[CustomPropertyDrawer(typeof(ObjRotation)), CanEditMultipleObjects]
public class ObjRotationCustomEditor : PropertyDrawer
{
    
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        Rect labelPosition = new Rect(position.xMin, position.y, position.width, position.height);
        position = EditorGUI.PrefixLabel(labelPosition,  GUIUtility.GetControlID(FocusType.Passive), label);

        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        var objLabelRect = new Rect(labelPosition.x, position.y - 30f, position.width, position.height);
        var defaultObjRotationLabelRect = new Rect(labelPosition.x, position.y - 10f, position.width, position.height);
        var trackingXLabelRect = new Rect(labelPosition.x, position.y + 10f, position.width, position.height);
        var trackingYLabelRect = new Rect(labelPosition.x, position.y + 30f, position.width, position.height);
        var trackingZLabelRect = new Rect(labelPosition.x, position.y + 50f, position.width, position.height);
        
        var objRect = new Rect(position.x, position.y + 20f, position.width, position.height);
        var defaultObjRotationRect = new Rect(position.x, position.y + 40f, position.width, position.height);
        var trackingXRect = new Rect(position.x, position.y + 60f, position.width, position.height);
        var trackingYRect = new Rect(position.x, position.y + 80f, position.width, position.height);
        var trackingZRect = new Rect(position.x, position.y + 100f, position.width, position.height);

        EditorGUI.LabelField(objLabelRect, "Объект");
        EditorGUI.PropertyField(objRect, property.FindPropertyRelative("_obj"), GUIContent.none, true);
        EditorGUI.LabelField(defaultObjRotationLabelRect, "Угол поворота по умолчанию");
        EditorGUI.PropertyField(defaultObjRotationRect, property.FindPropertyRelative("_defaultObjRotation"), GUIContent.none, true);
        EditorGUI.LabelField(trackingXLabelRect, "Поворот по оси X");
        EditorGUI.PropertyField(trackingXRect, property.FindPropertyRelative("_trackingX"), GUIContent.none, true);
        EditorGUI.LabelField(trackingYLabelRect, "Поворот по оси Y");
        EditorGUI.PropertyField(trackingYRect, property.FindPropertyRelative("_trackingY"), GUIContent.none, true);
        EditorGUI.LabelField(trackingZLabelRect, "Поворот по оси Z");
        EditorGUI.PropertyField(trackingZRect, property.FindPropertyRelative("_trackingZ"), GUIContent.none, true);

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
        property.serializedObject.ApplyModifiedProperties();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + 100f;
    }
}
