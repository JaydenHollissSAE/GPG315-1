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

        if (GUILayout.Button("Randomise!"))
        {
            if (Selection.objects.Length > 0)
            {
                foreach (var thisobj in Selection.objects)
                {
                    Renderer material = thisobj.GetComponent<Renderer>();
                    if (material != null)
                    {
                        List<int> checkedIndexes = new List<int>();
                        while (true)
                        {
                            if (checkedIndexes.Count >= randomMeshList.Length)
                            {
                                Debug.LogError("No valid materials found in list.");
                                break;
                            }
                            int materialIndex = Random.Range(0, randomMeshList.Length);
                            checkedIndexes.Add(materialIndex);
                            Material newMaterial = randomMaterialsList[materialIndex];
                            if (material != null)
                            {
                                material.material = newMaterial;
                                break;
                            }
                            else Debug.LogError("Mesh at index [" + materialIndex + "] is empty.");

                        }
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

        if (GUILayout.Button("Randomise!"))
        {
            if (Selection.objects.Length > 0)
            {
                foreach (var thisobj in Selection.objects)
                {
                    MeshFilter mesh = thisobj.GetComponent<MeshFilter>();
                    if (mesh != null)
                    {
                        List<int> checkedIndexes = new List<int>();
                        while (true)
                        {
                            if (checkedIndexes.Count >= randomMeshList.Length)
                            {
                                Debug.LogError("No valid meshes found in list.");
                                break;
                            }
                            int meshIndex = Random.Range(0, randomMeshList.Length);
                            checkedIndexes.Add(meshIndex);
                            Mesh newMesh = randomMeshList[meshIndex];
                            if (mesh != null)
                            {
                                mesh.mesh = newMesh;
                                break;
                            }
                            else Debug.LogError("Mesh at index [" + meshIndex + "] is empty.");

                        }
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
        SerializedObject thisObject = new SerializedObject(target);
        SerializedProperty variableProperty = thisObject.FindProperty(fieldName);

        EditorGUILayout.PropertyField(variableProperty, true);
        thisObject.ApplyModifiedProperties();
    }
}