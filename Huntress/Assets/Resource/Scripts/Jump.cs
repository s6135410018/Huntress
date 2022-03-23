using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public int jumpTime = 0;
    int maxJump = 2;
    float jumpSpeed = 9f;
    public float jumpPower = 10f;
    GameObject player;
    Rigidbody2D rb;
    Animator animator;
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
        animator = player.GetComponent<Animator>();
    }
   public void OnJump()
   {
            if (jumpTime < maxJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(jumpSpeed * (Vector2.up * jumpPower));
                animator.SetBool("Jump", true);
                animator.SetBool("Ground", false);
                jumpTime++;
            }
   }
}
