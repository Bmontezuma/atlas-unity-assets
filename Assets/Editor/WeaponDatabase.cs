using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WeaponDatabase : ItemDatabase<Weapon>
{
    // Implementing abstract method to import items from CSV
    public override void ImportItemsFromCSV()
    {
        // Implement import logic here
    }

    // Implementing abstract method to draw properties section
    public override void DrawPropertiesSection()
    {
        // Implement drawing properties section UI here
    }

    // Implementing abstract method to export items to CSV
    public override void ExportItemsToCSV()
    {
        // Implement export logic here
    }

    // Implementing abstract method to draw item list
    public override void DrawItemList()
    {
        // Implement drawing item list UI here
    }

    [MenuItem("Window/Item Manager/Weapon Database")]
    public static void ShowWindow()
    {
        GetWindow<WeaponDatabase>("Weapon Database");
    }
}