using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Dummy))]
public class DummyEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Dummy script = (Dummy)target;

        if (GUILayout.Button("Shake"))
        {
            script.Shake();
        }
    }
}
