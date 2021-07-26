using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter instance;
    public Text scoreText;

    public static int score = 0;    

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Start! Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void resetScore(){
        score = 0;
    }
    public void AddPoint(){
        score += 1;
        scoreText.text = "Score: " + score.ToString();
    }

    public void EndGame(){
        scoreText.text = "The End! Score: " + score.ToString();
    }

    public int returnScore(){
        return score;
    }

    
}
