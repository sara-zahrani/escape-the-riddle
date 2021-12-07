using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MenuController
{
    public void ResumeGame()
    {
        mMenuManager.SwitchMenu(MenuType.GameUI);
        mGameManager.mCurrentGameStatus = GameStatus.StartGame;
    }

    public override void LoadScene(string sceneName)
    {
        base.LoadScene(sceneName);
        //mMenuManager.SwitchMenu(MenuType.MainMenu);


    }
}
