using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
	[SerializeField]
	string defaultScene = "ArenaOne";

	public GameObject play;
	public GameObject levelSelect;
	public GameObject credits;

	public GameObject secondMenu;

	void Start()
	{
		secondMenu.SetActive(false);
	}

    public void HandlePlayButtonOnClickEvent()
	{
		SceneManager.LoadScene(defaultScene);
	}

	public void HandleLevelSelectButtonOnClickEvent()
	{
		play.SetActive(false);
		levelSelect.SetActive(false);
		credits.SetActive(false);

		secondMenu.SetActive(true);
	}

	public void HandleQuitButtonOnClickEvent()
	{
		Application.Quit();
	}

	public void HandleBackButtonOnClickEvent()
	{
		SceneManager.LoadScene("Main_Menu");
	}

	public void ArenaOne()
	{
		SceneManager.LoadScene("ArenaOne");
	}

	public void ArenaTwo()
	{
		SceneManager.LoadScene("ArenaTwo");
	}

	public void Sandbox()
	{
		SceneManager.LoadScene("Sandbox");
	}
}
