using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

private float horizontal;
private float speed = 8f;
private float jumpingPower = 16f;
private bool isFacingRight = true;

private float timeBtwFire;
public float startTimeBtwFire;

private Animator anim;

[SerializeField] private Rigidbody2D rb;
[SerializeField] private Transform groundCheck;
[SerializeField] private LayerMask groundLayer;

SavePlayerPos playerPosData;


private void Awake()
{
    playerPosData = FindObjectOfType<SavePlayerPos>();
    playerPosData.PlayerPosLoad();
}


void Start () {

anim = GetComponent<Animator>();

}

void Update () {

    
    horizontal = Input.GetAxisRaw("Horizontal");

    if (Input.GetButtonDown("Jump") && IsGrounded())
    {
        anim.SetTrigger("Jump");
        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
    }

    if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
    {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
    }

    if (Input.GetKeyDown(KeyCode.F))
    {
        if (timeBtwFire <= 0f)
        {
            anim.SetBool("IsAtacking", true);
        }
        else
        {
            timeBtwFire -= Time.deltaTime;
        }
    }
    else
    {
        anim.SetBool("IsAtacking", false);
    }

    float moveInput = Input.GetAxisRaw("Horizontal");
    
    
    if ( moveInput == 0 ) {
        anim.SetBool("IsRunning", false);
    }
    else {
        anim.SetBool("IsRunning", true);
    }

    if (IsGrounded()) {
        anim.SetBool("IsJumping", false);
    }
    else {
    anim.SetBool("IsJumping", true);
    }
    
    Flip();


}

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }


}
