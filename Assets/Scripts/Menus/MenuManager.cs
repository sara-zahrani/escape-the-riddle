using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum MenuType
{
    MainMenu,
    Instructions,
    GameUI,
    PauseMenu,
    LevelCompleteMenu,
    LostGame
}

public class MenuManager : MonoBehaviour
{
    List<MenuController> mMenuControllers;
    MenuController mLastActiveMenu;
    public MenuType mFirstActiveMenu;

    void Awake()
    {
        mMenuControllers = GetComponentsInChildren<MenuController>().ToList();
        mMenuControllers.ForEach(x => x.gameObject.SetActive(false));
        SwitchMenu(mFirstActiveMenu);
    }

    public void SwitchMenu(MenuType type)
    {
        if (mLastActiveMenu != null)
        {
            mLastActiveMenu.gameObject.SetActive(false);
        }

        MenuController desiredMenu = mMenuControllers.Find(x => x.mMenuType == type);

        if (desiredMenu != null)
        {
            desiredMenu.gameObject.SetActive(true);
            mLastActiveMenu = desiredMenu;
        }
        else { Debug.LogWarning("The desired menu was not found!"); }
    }
}














