using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    public List<GameObject> mShapes = new List<GameObject>();
    //public bool mSpawnRandomShapes;
    //public bool mSpawnShapes;
    public bool mResetShape = false;

    public bool mIsSpawning = false;
    private List<Transform> mShapesLocations = new List<Transform>();
    private int mRandomSpawnCounter = 20;
    private int mSpawnCounter = 20;


    private void Awake()
    {
        foreach(Transform child in transform)
        {
            mShapesLocations.Add(child);
        }

    }

    private void Start()
    {

        // spawning a certain enemy (this is used for another assignment)
        //if(mSpawnRandomShapes)
        //{
        //    Spawn(0, 0);
        //}


    }

    private void Update()
    {

        //if(mSpawnCounter > 0 && mSpawnShapes)
        //{
        //    StartCoroutine("SpawnEnemiesinLocation");
        //    mSpawnCounter--;
        //    mSpawnShapes = false;
        //}
        

        if (mRandomSpawnCounter > 0 && !mIsSpawning)
        {
            //for (int i = 0; i < mShapesLocations.Count; i++)
            //{
            StartCoroutine("SpawnEnemiesRandomly");
            //}
            mIsSpawning = true;

            mRandomSpawnCounter--;
        }
    }


    IEnumerator SpawnEnemiesRandomly()
    {
        yield return new WaitForSeconds(2);

        int randomIdex = UnityEngine.Random.Range(0, mShapes.Count);
        int randomIdexLoc = UnityEngine.Random.Range(0, mShapesLocations.Count);


        Spawn(randomIdex, randomIdexLoc);

        
    }


    void Spawn(int enemyIndex, int locationIndex)
    {
        Instantiate(mShapes[enemyIndex],
            mShapesLocations[locationIndex].transform.position,
            mShapesLocations[locationIndex].transform.rotation);
    }

}
