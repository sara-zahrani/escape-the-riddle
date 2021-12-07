using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LostGameMenu : MenuController
{
	public void ReplayLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		mMenuManager.SwitchMenu(MenuType.GameUI);
	}

	public override void LoadScene(string sceneName)
	{
		base.LoadScene(sceneName);
	}

}
