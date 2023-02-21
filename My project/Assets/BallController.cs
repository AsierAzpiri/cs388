using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rb;

    public float initSpeedX = 5.0f; 
    float speedX = 5.0f;

    float speedY = 0.0f;
    public float speedIncreasePerd = .5f;

    public GameObject gameManager;
    GameScriptManager gMgr;

    bool active;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        speedY = Random.Range(-5.0f, 5.0f);

        gMgr = gameManager.GetComponent<GameScriptManager>();
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
            rb.velocity = Vector3.left * speedX + Vector3.up * speedY;
    }

    public void stopBall()
    {
        active = false;
        transform.position = new Vector3(0, 0, 0);
        rb.velocity = new Vector3(0, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player_1" || collision.gameObject.name == "Player_2")
            speedX = -1f * (speedX + speedIncreasePerd);
        else if (collision.gameObject.name == "Up_Trigger" || collision.gameObject.name == "Down_Trigger")
            speedY = -1f * (speedY + speedIncreasePerd);
        //Debug.Log("Collision Enter: " + collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collided");
        if (speedX > 0f)
        {
            gMgr.AddScore(true);
            transform.position = new Vector3(0, 0, 0);
            speedX = initSpeedX;
        }
        else
        {
            gMgr.AddScore(false);
            transform.position = new Vector3(0, 0, 0);
            speedX = -initSpeedX;
        }
    }
}
