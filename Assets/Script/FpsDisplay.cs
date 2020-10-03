using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsDisplay : MonoBehaviour
{
    //フレーム更新回数
    int frameCount = 0;
    //経過した時間
    float prevTime = 0.0f;
    //FPS
    private float fps;
    //FPSを表示するテキスト
    private GameObject fpsText;

    public static readonly string FPStext = "FPS Text";

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.fpsText = GameObject.Find(FpsDisplay.FPStext);
    }

    // Update is called once per frame
    void Update()
    {
        //1フレーム毎にカウントを1足していく
        frameCount++;
        //経過した時間をリセットする
        float time = Time.realtimeSinceStartup - prevTime;

        //1秒毎にfpsを算出する
        if (time >= 1f)
        {
            fps = frameCount;
            frameCount = 0;
            prevTime = Time.realtimeSinceStartup;

            //FPSをUIに表示
            fpsText.GetComponent<Text>().text = fps.ToString("F1");
        }
    }
}
