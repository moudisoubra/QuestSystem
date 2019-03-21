using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(Quest))]
public class QuestEditor : Editor
{
    ReorderableList objectiveList;
    Quest quest;

    private void OnEnable()
    {
        quest = (Quest)target;
        DeleteMissingGameObjects();
        if (quest.objectives == null)
        {
            quest.objectives = new List<Objective>();
        }

        objectiveList = new ReorderableList(serializedObject, serializedObject.FindProperty("objectives"), true, true, true, true);

        objectiveList.onAddCallback = (list) =>
        {
            var obj = new GameObject("Objective_" + quest.objectives.Count).AddComponent<Objective>();
            obj.quest = quest;
            obj.transform.parent = quest.transform;
            quest.objectives.Add(obj);
            DeleteMissingGameObjects();
            Undo.RegisterFullObjectHierarchyUndo(quest, "Added an objective");
        };
        objectiveList.onRemoveCallback = (list) =>
        {
            DeleteMissingGameObjects();
            var index = list.index;
            GameObject.DestroyImmediate(quest.objectives[index].gameObject);
            quest.objectives.RemoveAt(index);
        };

        objectiveList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            var element = objectiveList.serializedProperty.GetArrayElementAtIndex(index);
            EditorGUI.PropertyField(
                new Rect(rect.x, rect.y + 2, rect.width, rect.height), element, GUIContent.none);
        };

        objectiveList.onReorderCallback = (list) =>
        {
            quest.transform.DetachChildren();
            for (int i = 0; i < quest.objectives.Count; i++)
            {
                quest.objectives[i].transform.parent = quest.transform;
            }
        };


    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        objectiveList.DoLayoutList();
    }

    public void DeleteMissingGameObjects()
    {
        for (int i = 0; i < quest.objectives.Count; i++)
        {
            if (quest.objectives[i] == null)
            {
                quest.objectives.RemoveAt(i);
            }
        }
    }
}
