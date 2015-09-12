using UnityEngine;
using System.Collections;

public class PlayerKilledScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log("ow");
        if (c.gameObject.tag == "EnemyBullet")
        {
            PlayerMotion pm = GetComponent<PlayerMotion>();
            pm.dead = true;

        }

    }
}
