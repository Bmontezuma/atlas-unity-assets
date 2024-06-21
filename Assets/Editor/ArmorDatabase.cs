using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ArmorDatabase : ItemDatabase<Armor>
{
    [MenuItem("Window/Item Manager/Armor Database")]
    public static void ShowWindow()
    {
        GetWindow<ArmorDatabase>("Armor Database");
    }
}
