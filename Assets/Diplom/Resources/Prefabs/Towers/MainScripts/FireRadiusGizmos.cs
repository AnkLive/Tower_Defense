using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class FireRadiusGizmos : MonoBehaviour
{
    [field: SerializeField]
    public SphereCollider _sphereCollider {get; set; }
    public float _radius {get; set; }
    void Start()
    {
        _sphereCollider = gameObject.GetComponent<SphereCollider>();
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}

[CustomEditor(typeof(FireRadiusGizmos)), CanEditMultipleObjects]
public class TowerOptionsCustomEditor : Editor
{

    public override void OnInspectorGUI()
    {
        FireRadiusGizmos fireRadiusGizmos = (FireRadiusGizmos)target;
        base.OnInspectorGUI();
        EditorGUI.BeginChangeCheck();
        fireRadiusGizmos._radius = EditorGUILayout.FloatField("Радиус огня башни", fireRadiusGizmos._radius);

        if (EditorGUI.EndChangeCheck())
        {
            fireRadiusGizmos._sphereCollider.radius = fireRadiusGizmos._radius;
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(fireRadiusGizmos);
            EditorSceneManager.MarkSceneDirty(fireRadiusGizmos.gameObject.scene);
        }
    }
}
