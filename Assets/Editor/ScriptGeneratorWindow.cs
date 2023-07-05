using UnityEditor;
using UnityEngine;

public class ScriptGeneratorWindow : EditorWindow
{
    private string _monoBehaviourTemplate =
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

    private string _scriptableObjectTemplate =
@"using UnityEngine;

public class #SCRIPTNAME# : ScriptableObject
{
　　//日本語

}";

    private string _classTemplate =
@"using UnityEngine;

public class #SCRIPTNAME#
{
　　//日本語
}";

    private string _interfaceTemplate =
@"using UnityEngine;

public interface #SCRIPTNAME#
{
　　//日本語
}";

    private string _scriptName = "NewScript";

    private SelectTemplates _selectTemplates = SelectTemplates.MonoBehaviour;


    public enum SelectTemplates
    {
        MonoBehaviour,
        ScriptableObject,
        Class,
        Interface,
    }

    [MenuItem("Test/ScriptGenerator")]
    public static void Window()
    {
        GetWindow<ScriptGeneratorWindow>("ScriptGenerator");//windowを生成
    }

    private void OnGUI()
    {
        _selectTemplates = (SelectTemplates)EditorGUILayout.EnumPopup("SelectTemplates", _selectTemplates);
        GUILayout.Label("Script Name", EditorStyles.boldLabel);//太字で表示
        _scriptName = EditorGUILayout.TextField(_scriptName);

        if (GUILayout.Button("Generate Script"))
        {
            GenerateScript();
        }
    }

    private void GenerateScript()
    {
        string template = "";

        switch (_selectTemplates)
        {
            case SelectTemplates.MonoBehaviour:
                template = _monoBehaviourTemplate;
                break;
            case SelectTemplates.ScriptableObject:
                template = _scriptableObjectTemplate;
                break;
            case SelectTemplates.Class:
                template = _classTemplate;
                break;
            case SelectTemplates.Interface:
                template = _interfaceTemplate;
                break;
        }

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