using UnityEngine;
using System.Collections;

public enum GameState
{
    TITLE,
    PLAY,
    PAUSE,
    OVER
}
// GameManagerはシングルトンで実装する
public class GameManager : Singleton<GameManager> {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
