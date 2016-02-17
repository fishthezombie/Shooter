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

        //Event when left click is pressed
        if (Input.GetMouseButtonDown(0))
        {
            //Get the mouse position on world point
            Vector3 mousePos = new Vector3(
                Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                0f
                );

            Debug.Log("x: " + mousePos.x + " y: " + mousePos.y);

            //Set the bullet spawn point
            Vector3 bulletPos = new Vector3(
                Mathf.Clamp(mousePos.x - transform.position.x, transform.position.x - 0.6f, transform.position.x + 0.6f),
                Mathf.Clamp(mousePos.y - transform.position.y, transform.position.y - 0.6f, transform.position.y + 0.6f),
                0f
                );

            //Set the bullet to face towards the mouse click's point
            float opp = Mathf.Abs(transform.position.x - mousePos.x);
            float adj = Mathf.Abs(transform.position.y - mousePos.y);
            float rotationAngle = Mathf.Atan2(opp, adj);

            //Instantiate the bullet
            Rigidbody2D bulletClone;
            bulletClone = Instantiate(bullet, bulletPos, Quaternion.Euler(0f,0f,rotationAngle)) as Rigidbody2D;
        }
	}
}