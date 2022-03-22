using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayClear : MonoBehaviour
{
    float startTime;
    float secondDestroy = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > secondDestroy)
        {
            Destroy(this.gameObject);
        }
    }
}
