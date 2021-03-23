using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Animator anim;
    public bool isWalking;
    float moveInput;

    public Transform firepoint;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        playAnimation(moveInput);

    }

    void playAnimation(float moveInput)
    {
        if (moveInput == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);

            if (moveInput > 0)
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
