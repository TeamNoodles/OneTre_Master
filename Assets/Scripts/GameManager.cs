using UnityEngine;
using System.Collections;
using System;

public enum GameScene
{
    TITLE,
    GUIDE,
    PLAY,
    PAUSE,
    RESULT1,
    RESULT2,
}

public enum GameState
{
    EASY,
    NORMAL,
    HARD,
    
    
}
// GameManagerはシングルトンで実装する
public class GameManager : Singleton<GameManager> {

    
    private static GameState gameState;
    private static GameScene gameScene;
    public static float pos;

    public static GameScene GameSceneProp
    {
        get
        {
            return gameScene;
        }
        set
        {
            gameScene = value;
        }
       
    }

    public static GameState GameStateProp
    {
        get
        {
            return gameState;
        }
        set
        {
            gameState = value;
        }

    }

    public  void StateSwitch(float pos)
    {

        switch (gameState)
        {
            case GameState.EASY:
                if (pos == 120.01f)
                    gameState = GameState.NORMAL;
                break;

            case GameState.NORMAL:
                if (pos == 240.01f)
                    gameState = GameState.HARD;
                break;
        }

    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Awake()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }


}
