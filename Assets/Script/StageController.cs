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
        if (playerObj != null && startPosition != null)
        {
            playerObj.transform.position = startPosition.transform.position;
            playerObj.transform.Rotate(0, 90, 0);
        }
    }


    public void GoHouse()
    {
        //SampleSceneを読み込む
        SceneManager.LoadScene("InMyHouse");
    }
    public void GoForest()
    {
        //InForestを読み込む
        SceneManager.LoadScene("InForest");
    }
    public void GoMainScene()
    {
        //SampleSceneを読み込む
        SceneManager.LoadScene("MainScene");
    }
    public void GoNightRoad()
    {
        //NightRoadを読み込む
        SceneManager.LoadScene("NightRoad");
    }
    public void Loading()
    {
        //Load1を読み込む
        SceneManager.LoadScene("Load1");
    }
}
