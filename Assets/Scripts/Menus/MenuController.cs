using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public MenuType mMenuType;
    public GameManager mGameManager;
    public MenuManager mMenuManager;

    public virtual void Start()
    {
        mMenuManager = GetComponentInParent<MenuManager>();

        if(mMenuType != MenuType.MainMenu && mMenuType != MenuType.Instructions)
        {
            mGameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }

    }

    public virtual void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

    public virtual void QuitGame()
    {
        Application.Quit();
    }
}
