using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        this.player = GameObject.Find("cat");
    }

    void Update()
    {
        //プレイヤーの座標を調べる
        Vector3 playerPos = this.player.transform.position;
        //カメラのY座標に反映
        transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
    }
}
