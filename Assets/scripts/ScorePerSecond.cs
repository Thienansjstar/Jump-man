using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePerSecond : MonoBehaviour
{
   
    public Text scoreText;
    public float scoreAmount;
    public float pointIncreasePerSecond;
    
    void Start()
    {
        scoreAmount = 0f;
        pointIncreasePerSecond = 6.78f;
    }

    public void Update()
    {
        if (GameManager.gameOver == false)
        {
            scoreText.text = "Score: " + (int)scoreAmount;
            scoreAmount += pointIncreasePerSecond * Time.deltaTime;
        }

    }

 
}
