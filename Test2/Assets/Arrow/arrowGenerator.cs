using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    float span = 1.0f;
    float delta = 0;

    void Start()
    {
        
    }

    void Update()
    {
        this.delta += Time.deltaTime;
        Debug.Log(Time.deltaTime);
        if(this.delta > this.span)
        {
            this.delta = 0;
            GameObject go =  Instantiate(arrowPrefab) as GameObject;
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}
