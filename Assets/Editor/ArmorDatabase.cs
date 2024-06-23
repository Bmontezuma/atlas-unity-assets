using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ArmorDatabase : ItemDatabase<Armor>
{
    protected override void ImportItemsFromCSV()
    {
        // Implement import logic specific to armor
    }

    protected override void DrawPropertiesSection()
    {
        // Implement drawing properties section UI for armor
    }

    protected override void ExportItemsToCSV()
    {
        // Implement export logic specific to armor
    }

    protected override void DrawItemList()
    {
        // Implement drawing item list UI for armor
    }

    [MenuItem("Window/Item Manager/Armor Database")]
    public static void ShowWindow()
    {
        GetWindow<ArmorDatabase>("Armor Database");
    }
}