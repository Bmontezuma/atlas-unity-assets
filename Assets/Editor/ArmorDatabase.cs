using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class Armor : ScriptableObject
{
    public string armorName;
    public string itemDescription;
    public int value;

    public int defense;
    public float durability;
    // Add other properties as needed
}

public class ArmorDatabase : ItemDatabase<Armor>
{
    private Armor _selectedArmor;
    private bool _invalidName;
    private bool _duplicateName;

    protected override void ImportItemsFromCSV()
    {
        // Implement import logic specific to armor
    }

    protected override void DrawPropertiesSection()
    {
        // Implement drawing properties section UI for armor
        DrawPropertiesEditor();
    }

    protected override void DrawItemList()
    {
        // Implement drawing item list UI for armor
    }

    protected override void ExportItemsToCSV()
    {
        // Implement export logic specific to armor
    }

    private void DrawPropertiesEditor()
    {
        if (_selectedArmor != null)
        {
            EditorGUI.BeginChangeCheck();

            // Display armor properties (e.g., defense, durability, weight)
            _selectedArmor.armorName = EditorGUILayout.TextField("Armor Name", _selectedArmor.armorName);
            _selectedArmor.defense = EditorGUILayout.IntField("Defense", _selectedArmor.defense);
            _selectedArmor.durability = EditorGUILayout.FloatField("Durability", _selectedArmor.durability);
            // Add other properties as needed

            if (EditorGUI.EndChangeCheck())
            {
                ValidateArmorProperties();
            }

            if (_invalidName)
            {
                EditorGUILayout.HelpBox("Invalid name. Special characters not allowed.", MessageType.Error);
            }
            // Add other feedback messages based on validation results
        }
    }

    private void ValidateArmorProperties()
    {
        _invalidName = ContainsSpecialCharacters(_selectedArmor.armorName);
        // Implement other validation checks

        if (_duplicateName)
        {
            _selectedArmor.armorName += $"_{Guid.NewGuid()}";
        }
    }

    private bool ContainsSpecialCharacters(string text)
    {
        // Implement your logic to check for special characters
        // (except spaces, dashes, and single quotes)
        return false; // Placeholder; replace with actual implementation
    }

    [MenuItem("Window/Item Manager/Armor Database")]
    public static void ShowWindow()
    {
        GetWindow<ArmorDatabase>("Armor Database");
    }
}