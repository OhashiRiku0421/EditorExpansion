using UnityEditor;
using UnityEngine;

public class ScriptGeneratorWindow : EditorWindow
{
    private string _scriptName = "NewScript";

    [MenuItem("Test/ScriptGenerator")]
    public static void Window()
    {
        GetWindow<ScriptGeneratorWindow>("ScriptGenerator");//window�𐶐�
    }

    private void OnGUI()
    {
        GUILayout.Label("Script Name", EditorStyles.boldLabel);//�����ŕ\��
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
�@�@//���{��

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}";

        string scriptContent = template.Replace("#SCRIPTNAME#", _scriptName);
        //�p�X���w�肷��
        string filePath = EditorUtility.SaveFilePanel("Save", "Assets", _scriptName, "cs");

        if (!string.IsNullOrEmpty(filePath))
        {
            //�w�肵���p�X�Ƀt�@�C�����쐬���ăe�L�X�g����������
            System.IO.File.WriteAllText(filePath, scriptContent);
            AssetDatabase.Refresh();//�G�f�B�^��ɔ��f����
        }
    }
}