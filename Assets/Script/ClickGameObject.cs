using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickGameObject : MonoBehaviour
{
    //Rayを飛ばす距離
    float maxDistance = 5f;
    //LayerがItemの物のみを検出するようにする
    int layerMask = 1 << 8;
    //クリックしたオブジェクトを入れる変数
    GameObject clickedGameObject;
    //アイテムタグ
    public string itemTag = "ItemTag";
    //アイテムを持っているか
    public bool haveItem = false;

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
        //クリックした時、アイテムを持っていなければアイテムを保持する
        if (Input.GetMouseButton(0))
        {
            clickedGameObject = null;

            //カーソルの位置へRayを飛ばす
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            //Rayが接触したオブジェクトを取得し、ログに表示する
            if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
            {
                clickedGameObject = hit.collider.gameObject;
                if (clickedGameObject.CompareTag(itemTag) && haveItem == false)
                {
                    clickedGameObject.GetComponent<ItemController>().OnUserAction();
                    clickedGameObject.GetComponent<Rigidbody>().useGravity = false;
                    //アイテムを持っている状態にする
                    haveItem = true;

                    Debug.Log(clickedGameObject);
                    Debug.Log("アイテムを持っている");
                }
                else if (clickedGameObject.CompareTag(itemTag) && haveItem == true)
                {
                    clickedGameObject.GetComponent<Rigidbody>().useGravity = true;
                    //アイテムを持っていない状態にする
                    haveItem = false;
                    Debug.Log(clickedGameObject);
                    Debug.Log("アイテムを持っていない");
                }

            }
        }

    }
}
