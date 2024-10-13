using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using JetBrains.Annotations;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject platform;
    float spawnsuresi = 3f;
    float spawnlayici;
    


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawner();
    }
    void spawner()
    {
        spawnlayici += Time.deltaTime;
        if(spawnlayici >= spawnsuresi)
        {
            Instantiate(platform, new Vector2(19,Random.Range(-5,3)), transform.rotation);       
            spawnlayici = 0;
        }
    }

}
