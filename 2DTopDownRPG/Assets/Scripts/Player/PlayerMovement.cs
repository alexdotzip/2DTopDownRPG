using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private BoxCollider2D boxCollider;
    private Vector3 movement; //what is the difference between now and where I want to be

    public float moveSpeed;

    private SpriteRenderer mySpriteRenderer;
    private Animator playerAnim;


    // Start is called before the first frame update
    void Start()
    {

        boxCollider = GetComponent<BoxCollider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
        playerAnim = (Animator)GetComponent(typeof(Animator));
        mySpriteRenderer = (SpriteRenderer)GetComponent(typeof(SpriteRenderer));
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement = new Vector3(x, y);

        if (movement != Vector3.zero)
        {
            myRigidbody.MovePosition(transform.position + movement * moveSpeed * Time.fixedDeltaTime);


            playerAnim.SetFloat("xMove", movement.x);
            playerAnim.SetFloat("yMove", movement.y);
            playerAnim.SetBool("isMoving", true);
        }
        else
        {
            playerAnim.SetBool("isMoving", false);
        }

    }

}
