using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ButtonManager : MonoBehaviour
{
	[SerializeField]
	string defaultScene = "ArenaOne";

	public GameObject play;
	public GameObject levelSelect;
	public GameObject playerSelect;
	public GameObject credits;

	public GameObject levelMenu;
	public GameObject characterMenu;

	private CharacterSelection characterSelection;
	private LevelSelection levelSelection;

	void Start()
	{
		characterSelection = characterMenu.GetComponent<CharacterSelection>();
		levelSelection = levelMenu.GetComponent<LevelSelection>();
		levelMenu.SetActive(false);
		characterMenu.SetActive(false);
	}

    public void HandlePlayButtonOnClickEvent()
	{
		DontDestroyOnLoad(characterSelection.SelectedItem);
		characterSelection.SelectedItem.name = "Player";
		var pathToScene = AssetDatabase.GetAssetPath(levelSelection.SelectedItem);
 		var scene = new EditorBuildSettingsScene(pathToScene, true);
		SceneManager.LoadScene(scene.path);
	}

	public void HandleLevelSelectButtonOnClickEvent()
	{
		play.SetActive(false);
		levelSelect.SetActive(false);
		playerSelect.SetActive(false);
		credits.SetActive(false);

		levelMenu.SetActive(true);
	}

	public void HandlePlayerSelectButtonOnClickEvent()
	{
		play.SetActive(false);
		levelSelect.SetActive(false);
		playerSelect.SetActive(false);
		credits.SetActive(false);

		characterMenu.SetActive(true);
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

		levelMenu.SetActive(false);
		characterMenu.SetActive(false);
	}
}
