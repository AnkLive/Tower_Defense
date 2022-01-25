using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public enum ESide
{
    Left,
    Right,
    Top,
    Bottom,
}

[Serializable]
public class ObjReferenceList
{
    public ObjReferenceList(GameObject ObjReference, string ObjName)
    {
        objReference = ObjReference;
        objName = ObjName;
    }
    public GameObject objReference;
    public string objName;
}

public class RoadBuilder : MonoBehaviour
{
    public int _indexCurrentObj { get; set; }
    public GameObject _objReferenceEditor { get; set; }
    public string _objNameEditor { get; set; }
    public GameObject _currentObj { get; set; }
    [field: SerializeField, HideInInspector]
    private List<ObjReferenceList> _objReferenceList = new List<ObjReferenceList>();
    [field: SerializeField, HideInInspector]
    private List<GameObject> _objList = new List<GameObject>();
    [SerializeField, HideInInspector]
    public List<string> _NameObjReferenceList { get; set; } = new List<string>();
    public ESide _eSide { get; set; }
    public bool _isFirstObj { get; set; } = true;
    public float _distanceBetweenObj { get; set; }

    public void AddNewObjToListReference(GameObject objReference, string objName)
    {
        _objReferenceList.Add(
            new ObjReferenceList(
                objReference,
                objName
            ));
    }

    public GameObject SetCurrentObj() => _objReferenceList[_indexCurrentObj].objReference;

    public void CheckListName()
    {
        _NameObjReferenceList.Clear();
        for (int i = 0; i < _objReferenceList.Count; i++)
        {
            _NameObjReferenceList.Insert(i, _objReferenceList[i].objName);
        }
    }

    public void Spawn()
    {
        _currentObj = SetCurrentObj();
        if (_isFirstObj) SpawnFirstObj();
        else SpawnNextObj();
    }

    public void DestroyLastObj()
    {
        _objList.RemoveAt(_objList.Count - 1);
        DestroyImmediate(transform.GetChild(transform.childCount - 1).gameObject);
        if (_objList.Count == 0) _isFirstObj = true;
    }

    public void DestroyAllObj()
    {
        foreach (GameObject item in _objList)
        {
            DestroyImmediate(item);
        }
        _objList.Clear();
        _isFirstObj = true;
    }

    private Vector3 SideObj(GameObject obj, string side) => side switch
    {
        "Left" => new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z + _distanceBetweenObj),
        "Right" => new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z - _distanceBetweenObj),
        "Top" => new Vector3(obj.transform.position.x + _distanceBetweenObj, obj.transform.position.y, obj.transform.position.z),
        "Bottom" => new Vector3(obj.transform.position.x - _distanceBetweenObj, obj.transform.position.y, obj.transform.position.z),
        _ => new Vector3(0f, 0f, 0f),
    };

    private void SpawnNextObj()
    {
        _objList.Add(Instantiate(_currentObj));
        _objList[_objList.Count - 1].tag = "Platform";
        _objList[_objList.Count - 1].transform.SetParent(gameObject.transform, false);
        _objList[_objList.Count - 1].transform.position = SideObj(_objList[_objList.Count - 2], _eSide.ToString());
    }

    private void SpawnFirstObj()
    {
        _isFirstObj = false;
        _objList.Add(Instantiate(_currentObj));
        _objList[0].tag = "Platform";
        _objList[0].transform.SetParent(gameObject.transform, false);
        _objList[0].transform.position = gameObject.transform.position;
    }
}

[CustomEditor(typeof(RoadBuilder))]
[CanEditMultipleObjects]
public class MyCustomEditor : Editor
{
    private bool _isCreated = false;
    private bool _isAdd = false;
    private bool _isEditListObj = true;

    public override void OnInspectorGUI()
    {
        RoadBuilder builder = (RoadBuilder)target;
        base.OnInspectorGUI();
        builder.CheckListName();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_objList"), new GUIContent("Список всех объектов на сцене"), true);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Расстояние между объектами");
        EditorGUILayout.Space();
        builder._distanceBetweenObj = EditorGUILayout.FloatField("", builder._distanceBetweenObj);
        EditorGUILayout.Space();

        if (builder._NameObjReferenceList.Count != 0)
        {

            if (GUILayout.Button("Добавить объект на сцену"))
            {
                _isEditListObj = false;
                _isAdd = true;
                EditorGUILayout.Space();
            }
        }

        if (_isAdd)
        {
            EditorGUILayout.LabelField("Выберите объект");
            EditorGUILayout.Space();
            EditorGUI.BeginChangeCheck();
            builder._indexCurrentObj = EditorGUILayout.Popup(builder._indexCurrentObj, builder._NameObjReferenceList.ToArray());
            EditorGUILayout.Space();

            if (EditorGUI.EndChangeCheck())
            {
                builder.SetCurrentObj();
            }

            if (!builder._isFirstObj)
            {
                EditorGUILayout.LabelField("Сторона с которой будет создан объект относительно предыдущего");
                builder._eSide = (ESide)EditorGUILayout.EnumPopup(builder._eSide);
                EditorGUILayout.Space();
            }

            if (GUILayout.Button("Добавить"))
            {
                _isEditListObj = true;
                _isAdd = false;
                builder.Spawn();
                EditorGUILayout.Space();
            }

            if (GUILayout.Button("Отменить"))
            {
                _isEditListObj = true;
                _isAdd = false;
                EditorGUILayout.Space();
            }
        }

        if (GUILayout.Button("Удалить последний объект на сцене"))
        {
            builder.DestroyLastObj();
            EditorGUILayout.Space();
        }

        if (GUILayout.Button("Удалить все объекты на сцене"))
        {
            builder.DestroyAllObj();
            EditorGUILayout.Space();
        }

        if (GUILayout.Button("Добавить новый объект в список"))
        {
            _isEditListObj = false;
            _isCreated = true;
            EditorGUILayout.Space();
        }

        if (_isCreated)
        {
            EditorGUILayout.LabelField("Имя объекта");
            EditorGUILayout.Space();
            builder._objNameEditor = EditorGUILayout.TextField("", builder._objNameEditor);
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Ссылка на объект");
            EditorGUILayout.Space();
            builder._objReferenceEditor = (GameObject)EditorGUILayout.ObjectField(builder._objReferenceEditor, typeof(GameObject), true);
            EditorGUILayout.Space();

            if (GUILayout.Button("Добавить"))
            {

                if (builder._objNameEditor != null && builder._objReferenceEditor != null)
                {
                    _isEditListObj = true;
                    _isCreated = false;
                    builder.AddNewObjToListReference(builder._objReferenceEditor, builder._objNameEditor);
                    builder._objNameEditor = null;
                    builder._objReferenceEditor = null;
                }
                EditorGUILayout.Space();
            }

            if (GUILayout.Button("Отменить"))
            {
                _isEditListObj = true;
                _isCreated = false;
                builder._objNameEditor = null;
                builder._objReferenceEditor = null;
                EditorGUILayout.Space();
            }
        }

        if (_isEditListObj)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_objReferenceList"), 
            new GUIContent("Список доступных объектов"), true);
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(builder);
            EditorSceneManager.MarkSceneDirty(builder.gameObject.scene);
        }
    }
}
