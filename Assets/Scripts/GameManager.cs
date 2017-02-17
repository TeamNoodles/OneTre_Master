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




// GameManagerはシングルトンで実装する
public class GameManager : Singleton<GameManager> {

    
   
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
    

    // Use this for initialization
    void Start () {
        /*
        player1 = GameObject.FindWithTag("Player1");
        player2 = GameObject.FindWithTag("Player2");
        player1Sc = player1.GetComponent<Player>();
        player2Sc = player2.GetComponent<Player>();
        */
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
