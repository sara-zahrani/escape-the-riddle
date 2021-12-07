using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int mSpeed;
    //public Transform mCamera;
    public int mJumpForce;
    public LayerMask mGroundLayer;
    public Transform mGroundCheck;
    public Shoot mShootBombs;
    public SoundManager mSoundManager;
    public AudioClip mJumpSound;

    private Rigidbody mRigidB;
    private float mFacing;
    private bool mCanJump;
    private bool mCanMove = true;
    private bool mCanGrab = false;
    private GameObject mGrabbedObject;
    private Rigidbody mGrabbedObjRB;
    


    // Start is called before the first frame update
    void Start()
    {
        mRigidB = GetComponent<Rigidbody>();

        // Enabel this mechanic to work
        // if the player has a Trigger BoxCollider attached 
        if(GetComponent<BoxCollider>() != null &&
            GetComponent<BoxCollider>().isTrigger)
        {
            mCanGrab = true;
        }

    }

    // Update is called once per frame
    void Update()
    {

        // Player Movement
        if (mCanMove)
        {
            Move();
        }

        // Player shooting mechanic 
        //if (Input.GetButtonDown("Fire1") && mShootBombs.GetCanSpawn())
        //{
        //    mShootBombs.SetCanSpawn(false);
        //    mShootBombs.ShootBomb();
        //}

        //if (Input.GetButtonUp("Fire1"))
        //{
        //    mShootBombs.SetCanSpawn(true);
        //}

        //// Player drop 
        //if (!mCanGrab && Input.GetButtonDown("Fire2"))
        //{

        //    Drop();
        //}

        //// Player throw 
        //if (!mCanGrab && Input.GetKeyDown(KeyCode.K))
        //{
        //    Drop();
        //    Throw();
        //}


        // Player Jump
        if (Input.GetButtonDown("Jump") && mCanJump)
        {
            Jump();
        }

        bool grounded = Physics.Linecast(
        new Vector3(transform.position.x, transform.position.y,
        transform.position.z),
        mGroundCheck.position,
        mGroundLayer);

        Debug.DrawLine(new Vector3(transform.position.x, transform.position.y,
            transform.position.z),
            mGroundCheck.position,
            Color.red);

        if (grounded)
        {
            mCanJump = true;
        }
        else
        {
            mCanJump = false;
        }

    }

    private void FixedUpdate()
    {
        //mCamera.eulerAngles = new Vector3(0, mCamera.eulerAngles.y, mCamera.eulerAngles.z);
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * mSpeed, 0,
        Input.GetAxis("Vertical") * mSpeed);

        // move the charecter relative to the Camera's direction.
        // So that what's left to the camera is left to the player as well.
        //movement = mCamera.TransformDirection(movement);

        mRigidB.velocity = new Vector3(movement.x, mRigidB.velocity.y, movement.z);

        if (movement.x != 0 && movement.z != 0)
        {
            mFacing = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
        }

        mRigidB.rotation = Quaternion.Euler(0, mFacing, 0);
    }

    void Jump()
    {
        mCanJump = false;
        mRigidB.AddForce(Vector3.up * mJumpForce);
        //mSoundManager.MakeJumpSound();

    }


    void Grab(Collider other)
    {
        mCanGrab = false;
        mGrabbedObject = other.gameObject;
        mGrabbedObjRB =  other.gameObject.GetComponent<Rigidbody>();
        mGrabbedObjRB.isKinematic = true;
        other.gameObject.transform.parent = transform;
    }

    void Drop()
    {
        mCanGrab = true;
        mGrabbedObjRB.isKinematic = false;
        mGrabbedObject.transform.parent = null;

    }

    void Throw()
    {
        mGrabbedObjRB.AddForce(transform.forward * 800);
        mGrabbedObjRB.AddForce(transform.up * 200);
    }

    private IEnumerator Knockback()
    {
        mCanMove = false;
        mRigidB.AddForce(transform.forward * -800);
        mRigidB.AddForce(transform.up * 200);
        GetComponent<PlayerScore>().mScore -= 100;
        yield return new WaitForSeconds(0.6f);
        mCanMove = true;
    }


    // Upon Colliding with NPCs
    private void OnCollisionEnter(Collision col)
    {

        if(col.gameObject.tag == "DeadRubik")
        {
            StartCoroutine("Knockback");
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "DeadCube" && Input.GetButtonDown("Fire1"))
        {
            Grab(other);
        }
    }



}
