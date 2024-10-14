using System.Collections;
using System.Collections.Generic;
using EthanTheHero;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Transform transform1;
    private Player player;
    void Start() 
    {
        // Player tag'ine sahip GameObject'i bul
        GameObject playerObject = GameObject.FindWithTag("player");

        // Eğer playerObject null değilse
        if (playerObject != null)
        {
            // Player bileşenini al
            player = playerObject.GetComponent<Player>();
        }
        transform1 = GetComponent<Transform>();
        Destroy(gameObject,10);  
    }

    // Update is called once per frame
    void Update()
    {
        platformmove();
    }
    void platformmove()
    {
        transform1.position = new Vector2(transform1.position.x - Time.deltaTime * player.platformhizlandirici(), transform1.position.y); 
    }   
} 
