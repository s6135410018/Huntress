using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostAI : MonoBehaviour
{
    public System.Action<int> action;

    [SerializeField] private Transform target, player, point;
    [SerializeField] private GameObject bulletPrefab, explodePrefab;
    [SerializeField] float y;
    protected float speed = 1.0f;
    Rigidbody2D rb;
    int flip = 0;


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
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        transform.eulerAngles = new Vector2(0, flip);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Follow"))
        {
            Instantiate(bulletPrefab, point.transform.position, point.transform.rotation);
            target.transform.position = new Vector2(Random.Range(1, 21), y);
        }
        if (other.gameObject.tag.Equals("Player"))
        {
            playerHealth playerHealth = other.GetComponent<playerHealth>();
            playerHealth.UpdateHealth(2);
        }
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
