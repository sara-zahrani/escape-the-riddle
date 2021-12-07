using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsMenu : MenuController
{

    public void Back()
    {
        mMenuManager.SwitchMenu(MenuType.MainMenu);
    }

}
