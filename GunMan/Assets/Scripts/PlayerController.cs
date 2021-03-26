using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    public GameObject bulletPrefab;
    private Animator anim;

    public float speed = 5.0f;
    public float jumpHeight = 10.0f;

    public bool isWalking;
    public float runInput;
    public float verticalInput;
    

    public Transform firepoint;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        runInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        playAnimation(runInput, verticalInput);

        // Move the character left or right

        transform.Translate(Vector3.right * Time.deltaTime * speed * Math.Abs(runInput));
        //rigidbody2d.velocity = new Vector3(speed * runInput, rigidbody2d.velocity.y);
        
        // Make the character jump or crouch
        if (verticalInput > 0 && isGrounded())
        {
            rigidbody2d.velocity = Vector2.up * jumpHeight;
        }
    }

    private bool isGrounded()
    {

        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, 0.1f, platformLayerMask);

        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }

    void playAnimation(float runInput, float verticalInput)
    {
        if (runInput == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);

            if (runInput > 0)
            {
                transform.eulerAngles = new Vector2(0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("shoot");
            Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        }

    }
}
