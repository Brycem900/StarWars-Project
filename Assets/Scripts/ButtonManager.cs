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
	public GameObject playerSelect;
	public GameObject credits;

	public GameObject secondMenu;
	public GameObject thirdMenu;

	public GameObject alien;
	public GameObject stormtrooper;
	public GameObject jedi;
	public GameObject droid;

	public GameObject activePlayer;

	void Start()
	{
		secondMenu.SetActive(false);
		thirdMenu.SetActive(false);

	}

    public void HandlePlayButtonOnClickEvent()
	{
		SceneManager.LoadScene(defaultScene);
	}

	public void HandleLevelSelectButtonOnClickEvent()
	{
		play.SetActive(false);
		levelSelect.SetActive(false);
		playerSelect.SetActive(false);
		credits.SetActive(false);

		secondMenu.SetActive(true);
	}

	public void HandlePlayerSelectButtonOnClickEvent()
	{
		play.SetActive(false);
		levelSelect.SetActive(false);
		playerSelect.SetActive(false);
		credits.SetActive(false);

		thirdMenu.SetActive(true);
	}

	public void HandleQuitButtonOnClickEvent()
	{
		Application.Quit();
	}

	public void HandleBackButtonOnClickEvent()
	{
		play.SetActive(true);
		levelSelect.SetActive(true);
		playerSelect.SetActive(true);
		credits.SetActive(true);

		secondMenu.SetActive(false);
		thirdMenu.SetActive(false);
	}

	public void ArenaOne()
	{
		DontDestroyOnLoad(activePlayer);
		SceneManager.LoadScene("ArenaOne");
	}

	public void ArenaTwo()
	{
		DontDestroyOnLoad(activePlayer);
		SceneManager.LoadScene("ArenaTwo");
	}

	public void Sandbox()
	{
		DontDestroyOnLoad(activePlayer);
		SceneManager.LoadScene("Sandbox");
	}

	public void alienSelect()
	{
		var position = activePlayer.transform.position;
		Destroy(activePlayer);
		activePlayer = Instantiate<GameObject>(alien);
		activePlayer.transform.position = position;
		
	}

	public void stormtrooperSelect()
	{
		var position = activePlayer.transform.position;
		Destroy(activePlayer);
		activePlayer = Instantiate<GameObject>(stormtrooper);
		activePlayer.transform.position = position;
	}

	public void droidSelect()
	{
		var position = activePlayer.transform.position;
		Destroy(activePlayer);
		activePlayer = Instantiate<GameObject>(droid);
		activePlayer.transform.position = position;
	}

	public void jediSelect()
	{
		var position = activePlayer.transform.position;
		Destroy(activePlayer);
		activePlayer = Instantiate<GameObject>(jedi);
		activePlayer.transform.position = position;
	}
}
