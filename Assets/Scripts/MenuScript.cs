using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public void playGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//gets current scene layer plus 1
    }

    public void quitGame(){
        Debug.Log("Quit!");//test if app quits
        Application.Quit();//happens in real app but not in unity
    }
}
