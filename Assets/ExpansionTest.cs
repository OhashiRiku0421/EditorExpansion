using UnityEngine;
using UnityEditor;

public class ExpansionTest : EditorWindow
{
    [MenuItem("Test/ExpansionTest1", false, 1)]
    private static void MyMenuItem()
    {
        ExpansionTest window = CreateInstance<ExpansionTest>();

        window.ShowAuxWindow();
    }
}
