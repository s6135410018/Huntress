using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    float dampTime = 0.15f;
    Vector3 velocity = Vector2.zero;
    public Transform target;
    public Vector3 minValue, maxValue;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 point = cam.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            Vector3 boundPosition = new Vector3(
                Mathf.Clamp(destination.x, minValue.x, maxValue.x),
                Mathf.Clamp(destination.y, minValue.y, maxValue.y),
                Mathf.Clamp(destination.z, minValue.z, maxValue.z)
                );

            transform.position = Vector3.SmoothDamp(transform.position, boundPosition, ref velocity, dampTime);
        }
    }
}
