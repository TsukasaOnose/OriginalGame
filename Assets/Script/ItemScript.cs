using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    [SerializeField] GameObject item; //アイテム
    [SerializeField] float d = 1f; //持ったアイテムのカメラからの距離
    [SerializeField] float armLength = 4f; //掴める距離（Rayを飛ばす距離）

    RaycastHit hit;
    Vector3 itemPos; //アイテムのデフォルト位置
    bool hold = false; //アイテムを持ち上げているかどうか

    // Update is called once per frame
    void Update()
    {
        //アイテムを持ち上げている時
        if (hold == true)
        {
            //Eキーでアイテムを置く
            if(Input.GetMouseButtonDown(0))
            {
                //デフォルトの位置に戻す
                item.transform.position = itemPos;

                hold = false;
                Pause(); //カメラのロックを解除
            }
        }
        //アイテムを持ち上げていない時
        else if (hold == false)
        {
            if (Physics.Raycast(transform.position,transform.forward, out hit, armLength))
            {
                if(hit.collider.tag == "ItemTag")
                {
                    //Eキーでアイテムを持ち上げる
                    if (Input.GetMouseButtonDown(0))
                    {
                        item = hit.collider.gameObject;

                        //アイテムの位置を保存
                        itemPos = item.transform.position;

                        //目の前にアイテムを移動
                        Vector3 itemNewPos = transform.position + transform.forward * d;
                        item.transform.position = itemNewPos;

                        hold = true; //アイテムを持ち上げる
                        Pause(); //カメラをロック
                    }
                }
            }
        }
    }

    public static void Pause()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
}
