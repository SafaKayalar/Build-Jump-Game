using System.Collections;
using System.Collections.Generic;
using EthanTheHero;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Transform transform1;

    void Start()
    {
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
        transform1.position = new Vector2(transform1.position.x - Time.deltaTime * 5f, transform1.position.y); 
    }   
}
