using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMainMenu : MonoBehaviour
{
    public static readonly string MAIN_MENU_SCENE = "Main_Menu";

    void Awake()
    {
        Cursor.visible = true;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU_SCENE);
    }
}
