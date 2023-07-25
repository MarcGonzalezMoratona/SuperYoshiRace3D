using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int level;
    
    // Start is called before the first frame update
    void Start() {
        level = 0;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)){
            SceneManager.LoadScene("MainMenu");
        }
        if (SceneManager.GetActiveScene().name == "LEVEL1") level = 1;
        else if (SceneManager.GetActiveScene().name == "LEVEL2") level = 2;
        else if (SceneManager.GetActiveScene().name == "LEVEL3") level = 3;
        else if (SceneManager.GetActiveScene().name == "LEVEL4") level = 4;
        else if (SceneManager.GetActiveScene().name == "LEVEL5") level = 5;
        else if (SceneManager.GetActiveScene().name == "LEVEL6") level = 6;
        else level = 0;
        if ((Player1.isWinner() || Player2.isWinner()) && SceneManager.GetActiveScene().name != "DANCE") SceneManager.LoadScene("DANCE");
    }

    public void SelectScreen(string screenName){
        SceneManager.LoadScene(screenName);
        Player1.setIsWinner(false);
        Player2.setIsWinner(false);
    }

    public void Quit() {
        Application.Quit();
    }
}
