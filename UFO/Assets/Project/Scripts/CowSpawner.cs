using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowSpawner : MonoBehaviour {

    float nextChangeTime;
    float changeDelay;
    void ChangeTimeSetup()
    {
        changeDelay = Random.Range(30f, 60f);
        nextChangeTime = Time.time + changeDelay;
    }
    void Start () {
        ChangeTimeSetup();
	}
	

	void Update () {
        if (Time.time > nextChangeTime)
        {
            ObjectPool.Instance.GetFromPool("Cow", Vector3.zero, Quaternion.identity);
            ObjectPool.Instance.GetFromPool("Bomb", Vector3.zero, Quaternion.identity);
            ChangeTimeSetup();
        }
	}
}
