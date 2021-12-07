using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    GameManager mGameManager;

    private void Awake()
    {
         mGameManager = GameObject.FindGameObjectWithTag("GameManager").
     GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {

        
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("END LEVEL TRIGGER");
            // TODO: check if door animation finihed
            // play sound
            // door animation must open first

            if(mGameManager.mOpenDoor)
            {
                mGameManager.mCurrentGameStatus = GameStatus.EndLevel;
            }
            

        }
    }
}
