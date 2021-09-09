using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MobStatus
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void OnDie()
    {
        base.OnDie();
        Destroy(gameObject.transform.parent.gameObject, 3f);
    }
}
