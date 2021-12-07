using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip mDoorOpen;
    public AudioClip mDoorClose;
    public AudioClip mFrameButton;
    public AudioClip mDoorButtonWinSound;
    public AudioClip mDoorButtonLoseSound;
    public AudioClip mBackgroundMusic;



    private AudioSource mAudioSource;

    private void Start()
    {
        mAudioSource = GetComponent<AudioSource>();
    }

    public void PlayOpenDoorSound()
    {
        mAudioSource.PlayOneShot(mDoorOpen);
    }

    public void PlayCloseDoorSound()
    {
        mAudioSource.PlayOneShot(mDoorClose);
    }

    public void PlayWinButtonSound()
    {
        mAudioSource.PlayOneShot(mDoorButtonWinSound);
    }


    public void PlayLoseButtonSound()
    {
        mAudioSource.PlayOneShot(mDoorButtonLoseSound);
    }


    public void PlayFrameButtonSound()
    {
        mAudioSource.PlayOneShot(mFrameButton);
    }

}
