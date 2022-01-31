using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RoadBuilder))]
[CanEditMultipleObjects]
public class RoadBuilderCustomEditor : Editor
{
    private bool _isCreated = false;
    private bool _isAdd = false;
    private bool _isEditListObj = true;

    public override void OnInspectorGUI()
    {
        RoadBuilder roadBuilder = (RoadBuilder)target;
        base.OnInspectorGUI();
        roadBuilder.CheckListName();
        EditorGUILayout.LabelField("���������", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        roadBuilder._distanceBetweenObj = EditorGUILayout.FloatField("���������� ����� ���������", roadBuilder._distanceBetweenObj);
        EditorGUILayout.Space();

        if (roadBuilder._NameObjReferenceList.Count != 0)
        {

            if (GUILayout.Button("�������� ������ �� �����"))
            {
                _isEditListObj = false;
                _isAdd = true;
            }
        }
        EditorGUILayout.Space();

        if (_isAdd)
        {
            EditorGUI.BeginChangeCheck();
            roadBuilder._indexCurrentObj = EditorGUILayout.Popup(
                "�������� ������", roadBuilder._indexCurrentObj, roadBuilder._NameObjReferenceList.ToArray());

            if (EditorGUI.EndChangeCheck()) roadBuilder.SetCurrentObj();

            if (!roadBuilder._isFirstObj)
            {
                EditorGUILayout.LabelField("������� ������������ ����������� �������");
                roadBuilder._eSide = (ESide)EditorGUILayout.EnumPopup(roadBuilder._eSide);
            }
            EditorGUILayout.Space();

            if (GUILayout.Button("��������"))
            {
                _isEditListObj = true;
                _isAdd = false;
                roadBuilder.Spawn();
            }
            EditorGUILayout.Space();

            if (GUILayout.Button("��������"))
            {
                _isEditListObj = true;
                _isAdd = false;
            }
            EditorGUILayout.Space();
        }

        if (GUILayout.Button("������� ��������� ������ �� �����")) roadBuilder.DestroyLastObj();
        EditorGUILayout.Space();

        if (GUILayout.Button("������� ��� ������� �� �����")) roadBuilder.DestroyAllObj();
        EditorGUILayout.Space();

        if (GUILayout.Button("�������� ����� ������ � ������"))
        {
            _isEditListObj = false;
            _isCreated = true;
        }
        EditorGUILayout.Space();

        if (_isCreated)
        {
            roadBuilder._objNameEditor = EditorGUILayout.TextField("��� �������", roadBuilder._objNameEditor);
            roadBuilder._objReferenceEditor = (GameObject)EditorGUILayout.ObjectField(
                "������ �� ������", roadBuilder._objReferenceEditor, typeof(GameObject), true);
            EditorGUILayout.Space();

            if (GUILayout.Button("��������"))
            {

                if (roadBuilder._objNameEditor != null && roadBuilder._objReferenceEditor != null)
                {
                    _isEditListObj = true;
                    _isCreated = false;
                    roadBuilder.AddNewObjToListReference(roadBuilder._objReferenceEditor, roadBuilder._objNameEditor);
                    roadBuilder._objNameEditor = null;
                    roadBuilder._objReferenceEditor = null;
                }
            }
            EditorGUILayout.Space();

            if (GUILayout.Button("��������"))
            {
                _isEditListObj = true;
                _isCreated = false;
                roadBuilder._objNameEditor = null;
                roadBuilder._objReferenceEditor = null;
            }
            EditorGUILayout.Space();
        }

        if (_isEditListObj)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_objList"), new GUIContent("������ ���� �������� �� �����"), true);
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_objReferenceList"), 
            new GUIContent("������ ��������� ��������"), true);
        }
        serializedObject.ApplyModifiedProperties();

        if (GUI.changed) EditorUtility.SetDirty(roadBuilder);
    }
}

