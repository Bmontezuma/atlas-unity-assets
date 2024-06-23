using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WeaponDatabase : ItemDatabase<Weapon>
{
    protected override void ImportItemsFromCSV()
    {
        // Implement your specific import logic for weapons
    }

    protected override void DrawPropertiesSection()
    {
        // Implement how weapon properties are drawn in the editor
    }

    protected override void DrawItemList()
    {
        // Implement how the list of weapons is drawn in the editor
    }

    protected override void ExportItemsToCSV()
    {
        // Implement your specific export logic for weapons
    }

    [MenuItem("Window/Item Manager/Weapon Database")]
    public static void ShowWindow()
    {
        GetWindow<WeaponDatabase>("Weapon Database");
    }
}
