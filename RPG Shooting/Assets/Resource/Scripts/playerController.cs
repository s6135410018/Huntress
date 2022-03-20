using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class playerController : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float jumpPower = 10.0f;

    float nextJump = 0.0f;
    float jumpSpeed = 9.0f;
    float nextFireRate = 0.0f;
    float fireRate = 1.0f;

    public FixedJoystick joystick;
    Animator animator;
    Rigidbody2D rb;
    Jump jumpJoyStick;
    playerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        jumpJoyStick = GameObject.FindObjectOfType<Jump>();
        playerHealth = GetComponent<playerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Ground", true);
        animator.SetFloat("Speed", Mathf.Abs(joystick.Horizontal));
        if (joystick.Horizontal < -0.1f)
        {
            transform.Translate(Vector2.right * speed* Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }
        else if (joystick.Horizontal > 0.1f)
        {
            transform.Translate(Vector2.right * speed  * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
       
        else
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Ground", true);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            playerHealth.UpdateHealth(2);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jumpJoyStick.jumpTime = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("deathZone"))
        {
            playerHealth.UpdateHealth(10);
        }
    }
}
