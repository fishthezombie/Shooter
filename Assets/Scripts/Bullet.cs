using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

        //Move the bullet by speed based on local axis
        transform.position += transform.up * Time.deltaTime * 15f;
	}
}
