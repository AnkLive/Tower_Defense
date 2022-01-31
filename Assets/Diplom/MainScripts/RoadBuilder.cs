using System;
using System.Collections.Generic;
using UnityEngine;

public enum ESide {Left, Right, Top, Bottom}

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
    public List<ObjReferenceList> _objReferenceList = new List<ObjReferenceList>();
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