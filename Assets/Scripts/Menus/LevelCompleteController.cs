using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompleteController : MenuController
{
	public Text mMenuTitle;
	public Button mContinueBtn;


	public override void Start()
	{
		base.Start();

		int currenttSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

		int levelsCount = SceneManager.sceneCountInBuildSettings;

		if (levelsCount == currenttSceneIndex)
		{
			mContinueBtn.gameObject.SetActive(false);
			mMenuTitle.text = "THE END!! YOU WON";
		}
		else
        {
			mContinueBtn.gameObject.SetActive(true);
			mMenuTitle.text = "YOU WON";
		}
	}

    public void ReplayLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		mMenuManager.SwitchMenu(MenuType.GameUI);

	}


	public override void LoadScene(string sceneName)
	{
		base.LoadScene(sceneName);
	}


	public void NextLevel()
    {
		int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

		int levelsCount = SceneManager.sceneCountInBuildSettings - 1; // remove main menu

		if (levelsCount >= nextSceneIndex) 
		{
			SceneManager.LoadScene(nextSceneIndex);
		}


	}


}
