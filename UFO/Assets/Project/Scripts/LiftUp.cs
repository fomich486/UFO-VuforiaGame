using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftUp : MonoBehaviour {

	
	void Update () {

        RaycastHit[] hits;
        Vector3 p1 = transform.position;
        Vector3 p2 = new Vector3(transform.position.x,0f,transform.position.z);
        float r = transform.localScale.x / 4;
        hits = Physics.CapsuleCastAll(p1, p2, r, Vector3.down, Vector3.Distance(p1, p2));
        foreach (RaycastHit h in hits)
        {
            if (h.collider.tag == "Cow")
            {
                h.collider.GetComponent<CowController>().lifted = true;
                h.collider.GetComponent<Rigidbody>().velocity = Vector3.up;
            }
            if (h.collider.tag == "Bomb")
            {
                h.collider.GetComponent<CowController>().lifted = true;
                h.collider.GetComponent<Rigidbody>().velocity = Vector3.up * 5f;
            }
        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Cow")
        {
            ObjectPool.Instance.BackinPool("Cow",collision.gameObject);
            ObjectPool.Instance.ParticleSet("CowDestroy", transform.position, Quaternion.identity);
            Score.Instance.SetScore(1);
        }
        if (collision.transform.tag == "Bomb")
        {
            ObjectPool.Instance.BackinPool("Bomb", collision.gameObject);
            ObjectPool.Instance.ParticleSet("CowDestroy", transform.position, Quaternion.identity);
            ObjectPool.Instance.ParticleSet("CowDestroy", transform.position, Quaternion.identity);
            ObjectPool.Instance.ParticleSet("CowDestroy", transform.position, Quaternion.identity);
            Score.Instance.GameOver("Bom Bom! You lost! Restart?");
        }
    }
}
