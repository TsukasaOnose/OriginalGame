using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    //キャラクターコントローラーの変数
    private CharacterController controller;
    //移動速度
    private float speed = 3.0f;
    //重力
    private float gravity = 10.0f;

    //カメラの横回転の速度
    public float sensitivityX = 2f;

    //取得したアイテムを表示する場所
    public static readonly string IP = "Item Position";

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMove();
        LookX();

        //カーソルを画面中央に固定する
        Cursor.lockState = CursorLockMode.Locked;
    }

    void CharacterMove()
    {
        //左右入力を設定する
        float horizontalInput = Input.GetAxis("Horizontal");
        //上下方向を設定する
        float verticalInput = Input.GetAxis("Vertical");
        //入力した方向へ移動する
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        //移動する速度
        Vector3 velocity = direction * speed;
        velocity = transform.TransformDirection(velocity);
        //常に重力を与える
        velocity.y -= gravity;
        controller.Move(velocity * Time.deltaTime);
    }

    void LookX()
    {
        //マウスで横回転を行う
        float mouseX = Input.GetAxis("Mouse X");
        //現在の向き情報を取得
        Transform myTransform = this.transform;
        //現在の向きをマウスの方向分だけ動かす
        myTransform.Rotate(0, mouseX * sensitivityX, 0);
    }

    //ゴールに着くとシーンを移動する
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GoalTag")
        {
            GameObject.Find(StageController.STR).GetComponent<StageController>().GoHouse();
        }
        else if (other.gameObject.tag == "GoToForestTag")
        {
            GameObject.Find(StageController.STR).GetComponent<StageController>().GoForest();
        }
        else if (other.gameObject.tag == "GoToMainScene")
        {
            GameObject.Find(StageController.STR).GetComponent<StageController>().GoMainScene();
        }
        else if (other.gameObject.tag == "GoToMainSceneNight")
        {
            GameObject.Find(StageController.STR).GetComponent<StageController>().GoNightRoad();
        }
    }
}
