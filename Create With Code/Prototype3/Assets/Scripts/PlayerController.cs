using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    private bool doubleJump;
    public bool doubleSpeed;
    private int score;
    private float timer;
    public bool startGame;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        doubleJump = false;
        doubleSpeed = false;
        score = 0;
        timer = 0;
        startGame = true;
        playerAnim.speed = 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
            StartGame();
        else if (!startGame)
        {
            if (!gameOver)
                timer += Time.deltaTime;
            if (doubleSpeed)
            {
                if (timer >= 0.5f)
                {
                    IncreaseScore();
                }
                playerAnim.speed = 2;
            }
            else if (!doubleSpeed)
            {
                if (timer >= 1f)
                {
                    IncreaseScore();
                }
                playerAnim.speed = 1;
            }

            if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
            {
                if (doubleJump)
                {
                    isOnGround = false;
                    playerRb.mass = 40;
                }
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                playerAnim.SetTrigger("Jump_trig");
                dirtParticle.Stop();
                playerAudio.PlayOneShot(jumpSound, 1.0f);
                doubleJump = true;
            }
            if (Input.GetKeyDown(KeyCode.Z) && !gameOver)
            {
                doubleSpeed = !doubleSpeed;
            }
        }        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            doubleJump = false;
            playerRb.mass = 20;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            doubleSpeed = false;
        }
    }

    private void IncreaseScore ()
    {
        score += 10;
        Debug.Log("Score: " + score);
        timer = 0;
    }

    private void StartGame()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 5);
        if (transform.position.x >= 0)
        {
            playerAnim.speed = 1;
            startGame = false;
        }           
    }
}
