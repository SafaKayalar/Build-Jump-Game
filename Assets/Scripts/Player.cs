using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    SpriteRenderer sprite;
    Animator anim;
    public float jumpspeed = 6.5f;
    public int score;
    public float platformhizi;
    bool touchwall;
    public AudioSource jumpSound;
    public AudioSource walkSound;    
    bool scoreartir;
    bool gamescreen = false;
    public Text playtext;
    public GameObject playpanel;

    public AudioSource runSound;    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        platformhizi = 5f;
        scoreartir = false;    
        playtext.text = ""; 
        playpanel.SetActive(false);
        
    }
    void Update()
    {
        hareket();
        platformhizlandirici();
        GameScreen();
    }

    void hareket()
    {
        if(Input.GetKey(KeyCode.D)&& !touchwall) 
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            sprite.flipX = false;    
            anim.SetFloat("Speed",1f); 
        }
        else if(Input.GetKey(KeyCode.A)&& !touchwall) 
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            sprite.flipX = true;
            anim.SetFloat("Speed",1f); 
        } 
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            anim.SetFloat("Speed",0f); 
        }         
        if(Input.GetKeyDown(KeyCode.W) && rb.velocity.y == 0 && !touchwall)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
            jumpSound.Play();
        }
        if(Input.GetKey(KeyCode.LeftShift) && rb.velocity.y == 0 && !touchwall && rb.velocity.x != 0)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal")  * 1.5f * speed, rb.velocity.y);
            anim.SetFloat("Speed", 2f);
        }
        if (rb.velocity.y != 0)
        {
            anim.SetBool("IsJumped", true);
        }
        else
        {
            anim.SetBool("IsJumped", false);
        }
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Score Area"))
        {
            score ++;
            Destroy(collision.gameObject);
        }
        
        if(collision.gameObject.CompareTag("Play Area"))
        {
            gamescreen = true;
            playtext.text = "Baslamak icin \"Space\" basiniz"; 
            playpanel.SetActive(true);
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Play Area"))
        {
            gamescreen = false;
            playtext.text = " "; 
            playpanel.SetActive(false); 
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dead"))
        {
            SceneManager.LoadScene("Play Again Menu");
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")) 
        {
            touchwall = false;
        }

    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")) 
        {
            touchwall = true;
        }
    }


    public float platformhizlandirici()
    {
        if(platformhizi <= 10f)
        {
            
            if (score%5 == 0 && score !=0 && scoreartir == false)
            {
                platformhizi += 0.2f;
                scoreartir = true;
            }
            if (score%5 == 1)
            {
                scoreartir = false;
            }
        }
        return platformhizi;
    }
    public void walkingsound()
    {
        walkSound.Play();
        runSound.Stop();
    }
    public void runningsound()
    {
        runSound.Play();
        walkSound.Stop();
    }
    public void seslerisustur()
    {
        walkSound.Stop();
        runSound.Stop();
    }   

    public void GameScreen()
    {
        if(gamescreen == true && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Game");
        }
    }
}






