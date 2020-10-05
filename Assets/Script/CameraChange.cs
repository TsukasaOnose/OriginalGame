using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera itemCamera;

    public static readonly string CM = "Camera Manager";

    void Start()
    {
        firstPersonCamera.enabled = true;
        itemCamera.enabled = false;
    }

    //一人称カメラがオンの時、アイテムカメラをオフにする
    public void ShowFirstPersonCamera()
    {
        firstPersonCamera.enabled = true;
        itemCamera.enabled = false;
    }

    // 一人称カメラがオフの時、アイテムカメラをオンにする
    public void ShowItemCamera()
    {
        firstPersonCamera.enabled = false;
        itemCamera.enabled = true;
    }
}
