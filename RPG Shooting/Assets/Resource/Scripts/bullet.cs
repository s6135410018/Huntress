using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    float speed = 3.0f;
    float startTime;
    float secondDestroy = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (Time.time - startTime >= secondDestroy)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Player"))
        {
            playerHealth playerHealth = other.GetComponent<playerHealth>();
            playerHealth.UpdateHealth(2);
        }
    }
}
