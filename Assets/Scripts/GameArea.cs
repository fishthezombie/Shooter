using UnityEngine;
using System.Collections;

public class GameArea : MonoBehaviour {

    //Detect collider's trigger
    void OnTriggerExit2D(Collider2D checkObject)
    {
        //Check if the object is tagged as "PlayerBullet"
        if (checkObject.CompareTag("PlayerBullet") || checkObject.CompareTag("Enemy"))
        {
            //Destroy object
            Destroy(checkObject.gameObject);
        }
    }
}
