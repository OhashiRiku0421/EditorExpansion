using UnityEditor;
using UnityEngine;

public class ScriptGeneratorWindow : EditorWindow
{
    private string _scriptName = "NewScript";

    [MenuItem("Test/ScriptGenerator")]
    public static void Window()
    {
        GetWindow<ScriptGeneratorWindow>("ScriptGenerator");//windowを生成
    }

    private void OnGUI()
    {
        GUILayout.Label("Script Name", EditorStyles.boldLabel);//太字で表示
        _scriptName = EditorGUILayout.TextField(_scriptName);

        if (GUILayout.Button("Generate Script"))
        {
            GenerateScript();
        }
    }

    private void GenerateScript()
    {
        string template =
@"using UnityEngine;

public class #SCRIPTNAME# : MonoBehaviour
{
　　//日本語

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}";

        string scriptContent = template.Replace("#SCRIPTNAME#", _scriptName);
        //パスを指定する
        string filePath = EditorUtility.SaveFilePanel("Save", "Assets", _scriptName, "cs");

        if (!string.IsNullOrEmpty(filePath))
        {
            //指定したパスにファイルを作成してテキストを書き込む
            System.IO.File.WriteAllText(filePath, scriptContent);
            AssetDatabase.Refresh();//エディタ上に反映する
        }
    }
}