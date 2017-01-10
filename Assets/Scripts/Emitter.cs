using UnityEngine;
using System.Collections;
using System;

public class Emitter : MonoBehaviour {

    public GameObject[] waves;

    //private int currentWave;

    // Use this for initialization
    IEnumerator Start() {

        int seed = Environment.TickCount;

        if (waves.Length == 0){
            yield break;
        }

        while (true)
        {
            System.Random cRandom = new System.Random(seed++);
            int currentWave = cRandom.Next(9);

            GameObject wave = (GameObject)Instantiate(waves[currentWave], transform.position, Quaternion.identity);
            wave.transform.parent = transform;

            // Waveの子要素のEnemyが全て削除されるまで待機する
            while (wave.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }
            Destroy(wave);
            Debug.Log("a");


            if (waves.Length <= ++currentWave)
            {
                currentWave = 0;
            }
            // Update is called once per frame

        }
    }
}
