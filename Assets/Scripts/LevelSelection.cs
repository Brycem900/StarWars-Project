using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : ButtonSelection<string>
{
    override protected GameObject CreateButton(string scene)
    {
        var obj = base.CreateButton(scene);
        obj.transform.GetChild(0).GetComponent<Text>().text = scene;
        return obj;
    }
}
