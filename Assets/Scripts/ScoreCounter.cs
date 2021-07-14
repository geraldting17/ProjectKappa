using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter instance;
    public Text scoreText;

    int score = 0;

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

    public void AddPoint(){
        score += 1;
        scoreText.text = "Score: " + score.ToString();
    }

    public void EndGame(){
        scoreText.text = "The End! Score: " + score.ToString();
    }
}
