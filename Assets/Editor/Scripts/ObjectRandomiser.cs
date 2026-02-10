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
        GetWindow<ObjectRandomiser>("Object Randomiser Tool");
    }
    
    public Material[] randomMaterialsList;
    public Mesh[] randomMeshList;

    bool showRandomiseMaterials = false; 
    bool showRandomiseMesh = false;
    bool showRandomisePosition = false;
    bool showRandomiseRotation = false;

    Vector3 startOfPositionArea = Vector3.zero;
    Vector3 endOfPositionArea = Vector3.one;

    Vector4 startOfRotationArea = Vector4.zero;
    Vector4 endOfRotationArea = Vector4.one;

    Vector2 scrollBar = Vector2.zero;

    void OnGUI()
    {
        //scrollBar = GUILayout.BeginScrollView(scrollBar);

        if (showRandomiseMaterials) 
        {
            RandomiseMaterials();
        }
        else if (showRandomiseMesh)
        {
            RandomiseMesh();
        }
        else if (showRandomisePosition)
        {
            RandomisePosition();
        }
        else if (showRandomiseRotation)
        {
            RandomiseRotation();
        }
        else
        {
            if (GUILayout.Button("Randomise Materials"))
            {
                showRandomiseMaterials = true;
            }

            if (GUILayout.Button("Randomise Mesh"))
            {
                showRandomiseMesh = true;
            }
            if (GUILayout.Button("Randomise Position"))
            {
                showRandomisePosition = true;
            }
            if (GUILayout.Button("Randomise Rotation"))
            {
                showRandomiseRotation = true;
            }
            if (GUILayout.Button("Close"))
            {
                showRandomiseMaterials = false;
                showRandomiseMesh = false;
                showRandomisePosition = false;
                showRandomiseRotation = false;
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
                            if (checkedIndexes.Count >= randomMaterialsList.Length)
                            {
                                Debug.LogError("No valid materials found in list.");
                                break;
                            }
                            int materialIndex = Random.Range(0, randomMaterialsList.Length);
                            checkedIndexes.Add(materialIndex);
                            Material newMaterial = randomMaterialsList[materialIndex];
                            if (newMaterial != null)
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

        if (variableProperty != null) {

            EditorGUILayout.PropertyField(variableProperty, true);
            thisObject.ApplyModifiedProperties();
        }
    }

    void RandomisePosition()
    {
        startOfPositionArea = EditorGUILayout.Vector3Field("Start of Area", startOfPositionArea);
        endOfPositionArea = EditorGUILayout.Vector3Field("End of Area", endOfPositionArea);
        if (GUILayout.Button("Randomise!"))
        {
            Debug.Log(startOfPositionArea);
            Debug.Log(endOfPositionArea);
            if (Selection.objects.Length > 0)
            {
                foreach (var thisobj in Selection.objects)
                {
                    Transform transform = thisobj.GetComponent<Transform>();
                    if (transform != null)
                    {
                        transform.position = new Vector3(Random.Range(startOfPositionArea.x, endOfPositionArea.x), Random.Range(startOfPositionArea.y, endOfPositionArea.y), Random.Range(startOfPositionArea.z, endOfPositionArea.z));
                    }
                    else
                    {
                        Debug.LogError("[" + thisobj.name + "] Does not contain a transform component");
                    }

                    Debug.Log(thisobj.name);
                }
            }
        }
        if (GUILayout.Button("Return"))
        {
            showRandomisePosition = false;
        }
        return;
    }

    void RandomiseRotation()
    {
        startOfRotationArea = EditorGUILayout.Vector4Field("Start of Area", startOfRotationArea);
        endOfRotationArea = EditorGUILayout.Vector4Field("End of Area", endOfRotationArea);
        if (GUILayout.Button("Randomise!"))
        {
            Debug.Log(startOfPositionArea);
            Debug.Log(endOfPositionArea);
            if (Selection.objects.Length > 0)
            {
                foreach (var thisobj in Selection.objects)
                {
                    Transform transform = thisobj.GetComponent<Transform>();
                    if (transform != null)
                    {
                        transform.rotation = new Quaternion(Random.Range(startOfRotationArea.x, endOfRotationArea.x), Random.Range(startOfRotationArea.y, endOfRotationArea.y), Random.Range(startOfRotationArea.z, endOfRotationArea.z), Random.Range(startOfRotationArea.w, endOfRotationArea.w));
                    }
                    else
                    {
                        Debug.LogError("[" + thisobj.name + "] Does not contain a transform component");
                    }

                    Debug.Log(thisobj.name);
                }
            }
        }
        if (GUILayout.Button("Return"))
        {
            showRandomiseRotation = false;
        }
        return;
    }
}