using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonType
{
    DoorButton,
    FrameButton
};

public class PuzzleButton : MonoBehaviour
{


    public ButtonType mButtonType;
    public  MeshRenderer mBaseRendere;
    public GameManager mGameManager;
    public SoundManager mSoundManager;

    private Color mBaseOrginalColor;


    void Start()
    {
        mBaseOrginalColor = mBaseRendere.material.color;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Change color");
            mBaseRendere.material.SetColor("_Color", Color.blue);

            if(mButtonType == ButtonType.FrameButton)
            {
                mSoundManager.PlayFrameButtonSound();
            }

            
            mGameManager.CheckPuzzle(mButtonType);

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            mBaseRendere.material.SetColor("_Color", mBaseOrginalColor);
        }

    }
}
