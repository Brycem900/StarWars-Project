using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class LevelSelection : ButtonSelection<Object>
{
    override protected GameObject CreateButton(Object scene)
    {
        var obj = base.CreateButton(scene);
        var pathToScene = AssetDatabase.GetAssetPath(scene);
 		var actualScene = new EditorBuildSettingsScene(pathToScene, true);
        obj.transform.GetChild(0).GetComponent<Text>().text = GetNameByPath(actualScene.path);

        return obj;
    }

    private string GetNameByPath(string path)
    {
        int slash = path.LastIndexOf('/');
        string name = path.Substring(slash + 1);
        int dot = name.LastIndexOf('.');
        return name.Substring(0, dot);
    }
}
