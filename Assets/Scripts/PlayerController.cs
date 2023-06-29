using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D myRB;
    private Animator myAnim;
    private Vector2 moveVelocity;


    [SerializeField]
    private float speed;

    Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;

        myAnim.SetFloat("moveX", movement.x);
        myAnim.SetFloat("moveY", movement.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnim.SetFloat("lastMoveX", movement.x);
            myAnim.SetFloat("lastMoveY", movement.y);
        }
    }
    void FixedUpdate()
    {
        myRB.MovePosition(myRB.position + movement * speed * Time.fixedDeltaTime);
    }

}
