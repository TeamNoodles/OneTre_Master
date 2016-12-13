using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private Transform Target;
    [SerializeField]
    private Transform CameraPos;

    [SerializeField]
    // カメラと自機との距離
    public Vector3 Offset;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        this.CameraPos.position = this.Target.position;
        this.transform.localPosition = Offset;
	}
}
