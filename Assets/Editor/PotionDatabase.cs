using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PotionDatabase : ItemDatabase<Potion>
{
    [MenuItem("Window/Item Manager/Potion Database")]
    public static void ShowWindow()
    {
        GetWindow<PotionDatabase>("Potion Database");
    }
}