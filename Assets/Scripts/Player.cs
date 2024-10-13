using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    SpriteRenderer sprite;
    Animator anim;
    public float jumpspeed = 6.5f;
    public int score;
    public float platformhizi;
    float platformhizartirici;
    float platformhizartissuresi = 10f;
    bool touchwall;
    public AudioSource jumpSound;
    public AudioSource walkSound;

    public AudioSource runSound;    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        platformhizartirici = 0;
        platformhizi = 5f;
        
    }
    void Update()
    {
        hareket();
        platformhizlandirici();
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Score Area"))
        {
            score ++;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")) 
        {
            touchwall = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")) 
        {
            touchwall = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dead"))
        {
            SceneManager.LoadScene("Play Again Menu");
        }
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
    
    
    
    
    
    
    
    
    public float platformhizlandirici()
    {
        if(platformhizi <= 10f)
        {
            platformhizartirici += Time.deltaTime;
            if (platformhizartirici >= platformhizartissuresi)
            {
                platformhizi += 0.2f;
                platformhizartirici = 0;
            }
        }
        return platformhizi;
    }



}
