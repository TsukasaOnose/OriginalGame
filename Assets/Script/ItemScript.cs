using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    [SerializeField] GameObject item; //アイテム
    private GameObject itemCopy; //アイテムカメラで見る為に一時的に生成するアイテムのコピー
    [SerializeField] float d = 1f; //持ったアイテムのカメラからの距離
    [SerializeField] float armLength = 4f; //掴める距離（Rayを飛ばす距離）
    [SerializeField] GameObject cameraManager;

    RaycastHit hit;
    //クリックしたアイテムを見る場所
    Vector3 itemPickUpPosition;
    //アイテムを掴んでいるかどうか
    public bool hold = false;
    //アイテムを落とす位置
    private Vector3 dumpPos;


    private void Start()
    {
        dumpPos = GameObject.Find("Player").transform.position;
        itemPickUpPosition = GameObject.Find("ItemPickUpPosition").transform.position;
        cameraManager = GameObject.Find("Camera Manager");
    }

    // Update is called once per frame
    void Update()
    {
        //クリックでアイテムを置く
        if (Input.GetMouseButtonDown(0))
        {
            //アイテムを掴んでいる時
            if (hold == true && item != null)
            {
                //持ってない状態にする
                hold = false;
                //所持アイテムの情報を空にする
                item = null;
                //アイテムコピーを破棄
                Destroy(itemCopy);
                //カメラを1人称視点に戻す
                cameraManager.GetComponent<CameraChange>().ShowFirstPersonCamera();
                return;
            }

            //アイテムを掴んでいない時
            if (hold == false)
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit, armLength))
                {
                    if (hit.collider.tag == "ItemTag")
                    {
                        //変数にアイテムの情報を代入
                        item = hit.collider.gameObject;
                        //アイテムのコピー作成
                        itemCopy = Object.Instantiate(item);
                        //アイテムコピーをアイテムカメラの前に生成
                        itemCopy.transform.position = itemPickUpPosition;
                        //アイテムを持っている状態にする
                        hold = true;
                        //カメラをアイテム画面に移す
                        cameraManager.GetComponent<CameraChange>().ShowItemCamera();
                    }
                }
            }

        }
    }
}