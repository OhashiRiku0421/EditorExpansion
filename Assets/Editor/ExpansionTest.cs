using UnityEngine;
using UnityEditor;

public class ExpansionTest : EditorWindow
{
    private string _memo;

    [MenuItem("Test/ExpansionTest1", false, 1)]
    private static void MyMenuItem()
    {
        GetWindow<ExpansionTest>();
    }

    private void OnGUI()
    {
        GUILayout.Label("Memo");
        _memo = EditorGUILayout.TextArea(_memo, GUILayout.Height(EditorGUIUtility.singleLineHeight * 5));
        if(GUILayout.Button("Apply"))
        {
            Debug.Log(_memo);
        }
    }
}