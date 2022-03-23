using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject hitArea;
    public System.Action<int> action;
    float nextFire = 0.0f;
    float fireRate = 1.0f;
    GameObject player;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void shootWhenDown()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            action?.Invoke(0);
            StartCoroutine(createArrow());
            animator.SetBool("Attack", true);
        }
    }
    public void shootWhenUp()
    {
        if (Time.time < nextFire)
        {
            animator.SetBool("Attack", false);
        }
    }
    IEnumerator createArrow()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(arrow, hitArea.transform.position, hitArea.transform.rotation);
    }
}
