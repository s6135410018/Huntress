using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float walkL, walkR = 0.3f;
    [SerializeField] private GameObject explodePrefab;
    public System.Action<int> action;

    Rigidbody2D rb;
    Animator animator;
    public float direction = -1f;
    public Vector3 walkAmount;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (direction > 0.0f && transform.position.x >= walkR)
        {
            direction = -1f;
        }
        else if (direction < 0.0f && transform.position.x <= walkL)
        {
            direction = 1f;

        }
        walkAmount.x = (direction * speed) * Time.deltaTime;
        transform.Translate(walkAmount);
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag.Equals("Player"))
        {
            playerHealth playerHealth = other.collider.GetComponent<playerHealth>();
            playerHealth.UpdateHealth(2);
        }
    }
     private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("weapon"))
        {
            action?.Invoke(2);
            Destroy(other.gameObject);
            StartCoroutine(CreateExplode(0.2f));
        }
    }
    IEnumerator CreateExplode(float sec)
    {
        yield return new WaitForSeconds(sec);
        Instantiate(explodePrefab, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
