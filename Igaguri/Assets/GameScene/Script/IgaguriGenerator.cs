using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgaguriGenerator : MonoBehaviour
{
    public GameObject m_igaguriPrefab;
    public static bool m_canThrow = false;

    void Update()
    {
        //マウスクリックするとイガグリを生成して飛ばす
        if (m_canThrow && Input.GetMouseButtonDown(0))
        {
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
        igaguri.GetComponent<IgaguriController>().Shoot(
            worldDir.normalized * FORCE_RATE);
    }
}
