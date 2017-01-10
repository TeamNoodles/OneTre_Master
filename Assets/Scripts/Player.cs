using UnityEngine;
using System;
using System.Collections;


public enum PlayerState
{
    NORMAL,
    JUMP,
    SLIDING,
    MOVING
}
public class Player : MonoBehaviour {

    private PlayerState pState = PlayerState.NORMAL;
    
    [SerializeField]
    // 1p,2pのキーバインドを設定する
    private string Upkey, LeftKey, DownKey, RightKey;
    // 横方向への移動速度
    public float HorizontalSpeed;
    // 前方への移動速度
    public float VerticalSpeed;
    // レーンの間隔
    public float LaneInterval;
    // 左右に移動中かどうか
    private bool isMoving;

    public float pos = 0;


    private Animator playerAnim;
    private Transform parentTransform;

    [SerializeField,Range(0,4)]
    private byte CurrentLane;
    [SerializeField]
    private byte LaneNum; // レーンの本数

    void Awake()
    {
        playerAnim = this.GetComponent<Animator>();
        parentTransform = this.transform.parent;
        isMoving = false;
        LaneNum = 5;
        CurrentLane = (byte)(LaneNum / 2); 
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager.GameSceneProp != GameScene.PLAY)
            return;

        MoveVertical();


        if (pState == PlayerState.NORMAL)
        {
            if (Input.GetKeyDown((KeyCode)Enum.Parse(typeof(KeyCode), Upkey)))
            {
                OnJumping();
            }
            if (Input.GetKeyDown((KeyCode)Enum.Parse(typeof(KeyCode), RightKey)))
            {
                if (this.CurrentLane < this.LaneNum - 1 && !isMoving)
                {
                    CurrentLane++;
                    MoveHorizontal(1);
                }
            }
            if (Input.GetKeyDown((KeyCode)Enum.Parse(typeof(KeyCode), DownKey)))
            {
                OnSliding();
            }
            if (Input.GetKeyDown((KeyCode)Enum.Parse(typeof(KeyCode), LeftKey)))
            {
                if (this.CurrentLane > 0 && !isMoving)
                {
                    CurrentLane--;
                    MoveHorizontal(-1);
                }
            }
        }
    }
    private void OnJumping()
    {
        pState = PlayerState.JUMP;
        if (!playerAnim.GetBool("isJumping")) 
            this.playerAnim.SetBool("isJumping", true);
    }

    private void OnSliding()
    {
        pState = PlayerState.SLIDING;
        if (!playerAnim.GetBool("isSliding"))
            this.playerAnim.SetBool("isSliding", true);
    }

    /// <summary>
    /// 引数で指定したトリガー名のトリガーを折る
    /// </summary>
    /// <param name="triggerName"></param>
    private void OnAnimationEnd(string triggerName)
    {
        this.playerAnim.SetBool(triggerName, false);
        pState = PlayerState.NORMAL;
    }

    private void MoveVertical()
    {
        Vector3 dir = Vector3.zero;
        dir.z = VerticalSpeed;
        parentTransform.position += dir * Time.deltaTime;
        pos += VerticalSpeed * Time.deltaTime;
    }

    private void MoveHorizontal(float dir)
    {
        pState = PlayerState.MOVING;
        this.isMoving = true;
        StartCoroutine("ChangeLane",dir);
    }

    IEnumerator ChangeLane(float dir)
    {
        float initPosX = this.parentTransform.position.x;
        Vector3 target = new Vector3(this.LaneInterval*dir + initPosX, 0.0f, 0.0f);
        while (isMoving)
        {
            target.z = parentTransform.position.z;
            this.parentTransform.position = Vector3.MoveTowards(this.parentTransform.position, target, Time.deltaTime * HorizontalSpeed);
            yield return new WaitForEndOfFrame();
            if (parentTransform.position.x == target.x)
            {
                print("Moved : " + parentTransform);
                isMoving = false;
            }
        }
        pState = PlayerState.NORMAL;
        yield return 0;
    }

    public byte LaneNumProp{ get { return LaneNum; } }
}
