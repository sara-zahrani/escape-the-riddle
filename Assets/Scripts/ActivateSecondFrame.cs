using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSecondFrame : MonoBehaviour
{
    public GameObject mSecondFrame;
    public SoundManager mSoundManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            mSoundManager.PlayFrameButtonSound();
            mSecondFrame.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
