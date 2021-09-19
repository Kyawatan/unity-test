using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestGenerator : MonoBehaviour
{
    private float m_time = 0f;
    private float m_enableTime = 10f;

    void Update()
    {
        // 一定時間ごとに、地球の裏側（プレイヤーから見えない位置）でチェストを生成

        if (GameDirector.GetInstance.OnChest) gameObject.SetActive(true);

        if (gameObject.activeSelf)
        {
            m_time += Time.deltaTime;
            if (m_time == m_enableTime) gameObject.SetActive(false);
        }
    }
}
