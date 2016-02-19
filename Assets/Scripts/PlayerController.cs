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

            //Set the bullet spawn point
            Vector3 bulletPos = new Vector3(
                Mathf.Clamp(mousePos.x - transform.position.x, transform.position.x - 0.6f, transform.position.x + 0.6f),
                Mathf.Clamp(mousePos.y - transform.position.y, transform.position.y - 0.6f, transform.position.y + 0.6f),
                0f
                );

            //Set the bullet to face towards the mouse click's point
            float opp = (mousePos.x - transform.position.x);
            float adj = (mousePos.y - transform.position.y);
            float rotateAngle = (180 / Mathf.PI) * Mathf.Atan2(opp, adj);
            Quaternion rotateByAngle = Quaternion.Euler(0, 0, -rotateAngle);

            //Instantiate the bullet
            Rigidbody2D bulletClone;
            bulletClone = Instantiate(bullet, bulletPos, rotateByAngle) as Rigidbody2D;
        }
	}
}