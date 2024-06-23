using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PotionDatabase : ItemDatabase<Potion>
{
    protected override void ImportItemsFromCSV()
    {
        // Implement import logic specific to potions
    }

    protected override void DrawPropertiesSection()
    {
        // Implement drawing properties section UI for potions
    }

    protected override void ExportItemsToCSV()
    {
        // Implement export logic specific to potions
    }

    protected override void DrawItemList()
    {
        // Implement drawing item list UI for potions
    }

    [MenuItem("Window/Item Manager/Potion Database")]
    public static void ShowWindow()
    {
        GetWindow<PotionDatabase>("Potion Database");
    }
}
