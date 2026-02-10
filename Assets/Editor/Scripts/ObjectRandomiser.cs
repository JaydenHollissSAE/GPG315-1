using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ObjectRandomiser : EditorWindow
{
    [MenuItem("Object Tools/Object Randomiser")]
    [CanEditMultipleObjects]
    public static void ShowWindow()
    {
        GetWindow<ObjectRandomiser>("Hello World");
    }
    
    public Material[] randomMaterialsList;
    public Mesh[] randomMeshList;

    bool showRandomiseMaterials = false; 
    bool showRandomiseMesh = false; 

    void OnGUI()
    {
        if (showRandomiseMaterials) 
        {
            RandomiseMaterials();
        }
        else if (showRandomiseMesh)
        {
            RandomiseMesh();
        }
        else
        {

            GUILayout.Label("Hello World!", EditorStyles.boldLabel);

            if (GUILayout.Button("Randomise Materials"))
            {
                showRandomiseMaterials = true;
            }

            if (GUILayout.Button("Randomise Mesh"))
            {
                showRandomiseMesh = true;
            }
            if (GUILayout.Button("Close"))
            {
                this.Close();
            }
        }

    }

    void RandomiseMaterials()
    {

        DisplayList("randomMaterialsList");

        if (GUILayout.Button("Randomise Materials"))
        {
            if (Selection.objects.Length > 0)
            {
                foreach (var thisobj in Selection.objects)
                {
                    Renderer material = thisobj.GetComponent<Renderer>();
                    if (material != null)
                    {
                        material.material = randomMaterialsList[Random.Range(0, randomMaterialsList.Length)];
                    }
                    else
                    {
                        Debug.LogError("[" + thisobj.name + "] Does not contain a renderer component");
                    }

                    Debug.Log(thisobj.name);
                }

            }
        }
        if (GUILayout.Button("Return"))
        {
            showRandomiseMaterials = false;
        }
        return;
    }

    void RandomiseMesh()
    {
        DisplayList("randomMeshList");

        if (GUILayout.Button("Randomise Mesh"))
        {
            if (Selection.objects.Length > 0)
            {
                foreach (var thisobj in Selection.objects)
                {
                    MeshFilter mesh = thisobj.GetComponent<MeshFilter>();
                    if (mesh != null)
                    {
                        mesh.mesh = randomMeshList[Random.Range(0, randomMeshList.Length)];
                    }
                    else
                    {
                        Debug.LogError("[" + thisobj.name + "] Does not contain a renderer component");
                    }

                    Debug.Log(thisobj.name);
                }

            }
        }
        if (GUILayout.Button("Return"))
        {
            showRandomiseMesh = false;
        }
        return;
    }

    void DisplayList(string fieldName)
    {

        ScriptableObject target = this;
        SerializedObject so = new SerializedObject(target);
        SerializedProperty stringsProperty = so.FindProperty(fieldName);

        EditorGUILayout.PropertyField(stringsProperty, true); // True means show children
        so.ApplyModifiedProperties(); // Remember to apply modified properties
    }
}