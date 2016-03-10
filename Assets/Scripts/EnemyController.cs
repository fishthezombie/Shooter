using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    void Update()
    {
        //Move the bullet by speed based on local axis
        transform.position += transform.up * Time.deltaTime * 5f;
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.CompareTag("PlayerBullet"))
        {
            Destroy(this.gameObject);
        }
    }
}
