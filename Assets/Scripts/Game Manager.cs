using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoretext;
    
    
    void Start()
    {
        player.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = player.score.ToString();
    }


    public void play()
    {
        SceneManager.LoadScene("Game");
    }
    public void quit()
    {
        Application.Quit();
    }
}
