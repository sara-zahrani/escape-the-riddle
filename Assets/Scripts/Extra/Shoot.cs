using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public int mShootingVelocity;
    public GameObject mBomb;
    public Transform mSpwanPoint;

    private bool mCanSpawn = true;
    private Rigidbody mBombRB;


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && mCanSpawn)
        {
            mCanSpawn = false;
            ShootBomb();
        }

        if(Input.GetButtonUp("Fire1"))
        {
            mCanSpawn = true;
        }
    }


    public void ShootBomb()
    {
        GameObject Bomb = Instantiate(mBomb, mSpwanPoint.position, mSpwanPoint.rotation);

        Bomb.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, mShootingVelocity, 0));
    }

    public void SetCanSpawn(bool canSpawn)
    {
        mCanSpawn = canSpawn;
    }

    public bool GetCanSpawn()
    {
        return mCanSpawn;
    }

}

