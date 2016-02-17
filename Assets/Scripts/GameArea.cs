using UnityEngine;
using System.Collections;

public class GameArea : MonoBehaviour {
    BoxCollider2D areaCollider;

	// Use this for initialization
	void Start () {
        areaCollider = GetComponent<BoxCollider2D>();
	}
	
	//Detect collider's trigger
    void OnTriggerExit2D(Collider2D checkObject)
    {
        //Check if the object is tagged as "PlayerBullet"
        if (checkObject.CompareTag("PlayerBullet"))
        {
            //Destroy object
            Destroy(checkObject.gameObject);
        }
    }
}
