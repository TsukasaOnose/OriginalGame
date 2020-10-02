using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    private AsyncOperation async;
    //シーンロード中に表示するUI画面
    [SerializeField] private GameObject loadingUI;
    //読み込み率を表示するスライダー
    [SerializeField] private Slider slider;

    public void NextScene()
    {
        //ロード画面UIをアクティブにする
        loadingUI.SetActive(true);

        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        async = SceneManager.LoadSceneAsync("InMyHouse");

        //読み込みが終わるまで進捗状況をスライダーの値い反映させる
        while (!async.isDone)
        {
            slider.value = async.progress;
            yield return null;
        }
    }
}
