using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(OfferModelSO))]
public class OfferModelSOEditor : Editor
{
    private void OnEnable()
    {
        OfferModelSO offerModelSO = (OfferModelSO)target;

        if (offerModelSO.items == null || offerModelSO.items.Length == 0)
        {
            offerModelSO.items = new Item[3];
        }
    }

    public override void OnInspectorGUI()
    {
        OfferModelSO offerModelSO = (OfferModelSO)target;

        if (offerModelSO.items.Length < 3) EditorGUILayout.HelpBox("Минимальное количество элементов: 3", MessageType.Error);
        else if (offerModelSO.items.Length > 6) EditorGUILayout.HelpBox("Максимальное количество элементов: 6", MessageType.Error);

        EditorGUI.BeginChangeCheck();

        SerializedProperty titleProperty = serializedObject.FindProperty("title");
        SerializedProperty descriptionProperty = serializedObject.FindProperty("description");
        SerializedProperty itemsProperty = serializedObject.FindProperty("items");
        SerializedProperty priceProperty = serializedObject.FindProperty("price");
        SerializedProperty discountedPriceProperty = serializedObject.FindProperty("discountedPrice");
        SerializedProperty imageIdProperty = serializedObject.FindProperty("imageId");
        
        EditorGUILayout.PropertyField(titleProperty);
        EditorGUILayout.PropertyField(descriptionProperty);
        EditorGUILayout.Space(10);
        for (int i = 0; i < itemsProperty.arraySize; i++)
        {
            EditorGUILayout.PropertyField(itemsProperty.GetArrayElementAtIndex(i), new GUIContent($"Item {i + 1}"));
        }

        if (itemsProperty.arraySize < 6)
        {
            if (GUILayout.Button("Добавить элемент"))
            {
                itemsProperty.InsertArrayElementAtIndex(itemsProperty.arraySize);
                serializedObject.ApplyModifiedProperties();
            }
        }

        if (itemsProperty.arraySize > 3)
        {
            if (GUILayout.Button("Удалить последний элемент"))
            {
                itemsProperty.DeleteArrayElementAtIndex(itemsProperty.arraySize - 1);
                serializedObject.ApplyModifiedProperties();
            }
        }
        EditorGUILayout.Space(10);
        EditorGUILayout.PropertyField(priceProperty);
        EditorGUILayout.PropertyField(discountedPriceProperty);
        EditorGUILayout.PropertyField(imageIdProperty);

        if (EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
        }
    }
}
