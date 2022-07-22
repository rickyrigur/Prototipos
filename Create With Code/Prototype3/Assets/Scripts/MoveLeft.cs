using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 25;
    private float leftBound = -15;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.startGame)
        {
            if (!playerControllerScript.gameOver)
            {
                if (playerControllerScript.doubleSpeed)
                    speed = 50;
                else if (!playerControllerScript.doubleSpeed)
                    speed = 25;
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }

            //Destroys obstacles that leave the game
            if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
                Destroy(gameObject);
        }                 

        
    }
}
