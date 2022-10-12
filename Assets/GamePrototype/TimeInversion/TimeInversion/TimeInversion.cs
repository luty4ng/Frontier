using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeInversion : MonoBehaviour {
    public Stack<Status> TimeData;
    public SpriteRenderer sr;
    public Animator anim;
    public PlayerController player;
    public Rigidbody2D rb;
    private Status tempStatus;
    [SerializeField] private bool isInversion;
    [SerializeField] private bool keyUp;
    [SerializeField] private bool keyDown;

    private void Start() 
    {
        tempStatus = new Status();
        TimeData = new Stack<Status>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();

    }

    private void SaveData()
    {
        Status status = new Status();
        status.Position = transform.position;
        status.Sprite = sr.sprite;
        status.faceDir = player.faceDir;
        status.Velocity = rb.velocity;
        TimeData.Push(status);
    }

    private Status LoadData()
    {
        if(TimeData.Count > 1)
            return TimeData.Pop();
        else
            return TimeData.Peek();
    }
    
    private void DeployStatus(Status status)
    {
        // 关闭物理引擎， 关闭控制脚本, 关闭动画控制
        anim.enabled = false;
        rb.simulated = false;
        // 执行抛出数据
        transform.position = status.Position;
        sr.sprite = status.Sprite;
        transform.localScale = new Vector3(status.faceDir, 1, 1);
        //rb.velocity = status.Velocity;
    }

    private void FixedUpdate() {
        // 存取和抛出数据
        if(keyDown)
        {
            tempStatus = LoadData();
            if(tempStatus!=null)
                DeployStatus(tempStatus);
        }
        else
        {
            SaveData();
        }

    }

    private void Update() {
        keyDown = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        keyUp = Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift);

        // 开启正常游戏功能
        if(keyUp)
        {
            player.faceDir = tempStatus.faceDir;
            anim.enabled = true;
            rb.simulated = true;

        }
    }
}