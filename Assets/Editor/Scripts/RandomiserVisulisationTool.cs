using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;

[CustomEditor(typeof(Transform))]
public class RandomiserVisulisationTool : Editor
{
    public static Vector3 drawStartPos;
    public static Vector3 drawEndPos;

    private void Test()
    {
        //Debug.Log("Active 1");
        if (ObjectRandomiser.showVisulisation)
        {
            //Debug.Log(drawStartPos);

            //Vector3[] positions = new Vector3[2] { drawStartPos, drawEndPos };

            //for (int x = 0; x < 2; x++)
            //{
            //    for (int y = 0; y < 2; y++)
            //    {
            //        for (int z = 0; z < 2; z++)
            //        {
            //            Handles.DrawDottedLine(new Vector3(positions[0].x, positions[0].y, positions[0].z), new Vector3(positions[0+x].x, positions[0+y].y, positions[0 + z].z), 4);
            //        }
            //    }
            //}

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

            //Handles.DrawDottedLine(drawStartPos, drawEndPos, 4);
            //Handles.DrawDottedLine(Vector3.zero, Vector3.one, 4);
        }
    }

    private void OnSceneGUI()
    {
        Test();
    }

}