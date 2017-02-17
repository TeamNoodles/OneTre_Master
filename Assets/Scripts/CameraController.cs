using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private Transform Target;
    [SerializeField]
    private Transform CameraPos;
    [SerializeField]
    private Transform ChildCamera;

    [SerializeField]
    // カメラと自機との距離
    public Vector3 Offset;

    // カメラのスイープ速度
    [SerializeField]
    public float SweepSpeed;

	// Use this for initialization
	void Start () {
        StartCoroutine("SweepCamera");
	}
	
	// Update is called once per frame
	void Update () {
        // GameScene.PLAYの時のみ動作
        /*
        if (GameManager.Instance.GameSceneProp != GameScene.PLAY) return;
        this.CameraPos.position = this.Target.position;
        this.ChildCamera.localPosition = Offset;
        */
	}

    IEnumerator SweepCamera()
    {
        while (this.ChildCamera.localPosition != this.Offset)
        {
            this.ChildCamera.localPosition = Vector3.MoveTowards(this.ChildCamera.localPosition, this.Offset, this.SweepSpeed * Time.deltaTime);
            yield return 0;
        }
        print("SweptCamera : " + this.ChildCamera);
        yield break;
    }
}
