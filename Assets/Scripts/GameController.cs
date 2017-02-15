using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController>
{

    bool isPlayer1Clear;
    bool isPlayer2Clear;


    public void ToPlay()//プレイ画面へ移行
    {

        if (GameManager.Instance.GameSceneProp == GameScene.TITLE)
        {
            GameManager.Instance.GameSceneProp = GameScene.PLAY;
            FadeManager.Instance.LoadScene("Main", 1);
        }
            
        if (GameManager.Instance.GameSceneProp == GameScene.PAUSE)
        {
            GameManager.Instance.GameSceneProp = GameScene.PLAY;
            Time.timeScale = 1.0f;

        }

    }


    public  void ToGuide()//操作説明画面へ移行
    {
        GameManager.Instance.GameSceneProp = GameScene.GUIDE;
    }

    public void ToTitle()//タイトル画面へ移行
    {
        GameManager.Instance.GameSceneProp = GameScene.TITLE;
        FadeManager.Instance.LoadScene("Title", 1);
    }

           

    public void ToPause()//ポーズ画面へ移行
    {
        GameManager.Instance.GameSceneProp = GameScene.PAUSE;
        Time.timeScale = 0.0f;
    }

    public void ToRESULT1()//プレーヤー2のリザルト画面へ移行
    {
        if (isPlayer1Clear)
        {
            GameManager.Instance.GameSceneProp = GameScene.RESULT1;
            FadeManager.Instance.LoadScene("RESULT1", 1);
        }
    }

    public void ToRESULT2()//プレイヤー2のリザルト画面へ移行
    {
        if (isPlayer2Clear)
        {
            GameManager.Instance.GameSceneProp = GameScene.RESULT2;
            FadeManager.Instance.LoadScene("RESULT2", 1);
        }            
    }

    public void Retry()//再び最初からプレイするときプレイ画面へ移行
    {
        GameManager.Instance.GameSceneProp = GameScene.PLAY;
        FadeManager.Instance.LoadScene("Main",2);       
    }

    public void Awake()
    {
        if(this != Instance)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void ClearJudge()//クリア判定
    {
        if(GameManager.Instance.Player1Prop.playerpos <= 500 && GameManager.Instance.Player2Prop.playerpos >= 500)//残り500mの時点でプレイヤー1が先行していたら
        {
            isPlayer1Clear = true;
        }

        if (GameManager.Instance.Player2Prop.playerpos <= 500 && GameManager.Instance.Player1Prop.playerpos >= 500)//残り500mの時点でプレイヤー2が先行していたら
        {
            isPlayer2Clear = true;
        }

    }

      
    // Use this for initialization
    void Start ()
    {      
        isPlayer1Clear = false;
        isPlayer2Clear = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

 
}
