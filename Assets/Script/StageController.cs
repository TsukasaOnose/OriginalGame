using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    [Header("プレイヤーオブジェクト")] public GameObject playerObj;
    [Header("スタート地点")] public GameObject startPosition;
    public static readonly string STR = "Stage Controller";

    // Start is called before the first frame update
    void Start()
    {
        if (playerObj !=null && startPosition != null )
        {
            playerObj.transform.position = startPosition.transform.position;
            playerObj.transform.Rotate(0, 90, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScene()
    {
        //SampleSceneを読み込む
        SceneManager.LoadScene("InMyHouse");
    }
}
