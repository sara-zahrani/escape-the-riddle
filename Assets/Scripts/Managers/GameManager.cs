using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStatus
{
	StartGame,
	PauseGame,
	EndLevel,
	EndGame,
	LostGame
}

public class GameManager : MonoBehaviour
{

	public RaceTimer mRaceTimer;
	public MenuManager mMenuManager;
	public GameStatus mCurrentGameStatus;
    public List<GameObject> mFrames = new List<GameObject>();
    public Transform mFramesParent;
    public GameObject mCurrentFrame;
    public Animator mDoorAnim;
    public Transform mParticleLocation;
    public GameObject mParticlePrefab;
    public SoundManager mSoundManager;

    ButtonType mButtonType;
    int activeFrameIndex;
    int desiredFrameIndex;
    public bool mOpenDoor;



    //====================================================================================================


    void Awake()
	{

		mCurrentGameStatus = GameStatus.StartGame;

        foreach (Transform child in mFramesParent)
        {
            mFrames.Add(child.gameObject);
        }
       



    }

	private void Start()
    {

		mRaceTimer = GameObject.FindGameObjectWithTag("Timer").GetComponent<RaceTimer>();
		mMenuManager = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>();


        if (mRaceTimer != null)
        {
            mRaceTimer.ResetTimer();
        }


        Time.timeScale = 1;

        for (int i = 0; i < mFrames.Count; i++)
        {
            if (mFrames[i].activeInHierarchy)
            {
                mCurrentFrame = mFrames[i];
                activeFrameIndex = i;
            }

            desiredFrameIndex = activeFrameIndex;
        }

    }

    void Update()
	{
        if (mRaceTimer.mTimeRemaining <= 0)
        {
            mCurrentGameStatus = GameStatus.LostGame;
        }

        if (mCurrentGameStatus == GameStatus.StartGame)
		{
			Time.timeScale = 1;
            mRaceTimer.StartCoroutine("CalculateTime");
			Debug.Log("Status START Game");
		}

		else if (mCurrentGameStatus == GameStatus.EndLevel)
		{
			Time.timeScale = 0;
            mRaceTimer.StopCoroutine("CalculateTime");
            mRaceTimer.ResetTimer();
            Debug.Log("Status END LEVEL");

			mMenuManager.SwitchMenu(MenuType.LevelCompleteMenu);
		}
		else if (mCurrentGameStatus == GameStatus.PauseGame)
		{
			Time.timeScale = 0;
			Debug.Log("Status PAUSE Game");

		}
		else if (mCurrentGameStatus == GameStatus.EndGame)
		{
			Time.timeScale = 0;
			//  Won the game back to main menu 

		}
		else if(mCurrentGameStatus == GameStatus.LostGame)
        {
			Time.timeScale = 0;
            mRaceTimer.StopCoroutine("CalculateTime");
            mRaceTimer.ResetTimer();
            Debug.Log("LOST GAME");

			mMenuManager.SwitchMenu(MenuType.LostGame);
		}

	}

	public void CheckPuzzle(ButtonType btnType)
    {

        if (btnType == ButtonType.DoorButton)
        {
            if(mCurrentFrame != null)
            {
                if (mCurrentFrame.tag == "Map")
                {
                    mOpenDoor = true;

                    Instantiate(mParticlePrefab, mParticleLocation.position, mParticleLocation.rotation);
                    mDoorAnim.SetTrigger("OpenDoor");
                    mSoundManager.PlayOpenDoorSound();
                    mSoundManager.PlayWinButtonSound();
                }
                else
                {
                    mSoundManager.PlayLoseButtonSound();
                }
            }
            else
            {
                mSoundManager.PlayLoseButtonSound();
            }


        }

        if (btnType == ButtonType.FrameButton)
        {

            if (desiredFrameIndex < mFrames.Count - 1)
            {
                desiredFrameIndex++;
                Debug.Log("current frame index" + desiredFrameIndex);
            }
            else
            {
                desiredFrameIndex = 0;
            }


            for (int i = 0; i < mFrames.Count; i++)
            {

                mFrames[desiredFrameIndex].SetActive(true);
                mCurrentFrame = mFrames[desiredFrameIndex];
                if (i != desiredFrameIndex)
                {
                    mFrames[i].SetActive(false);
                }

            }
        }
    }
	
}
