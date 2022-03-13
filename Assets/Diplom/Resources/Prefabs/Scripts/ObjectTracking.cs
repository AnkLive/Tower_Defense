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

public class ObjectTracking : Tracking
{
    [SerializeField] private float speedRotation;
    [SerializeField] private string objectTrackingTag;
    [SerializeField] private List<ObjRotation> objList = new List<ObjRotation>();
    [SerializeField] private List<GameObject> objTracking = new List<GameObject>();

    public override float _speedRotation { get => speedRotation; set => speedRotation = value; }
    public override string _objectTrackingTag { get => objectTrackingTag; set => objectTrackingTag = value; }
    public override List<ObjRotation> _objList { get => objList; set => objList = value; }
    public override List<GameObject> _objTracking { get => objTracking; set => objTracking = value; }

    private void Awake() => base.Subscribe();

    private void Update() => base.checkListTracking();

    private void OnTriggerEnter(Collider collider) => base.AddTrackingListObj(collider.gameObject);

    private void OnTriggerStay(Collider collider) => base.CheckTagObj(collider.gameObject);

    private void OnTriggerExit(Collider collider) => base.RemoveTrackingListObj();

    private void OnDisable() => base.Unsubscribe();
}
