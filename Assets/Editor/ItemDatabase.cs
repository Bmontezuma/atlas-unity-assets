using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class ItemDatabase<T> : EditorWindow
{
    protected List<T> items;

    protected abstract void ImportItemsFromCSV();
    protected abstract void DrawPropertiesSection();
    protected abstract void ExportItemsToCSV();
    protected abstract void DrawItemList();

    // Other common functionality for item databases can be added here
}