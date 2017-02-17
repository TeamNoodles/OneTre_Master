using UnityEngine;
using System.Collections;
using System;

public class Emitter : MonoBehaviour
{

    public GameObject[] waves;
    public GameObject Obstacle_Up;
    public GameObject Obstacle_Down;
    [SerializeField]
    private Player TargetPlayer;
    private GameManager GameState;

    //private int currentWave;

    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(TargetPlayer.transform.position.x, TargetPlayer.transform.position.y, TargetPlayer.transform.position.z + 3);
    }

    void Update()
    {

    }

    IEnumerator Spawn()
    {

        int seed = Environment.TickCount;

        /*if (waves.Length == 0) {
            yield break;
        }*/


        //while(進んだ距離が０～１２０００){
        System.Random cRandom = new System.Random(seed++);
        int firstselect = cRandom.Next(9);
        if (firstselect <= 2)
        {
            //ビーム撃つ
        }
        else
        {
            int secondselect = cRandom.Next(9);

            if (secondselect <= 2)  //上障生成
            {
                Instantiate(Obstacle_Up, this.transform.position, Obstacle_Up.transform.rotation);
                Obstacle_Up.transform.parent = transform;
                while (Obstacle_Up.transform.childCount != 0)
                {
                    yield return new WaitForEndOfFrame();
                    if (TargetPlayer.transform.position.z - Obstacle_Up.transform.position.z == -20)
                    {
                        Destroy(Obstacle_Up);
                    }
                }
            }
            else if (3 <= secondselect && secondselect <= 4) //下障生成
            {
                Instantiate(Obstacle_Down, this.transform.position, Obstacle_Down.transform.rotation);
                Obstacle_Down.transform.parent = transform;
                while (Obstacle_Down.transform.childCount != 0)
                {
                    yield return new WaitForEndOfFrame();
                    if (TargetPlayer.transform.position.z - Obstacle_Down.transform.position.z == -20)
                    {
                        Destroy(Obstacle_Down);
                    }
                }
            }
            else //球生成
            {
                int currentWave = cRandom.Next(9);

                GameObject wave = (GameObject)Instantiate(waves[currentWave], this.transform.position, Quaternion.identity);
                wave.transform.parent = transform;
                while (wave.transform.childCount != 0)
                {
                    yield return new WaitForEndOfFrame();
                    if (TargetPlayer.transform.position.z - wave.transform.position.z == -20)
                    {
                        Destroy(wave);
                    }
                }
            }
        }
    }
}

