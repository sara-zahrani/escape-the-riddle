using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyFallingObjects : MonoBehaviour
{
    private GameManager mGameManager;


    private void Awake()
    {
        mGameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Player")
        {
            mGameManager.mCurrentGameStatus = GameStatus.LostGame;
        }
    }
}
