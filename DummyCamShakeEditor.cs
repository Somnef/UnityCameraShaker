using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DummyCameraShaker))]
public class DummyCamShakeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DummyCameraShaker script = (DummyCameraShaker)target;

        if (GUILayout.Button("Shake"))
        {
            script.Shake();
        }
    }
}
