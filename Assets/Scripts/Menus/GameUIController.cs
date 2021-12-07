using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MenuController
{
    public Text mTimerText;

    public void PauseGame()
    {

        Debug.Log("pause the game");
        mMenuManager.SwitchMenu(MenuType.PauseMenu);

        if(mGameManager != null)
        {
            mGameManager.mCurrentGameStatus = GameStatus.PauseGame;
        }
        else
        {
            Debug.LogError("Game Manager is NULL");
        }
    }

    private void Update()
    {
        if(mGameManager != null)
        {
            if (mGameManager.mCurrentGameStatus == GameStatus.StartGame)
            {
                // ADD CODE HERE FOR GAME UI UPDATES
                mTimerText.text = mGameManager.mRaceTimer.GetElapsedTime();
            }
        }
        else
        {
            Debug.LogError("Game Manager is NULL");
        }

    }
}
