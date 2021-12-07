using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceTimer : MonoBehaviour
{
    public float mLevelTimer = 10;
    public AudioClip mTimerSound;
    public float mTimeRemaining = 10f;

    private string mElapsedTimeFormatted;
    private TimeSpan mTimePlaying;
    private AudioSource mAudioSource;


   private void Start()
    {
        ResetTimer();
        mAudioSource = GetComponent<AudioSource>();
    }



    IEnumerator CalculateTime()
    {
        if(mTimeRemaining > 0)
        {
            mTimeRemaining -= Time.deltaTime;
            //mAudioSource.PlayOneShot(mTimerSound);
            mTimePlaying = TimeSpan.FromSeconds(mTimeRemaining);
            yield return null;
        }

        if(mTimeRemaining < 5)
        {
            // play sound 
        }
    }


    public string GetElapsedTime()
    {
        return mTimePlaying.ToString("ss");
    }

    public void ResetTimer()
    {

        mTimeRemaining = mLevelTimer;
        mTimePlaying = TimeSpan.FromSeconds(mTimeRemaining);
        string timePlayingStr = mTimePlaying.ToString("ss");

    }


}
