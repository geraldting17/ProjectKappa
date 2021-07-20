using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class GameOverScript : MonoBehaviour
{
    public static GameOverScript instance;

    public TextMeshProUGUI GameOverScoreText;//public = [SerializeField] private

    public void GameOverScore(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameOverScoreText.text = "Game Over! Your Score is " + ScoreCounter.score.ToString(); 
    }

    public void replayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void quitGame(){
            Debug.Log("Quit!");//test if app quits
            Application.Quit();//happens in real app but not in unity
        }
}
