using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
    public int mRotateSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, mRotateSpeed, 0) * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {

        PlayerScore ps = other.gameObject.GetComponent<PlayerScore>();

        if (ps != null)
        {
            ps.AddScore();
            Destroy(this.gameObject);

        }

    }
}
