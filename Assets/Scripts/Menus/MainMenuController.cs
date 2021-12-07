using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MenuController
{

    public override void LoadScene(string sceneName)
    {
        base.LoadScene(sceneName);
        mMenuManager.SwitchMenu(MenuType.GameUI);
    }


    public void Instructions()
    {
        mMenuManager.SwitchMenu(MenuType.Instructions);
    }
}
