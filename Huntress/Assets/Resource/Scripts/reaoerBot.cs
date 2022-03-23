using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reaoerBot : MonoBehaviour
{
    public System.Action<int> action;

    float speed = 0.5f;
    [SerializeField] GameObject bullet, explodePrefab;
    GameObject player;
    int flip = 0;
    float distance = 2;
    int number;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        number = Random.Range(0, 1000);

        if (player.transform.position.x <= transform.position.x)
        {
            flip = 180;

        }
        else
        {
            flip = 0;

        }
        if (Vector3.Distance(transform.position, player.transform.position) > distance)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            if (number == 100)
            {
                Instantiate(bullet, transform.position, transform.rotation);
            }
        }
        transform.eulerAngles = new Vector2(0, flip);

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other) {
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
