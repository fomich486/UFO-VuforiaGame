using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForTarget : MonoBehaviour {
    //Wait until user find target and spawn player prefab in center of target
    [SerializeField]
    BoxCollider meshColl;
    [SerializeField]
    CowSpawner cowSpawner;
    bool gameStarted = false;
    private void Update()
    {
        if (meshColl.enabled && !gameStarted)
        {
            ObjectPool.Instance.GetFromPool("Level", Vector3.zero, Quaternion.identity);
            ObjectPool.Instance.GetFromPool("UFO", Vector3.zero, Quaternion.identity);
            ObjectPool.Instance.GetFromPool("Bomb", Vector3.zero, Quaternion.identity);
            for (int i = 0; i < 10; i++)
            {
                ObjectPool.Instance.GetFromPool("Cow", Vector3.zero, Quaternion.identity);
            }
            cowSpawner.enabled = true;
            gameStarted = true;
          
        }
        else if (gameStarted && !meshColl.enabled)
        {
            Score.Instance.GameOver("Target Lost. Restart?");
            this.enabled = false;
        }
    }
}
