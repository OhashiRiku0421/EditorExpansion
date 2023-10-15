using UnityEngine;
using UnityEditor;

public class InspectorTest : MonoBehaviour
{
    [SerializeField]
    private int _test = 10;
}

[CustomEditor(typeof(InspectorTest))]
public class Expansion : Editor
{
    private SerializedProperty _testProperty;

    private void OnEnable()
    {
        _testProperty = serializedObject.FindProperty("_test");
    }

    public override void OnInspectorGUI()
    {
        //InspectorTest inspectorTest = target as InspectorTest;
        serializedObject.Update();
        EditorGUILayout.PropertyField(_testProperty);
        _testProperty.intValue = EditorGUILayout.IntSlider(_testProperty.intValue, 0, 10);
        serializedObject.ApplyModifiedProperties();
    }
}
