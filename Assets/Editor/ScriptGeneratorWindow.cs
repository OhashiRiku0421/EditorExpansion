using UnityEditor;
using UnityEngine;

public class ScriptGeneratorWindow : EditorWindow
{
    private string _monoBehaviourTemplate =
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

    private string _scriptableObjectTemplate =
@"using UnityEngine;

public class #SCRIPTNAME# : ScriptableObject
{
�@�@//���{��

}";

    private string _classTemplate =
@"using UnityEngine;

public class #SCRIPTNAME#
{
�@�@//���{��
}";

    private string _interfaceTemplate =
@"using UnityEngine;

public interface #SCRIPTNAME#
{
�@�@//���{��
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
        GetWindow<ScriptGeneratorWindow>("ScriptGenerator");//window�𐶐�
    }

    private void OnGUI()
    {
        _selectTemplates = (SelectTemplates)EditorGUILayout.EnumPopup("SelectTemplates", _selectTemplates);
        GUILayout.Label("Script Name", EditorStyles.boldLabel);//�����ŕ\��
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