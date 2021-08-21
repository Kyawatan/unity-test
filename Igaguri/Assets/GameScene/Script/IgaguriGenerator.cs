using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgaguriGenerator : MonoBehaviour
{
    public GameObject igaguriPrefab;

    void Update()
    {
        //マウスクリックするとイガグリのインスタンス生成
        if (Input.GetMouseButtonDown(0))
        {
            const float FORCE_RATE = 50f;
            GameObject igaguri = Instantiate(igaguriPrefab) as GameObject;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;

            //タップした位置に向けてイガグリを飛ばす
            igaguri.GetComponent<IgaguriController>().Shoot(
                worldDir.normalized * FORCE_RATE);
        }
    }
}
