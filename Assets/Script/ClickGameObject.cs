﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickGameObject : MonoBehaviour
{
    //アイテムを入れる変数
    private GameObject item;
    //アイテムを掴める距離（Rayを飛ばす距離）
    private float armLength = 4f;
    //持ったアイテムの距離
    private float d = 1f;
    //LayerがItemの物のみを検出するようにする
    private int layerMask = 1 << 8;
    //アイテムタグ
    public string itemTag = "ItemTag";
    //アイテムを持っているか
    private bool hold = false;
    //アイテムの初期位置
    Vector3 itemPos;
    //アイテムを落とす位置
    private Vector3 dumpPos;

    RaycastHit hit;

    private void Start()
    {
        dumpPos = GameObject.Find("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //カーソルを画面中央に固定する
        Cursor.lockState = CursorLockMode.Locked;
        //クリック時の処理関数を呼び出す
        ClickAction();
    }

    public void ClickAction()
    {
        //カーソルの位置へRayを飛ばす
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //クリックした時
        if (Input.GetMouseButtonDown(0))
        {
            //アイテムを持っている時
            if (item != null && item.CompareTag(itemTag) && hold == true)
            {
                item.transform.position = itemPos;
                hold = false;
                item = null;
                return;
            }

            //Rayが接触したオブジェクトを取得し、ログに表示する
            if (Physics.Raycast(ray, out hit, armLength, layerMask))
            {
                //クリックしたアイテムを取得
                item = hit.collider.gameObject;
                //対象がアイテム且つ、アイテムを持っていない時
                if (item == null && item.CompareTag(itemTag) && hold == false)
                {
                    //アイテムの初期位置を保存
                    itemPos = item.transform.position;

                    //目の前にアイテムを移動
                    Vector3 itemNewPos = transform.position + transform.forward * d;
                    item.transform.position = itemNewPos;

                    //アイテムを持っている状態にする
                    hold = true;

                    Debug.Log(item);
                    Debug.Log("アイテムを持っている");
                }
            }

        }


    }
}
