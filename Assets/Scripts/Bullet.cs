using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    Rigidbody2D bulletRb;

	// Use this for initialization
	void Start () {
        bulletRb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        //Move the bullet by y speed based on local axis
        bulletRb.velocity = new Vector2(0, 5f);
	}
}
