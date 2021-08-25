using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgaguriGenerator : MonoBehaviour
{
    public GameObject m_igaguriPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameDirector.ms_instance.GetNowFlow() == GameDirector.GAME_FLOW.Playing)
        {
            //プレイ中にマウスクリックするとイガグリを生成して飛ばす
            ThrowIgaguri();
        }
    }

    private void ThrowIgaguri()
    {
        const float FORCE_RATE = 50f;
        GameObject igaguri = Instantiate(m_igaguriPrefab) as GameObject;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 worldDir = ray.direction;

        //クリックした位置に向けてイガグリを飛ばす
        igaguri.GetComponent<IgaguriController>().Shoot(worldDir.normalized * FORCE_RATE);
    }
}
