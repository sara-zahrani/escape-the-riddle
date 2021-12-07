using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> mEnemies = new List<GameObject>();
    public bool mSpawnRandomEnemies;
    public bool mSpawnEnemies;
    public bool mResetEnemy = false;
    public int mSpawnCounter = 20;


    public List<Transform> mEnemiesLocations = new List<Transform>();
    private int mRandomSpawnCounter = 4;


    private void Awake()
    {
        foreach(Transform child in transform)
        {
            mEnemiesLocations.Add(child);
        }


    }

    private void Start()
    {


    }

    private void Update()
    {

        if(mSpawnCounter > 0 && mSpawnEnemies)
        {
            StartCoroutine("SpawnEnemiesinLocation");
            mSpawnCounter--;
            mSpawnEnemies = false;
        }
        

        if (mRandomSpawnCounter > 0 && mSpawnRandomEnemies)
        {
            //for (int i = 1; i < mEnemiesLocations.Count; i++)
            //{
                StartCoroutine("SpawnEnemiesRandomly");
            //}

            mRandomSpawnCounter--;
            mSpawnRandomEnemies = false;
        }
    }


    IEnumerator SpawnEnemiesRandomly()
    {
        yield return new WaitForSeconds(2);

        int randomIdex = UnityEngine.Random.Range(0, mEnemies.Count);
        int randomIdexLoc = UnityEngine.Random.Range(0, mEnemiesLocations.Count);

        for (int i = 0; i < mEnemiesLocations.Count; i++)
        {
            Spawn(randomIdex, i);
        }

        mSpawnRandomEnemies = true;
    }

    IEnumerator SpawnEnemiesinLocation()
    {

        yield return new WaitForSeconds(2);

        for (int i = 0; i < mEnemiesLocations.Count; i++)
        {
            Spawn(0, i);
        }

        mSpawnEnemies = true;

    }


    void Spawn(int enemyIndex, int locationIndex)
    {
        Instantiate(mEnemies[enemyIndex],
            mEnemiesLocations[locationIndex].position,
            mEnemiesLocations[locationIndex].rotation);
    }

}
