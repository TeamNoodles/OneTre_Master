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
