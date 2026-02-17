using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;

[CustomEditor(typeof(Transform))]
public class RandomiserVisulisationTool : Editor
{
    public static Vector3 drawStartPos;
    public static Vector3 drawEndPos;

    private void DrawBox()
    {
        //Debug.Log("Active 1");
        if (ObjectRandomiser.showVisulisation)
        {


            Handles.DrawDottedLine(new Vector3(drawStartPos.x, drawStartPos.y, drawStartPos.z), new Vector3(drawEndPos.x, drawStartPos.y, drawStartPos.z), 4);
            Handles.DrawDottedLine(new Vector3(drawStartPos.x, drawStartPos.y, drawStartPos.z), new Vector3(drawStartPos.x, drawStartPos.y, drawEndPos.z), 4);
            Handles.DrawDottedLine(new Vector3(drawStartPos.x, drawStartPos.y, drawStartPos.z), new Vector3(drawStartPos.x, drawEndPos.y, drawStartPos.z), 4);
            
            Handles.DrawDottedLine(new Vector3(drawEndPos.x, drawStartPos.y, drawStartPos.z), new Vector3(drawEndPos.x, drawStartPos.y, drawEndPos.z), 4);
            Handles.DrawDottedLine(new Vector3(drawEndPos.x, drawStartPos.y, drawStartPos.z), new Vector3(drawEndPos.x, drawEndPos.y, drawStartPos.z), 4);

            Handles.DrawDottedLine(new Vector3(drawStartPos.x, drawEndPos.y, drawStartPos.z), new Vector3(drawEndPos.x, drawEndPos.y, drawStartPos.z), 4);
            Handles.DrawDottedLine(new Vector3(drawStartPos.x, drawEndPos.y, drawStartPos.z), new Vector3(drawStartPos.x, drawEndPos.y, drawEndPos.z), 4);

            Handles.DrawDottedLine(new Vector3(drawStartPos.x, drawStartPos.y, drawEndPos.z), new Vector3(drawEndPos.x, drawStartPos.y, drawEndPos.z), 4);
            Handles.DrawDottedLine(new Vector3(drawStartPos.x, drawStartPos.y, drawEndPos.z), new Vector3(drawStartPos.x, drawEndPos.y, drawEndPos.z), 4);

            Handles.DrawDottedLine(new Vector3(drawEndPos.x, drawEndPos.y, drawEndPos.z), new Vector3(drawEndPos.x, drawEndPos.y, drawStartPos.z), 4);
            Handles.DrawDottedLine(new Vector3(drawEndPos.x, drawEndPos.y, drawEndPos.z), new Vector3(drawEndPos.x, drawStartPos.y, drawEndPos.z), 4);
            Handles.DrawDottedLine(new Vector3(drawEndPos.x, drawEndPos.y, drawEndPos.z), new Vector3(drawStartPos.x, drawEndPos.y, drawEndPos.z), 4);

        }
    }

    private void OnSceneGUI()
    {
        DrawBox();
    }

}