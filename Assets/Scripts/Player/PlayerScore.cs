using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public Text mScoreUI;
    public int mScore = -1;
    public int mMaximumScore = 200;

    // Start is called before the first frame update
    void Start()
    {
        mScoreUI.text = mScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        mScoreUI.text = mScore.ToString();
    }

    public void AddScore()
    {
        mScore += 200;
        
    }


}
