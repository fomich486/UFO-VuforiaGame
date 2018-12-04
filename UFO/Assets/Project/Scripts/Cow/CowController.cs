using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowController : MonoBehaviour,IOnObjectSpawn {
    public bool lifted = false;
    float nextChangeTime;
    float changeDelay;
    [SerializeField]
    float translateSpeed;
    [SerializeField]
    Transform levelBounds;
    Rigidbody rb;
    void ChangeTimeSetup()
    {
        changeDelay = Random.Range(5f, 10f);
        nextChangeTime = Time.time + changeDelay;
    }

    void Update () {
        if (!lifted)
        {
            rb.velocity = transform.forward * translateSpeed;
            if (Time.time > nextChangeTime)
            {
                ChangeTimeSetup();
                Vector3 newPosition = GetNewPosition();
                transform.LookAt(newPosition);
                translateSpeed = Random.Range(0.5f, 1f);
                //rb.velocity = transform.forward * translateSpeed;
            }
        }
	}

    Vector3 GetNewPosition()
    {
        Vector3 pos;
        float x = Random.Range(-levelBounds.localScale.x/2, levelBounds.localScale.x/2);
        float z = Random.Range(-levelBounds.localScale.z/2, levelBounds.localScale.z/2);
        pos = new Vector3(x, 0f, z);
        return pos;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            lifted = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            lifted = false;
        }
    }

    public void Spawned()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = GetNewPosition();
        transform.LookAt(GetNewPosition());
        ChangeTimeSetup();
    }
}
