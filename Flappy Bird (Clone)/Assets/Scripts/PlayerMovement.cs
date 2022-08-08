using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpSpeed = 3f;
    [SerializeField] private float touchJumpSpeed = 600f;
    [SerializeField] private GameObject deathScreen; 
    [SerializeField] private AudioSource dieAudioSource;
    [SerializeField] private AudioSource jumpAudioSource;
    [SerializeField] private AudioSource scoringAudioSource;

    private Rigidbody2D rb2d;

    public bool isDead;
    public GameManager gameManager;

    private void Start()
    {
        Time.timeScale = 1f;
        rb2d = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        BirdJump();
    }

    private void BirdJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = Vector2.up * jumpSpeed;
            jumpAudioSource.Play();
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            rb2d.AddForce(new Vector2(0f, touchJumpSpeed), ForceMode2D.Force);
            jumpAudioSource.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Obstacle")
        {
            isDead = true;
            dieAudioSource.Play();
            Time.timeScale = 0f; //pause the game
            deathScreen.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Scoring")
        {
            gameManager.IncreaseScore();
            scoringAudioSource.Play();
        }
    }

}
