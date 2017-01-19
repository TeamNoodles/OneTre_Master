using UnityEngine;
using System.Collections;
using System;

public enum GameScene
{
    TITLE,
    GUIDE,
    RENDERING,
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

    
    private GameState gameState = GameState.EASY;
    private GameScene gameScene;
    private GameObject player1;
    private GameObject player2;
    private Player player1Sc;
    private Player player2Sc;

    

    public Player Player1Prop
    {
        get
        {
            return player1Sc;
        }

        set
        {
            player1Sc = value;
        }
    }

    public Player Player2Prop
    {
        get
        {
            return player2Sc;
        }

        set
        {
            player2Sc = value;
        }
    }

    public  GameScene GameSceneProp
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

    public  GameState GameStateProp1
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

   

    public void StateSwitch1(float player1_pos)//ステート変更
    {

        switch (gameState)
        {
            case GameState.EASY:
                if (player1_pos == 120.01f)
                    gameState = GameState.NORMAL;
                break;

            case GameState.NORMAL:
                if (player1_pos == 240.01f)
                    gameState = GameState.HARD;
                break;
        }
    }

    public void StateSwitch2(float player2_pos)
    {
        switch (gameState)
        {
            case GameState.EASY:
                if (player2_pos == 120.01f)
                    gameState= GameState.NORMAL;
                break;

            case GameState.NORMAL:
                if (player2_pos == 240.01f)
                    gameState = GameState.HARD;
                break;
        }

    }
      
    

    // Use this for initialization
    void Start () {

        player1 = GameObject.FindWithTag("Player1");
        player2 = GameObject.FindWithTag("Player2");
        player1Sc = player1.GetComponent<Player>();
        player2Sc = player2.GetComponent<Player>();

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
