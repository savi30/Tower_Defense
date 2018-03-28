using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public static bool gameIsOver;
    public GameObject gameOverUI;

    public string nextLevelName = "Level2";
    public int levelToReach = 2;

    public SceneFader sceneFader;

	// Use this for initialization
	void Start () {

        gameIsOver = false;

	}
	
	// Update is called once per frame
	void Update () {

        if (gameIsOver)
            return;

        if (Input.GetKeyDown(KeyCode.E))
            EndGame();

        if(PlayerStats.lives<=0)
        {
            EndGame();
        }

	}

    void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);

    
    }

    public void WinLevel()
    {
        Debug.Log("level won");
        PlayerPrefs.SetInt("levelReached", levelToReach);
        sceneFader.FadeTo(nextLevelName);
    }

}
