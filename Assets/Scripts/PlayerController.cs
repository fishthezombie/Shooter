using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float shipSpeed;
    public float areaXMin, areaXMax, areaYMin, areaYMax;
    public Rigidbody2D bullet;
    Rigidbody2D shipRigidbody;

	// Initialization
	void Start () {
        shipRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //Read the X and Y movement input
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        //Move the ship by x and y amount
        shipRigidbody.velocity = new Vector2(moveX * shipSpeed, moveY * shipSpeed);

        //Limit the ship's movement to an area
        shipRigidbody.position = new Vector2(
            Mathf.Clamp(shipRigidbody.position.x, areaXMin, areaXMax),
            Mathf.Clamp(shipRigidbody.position.y, areaYMin, areaYMax)
            );

        //Shoot bullet when left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left click pressed.");
            Rigidbody2D bulletClone;
            bulletClone = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody2D;
        }
	}
}