using UnityEngine;
using System.Collections;

public class EnemySpawnControl : MonoBehaviour {

    public Rigidbody2D enemyShip;

    Vector2 gameAreaMaxCoor;
    float timeDelay, spawnTime;

	// Use this for initialization
	void Start () {
        gameAreaMaxCoor = new Vector2(6f, 6f);
        timeDelay = 5f;
        spawnTime = 0;
	}
	
	// Update is called once per frame
	void Update () {

        //spawn every 1 second
        if (Time.time >= spawnTime + 1f)
        {
            spawnTime = Time.time;

            //Set the enemy ship spawnPoint on coordinate:
            //(random(-x,x), random.range(-y to y))
            //(random.range(-x to x), random(-y,y))
            Vector2 spawnPoint;
            if (Random.Range(0, 1) == 0)
                spawnPoint = new Vector2(GenRandom(Random.Range(-gameAreaMaxCoor.x, gameAreaMaxCoor.x)), GenRandom(gameAreaMaxCoor.y));
            else
                spawnPoint = new Vector2(GenRandom(gameAreaMaxCoor.x), GenRandom(Random.Range(-gameAreaMaxCoor.y, gameAreaMaxCoor.y)));

            //Set the enemy ship rotation point to player's ship
            float opp = (spawnPoint.x - transform.position.x);
            float adj = (spawnPoint.y - transform.position.y);
            float rotateAngle = (180 / Mathf.PI) * Mathf.Atan2(opp, adj);
            Quaternion spawnRotation = Quaternion.Euler(0, 0, rotateAngle);

            //Instantiate the enemy ship
            Rigidbody2D enemyShipClone = Instantiate(enemyShip, spawnPoint, spawnRotation) as Rigidbody2D;
        }
	}

    float GenRandom (float num)
    {
        float rnd = Random.Range(0, 1);
        if (rnd < 0.51f) return num;
        else return -num;
    }
}
