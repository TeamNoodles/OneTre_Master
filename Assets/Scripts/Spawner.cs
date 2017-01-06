using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] Obstacles;
    [SerializeField]
    private Player TargetPlayer;
    private float laneInterval;
    private float initialPosX;
    private byte LaneNum;


    [SerializeField]
    private float SpawnInterval;

	// Use this for initialization
	void Start () {
        laneInterval = TargetPlayer.LaneInterval;
        initialPosX = TargetPlayer.transform.position.x;
        LaneNum = TargetPlayer.LaneNumProp;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void SpawnObstacle()
    {
        switch (Random.Range(0,Obstacles.Length))
        {

        }
    }
}
