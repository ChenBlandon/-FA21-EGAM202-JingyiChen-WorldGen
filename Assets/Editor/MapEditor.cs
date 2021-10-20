using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(MountainGenerator))]
[CanEditMultipleObjects]
public class MapEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MountainGenerator Gen = (MountainGenerator)target;
        if (GUILayout.Button("Pip"))
        {
            Gen.Pip();
        }
        if (GUILayout.Button("SetElevation"))
        {
            Gen.SetElevation();
        }
        if (GUILayout.Button("ExtrudeBox"))
        {
            Gen.ExtrudeBox();
        }
        if (GUILayout.Button("ThreeStairs"))
        {
            Gen.threeStairs();
        }
        if (GUILayout.Button("ExtrudeCylinder"))
        {
            Gen.ExtrudeCylinder();
        }
        if (GUILayout.Button("ExtrudeDome"))
        {
            Gen.ExtrudeDome();
        }
    }
}
