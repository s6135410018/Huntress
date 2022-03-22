using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beastAI : MonoBehaviour
{
    public System.Action<int> action;
  
    [SerializeField] private Transform target, player;
    [SerializeField] private GameObject explodePrefab;
    protected float speed = 1.0f;
    Rigidbody2D rb;
    int flip = 0;
    float distance = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.position);
        if (player.position.x < transform.position.x)
        {
            flip = 0;
        }
        else
        {
             flip = 180;
        }
        if (Vector3.Distance(transform.position, player.position) < distance)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        transform.eulerAngles = new Vector2(0, flip);
    }

    void OnTriggerEnter2D(Collider2D other) {
         if (other.gameObject.tag.Equals("weapon"))
        {
            action?.Invoke(2);
            Destroy(other.gameObject);
            StartCoroutine(CreateExplode(0.2f));
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag.Equals("Player"))
        {
            playerHealth playerHealth = other.collider.GetComponent<playerHealth>();
            playerHealth.UpdateHealth(2);
        }
        
    }
     IEnumerator CreateExplode(float sec)
    {
        yield return new WaitForSeconds(sec);
        Instantiate(explodePrefab, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
