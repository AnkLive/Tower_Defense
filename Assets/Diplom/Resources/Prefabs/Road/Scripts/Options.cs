using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Options : MonoBehaviour
{
    public bool _dizmosIsVisible { get; set; } = true;
    public void RotateObjLeft()
    {

        if (gameObject.transform.rotation.y > 360f) gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        gameObject.transform.rotation = Quaternion.Euler(
            transform.rotation.eulerAngles.x, 
            transform.rotation.eulerAngles.y - 90f, 
            transform.rotation.eulerAngles.z
        );
    }
    
    public void RotateObjRight()
    {

        if (gameObject.transform.rotation.y > 360f) gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        gameObject.transform.rotation = Quaternion.Euler(
            transform.rotation.eulerAngles.x, 
            transform.rotation.eulerAngles.y + 90f, 
            transform.rotation.eulerAngles.z
        );
    }

    public void OnDrawGizmos()
    {
        if (_dizmosIsVisible) 
        {
            Gizmos.color = Color.red;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawCube(new Vector3(
                gameObject.transform.position.normalized.x - 0.25f, 
                gameObject.transform.position.normalized.y + 0.5f, 
                gameObject.transform.position.normalized.z - 1f), 
                new Vector3(0.25f, 0.2f, 0.35f)
            );
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(new Vector3(
                gameObject.transform.position.normalized.x - 0.25f, 
                gameObject.transform.position.normalized.y + 0.5f, 
                gameObject.transform.position.normalized.z - 0.5f), 
                0.10f
            );
        }
    }
}

[CustomEditor(typeof(Options))]
[CanEditMultipleObjects]
public class OptionsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Options options = (Options)target;
        base.OnInspectorGUI();
        options._dizmosIsVisible = EditorGUILayout.Toggle("Видимость Gizmos ", options._dizmosIsVisible);
        EditorGUILayout.Space();

        if (GUILayout.Button("Повернуть влево на 90 градусов"))
        {
            options.RotateObjLeft();
            EditorGUILayout.Space();
        }

        if (GUILayout.Button("Повернуть вправо на 90 градусов"))
        {
            options.RotateObjRight();
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(options);
            EditorSceneManager.MarkSceneDirty(options.gameObject.scene);
        }
    }
}
