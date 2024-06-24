using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class ItemDatabase<T> : EditorWindow where T : ScriptableObject
{
    protected List<T> items = new List<T>();

    private void OnEnable()
    {
        LoadItems();
    }

    protected abstract void ImportItemsFromCSV();
    protected abstract void DrawPropertiesSection();
    protected abstract void ExportItemsToCSV();
    protected abstract void DrawItemList();

    private void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        DrawItemList();
        EditorGUILayout.EndVertical();

        EditorGUILayout.Space();

        EditorGUILayout.BeginVertical();
        DrawPropertiesSection();
        EditorGUILayout.EndVertical();
    }

    protected void LoadItems()
    {
        items.Clear();
        string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            T item = AssetDatabase.LoadAssetAtPath<T>(path);
            items.Add(item);
        }
    }
}