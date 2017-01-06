using UnityEngine;
using System.Collections;

public class FloorController : MonoBehaviour {

    // 床1枚の長さ
    private float width;
    [SerializeField]
    // 使用する床の枚数
    private int PartsNum;
    // 床の長さの合計
    private float totalLength;

    [SerializeField]
    // 床生成の基準となるカメラの座標
    private Transform targetCam;
    // この床の位置
    private Vector3 floorPos;

    void Awake()
    {
        width = gameObject.GetComponent<Renderer>().bounds.size.z;
        totalLength = width * PartsNum;
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        floorPos = this.transform.position;

        if (floorPos.z + totalLength / 4.0f < targetCam.position.z)
        {
            floorPos.z += totalLength;
            this.transform.position = floorPos;
        }
	}
}
