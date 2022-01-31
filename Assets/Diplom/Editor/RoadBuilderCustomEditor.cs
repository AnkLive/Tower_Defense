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
        EditorGUILayout.LabelField("Параметры", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        roadBuilder._distanceBetweenObj = EditorGUILayout.FloatField("Расстояние между объектами", roadBuilder._distanceBetweenObj);
        EditorGUILayout.Space();

        if (roadBuilder._NameObjReferenceList.Count != 0)
        {

            if (GUILayout.Button("Добавить объект на сцену"))
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
                "Выберите объект", roadBuilder._indexCurrentObj, roadBuilder._NameObjReferenceList.ToArray());

            if (EditorGUI.EndChangeCheck()) roadBuilder.SetCurrentObj();

            if (!roadBuilder._isFirstObj)
            {
                EditorGUILayout.LabelField("Позиция относительно предыдущего объекта");
                roadBuilder._eSide = (ESide)EditorGUILayout.EnumPopup(roadBuilder._eSide);
            }
            EditorGUILayout.Space();

            if (GUILayout.Button("Добавить"))
            {
                _isEditListObj = true;
                _isAdd = false;
                roadBuilder.Spawn();
            }
            EditorGUILayout.Space();

            if (GUILayout.Button("Отменить"))
            {
                _isEditListObj = true;
                _isAdd = false;
            }
            EditorGUILayout.Space();
        }

        if (GUILayout.Button("Удалить последний объект на сцене")) roadBuilder.DestroyLastObj();
        EditorGUILayout.Space();

        if (GUILayout.Button("Удалить все объекты на сцене")) roadBuilder.DestroyAllObj();
        EditorGUILayout.Space();

        if (GUILayout.Button("Добавить новый объект в список"))
        {
            _isEditListObj = false;
            _isCreated = true;
        }
        EditorGUILayout.Space();

        if (_isCreated)
        {
            roadBuilder._objNameEditor = EditorGUILayout.TextField("Имя объекта", roadBuilder._objNameEditor);
            roadBuilder._objReferenceEditor = (GameObject)EditorGUILayout.ObjectField(
                "Ссылка на объект", roadBuilder._objReferenceEditor, typeof(GameObject), true);
            EditorGUILayout.Space();

            if (GUILayout.Button("Добавить"))
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

            if (GUILayout.Button("Отменить"))
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
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_objList"), new GUIContent("Список всех объектов на сцене"), true);
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_objReferenceList"), 
            new GUIContent("Список доступных объектов"), true);
        }
        serializedObject.ApplyModifiedProperties();

        if (GUI.changed) EditorUtility.SetDirty(roadBuilder);
    }
}

