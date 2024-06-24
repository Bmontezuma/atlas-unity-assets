using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Define a new class specifically for potion creation, inheriting from EditorWindow
public class PotionDatabase : EditorWindow
{
    // Common fields for potion creation
    protected string potionName;
    protected Sprite potionIcon;
    protected string potionDescription;
    protected float potionValue;
    protected int potionEffectLevel;
    protected Rarity potionRarity;

    // Method to show the window
    [MenuItem("Window/Potion Database")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(PotionDatabase), true, "Create New Potion");
    }

    // Method to draw GUI for potion creation
    void OnGUI()
    {
        DrawPotionFields();
    }

    // Method to create the potion
    void CreatePotion()
    {
        // Determine the folder path for potions
        string folderPath = "Assets/Potions/";

        // Create the directory if it doesn't exist
        if (!AssetDatabase.IsValidFolder(folderPath))
        {
            System.IO.Directory.CreateDirectory(Application.dataPath + folderPath.Substring("Assets".Length));
            AssetDatabase.Refresh();
        }

        // Define the full path for the asset
        string fullPath = folderPath + potionName + ".asset";
        fullPath = AssetDatabase.GenerateUniqueAssetPath(fullPath);

        // Create a new Potion asset
        Potion newPotion = ScriptableObject.CreateInstance<Potion>();
        newPotion.itemName = potionName;
        newPotion.baseValue = potionValue;
        newPotion.rarity = potionRarity;

        AssetDatabase.CreateAsset(newPotion, fullPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    // Method to draw fields specific to potions
    void DrawPotionFields()
    {
        potionName = EditorGUILayout.TextField("Name:", potionName);
        potionIcon = (Sprite)EditorGUILayout.ObjectField("Icon:", potionIcon, typeof(Sprite), false);
        potionDescription = EditorGUILayout.TextField("Description:", potionDescription);
        potionValue = EditorGUILayout.FloatField("Base Value:", potionValue);
        potionEffectLevel = EditorGUILayout.IntField("Effect Level:", potionEffectLevel);
        potionRarity = (Rarity)EditorGUILayout.EnumPopup("Rarity:", potionRarity);

        if (GUILayout.Button("Create Potion"))
        {
            CreatePotion();
        }
    }
}
