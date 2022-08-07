using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce= 11f;

    private float movementX;

    private SpriteRenderer sr;
    private Rigidbody2D myBody;
    private Animator anime;

    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Monster";
    private bool isGrounded=true;
    // Start is called before the first frame update

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        myBody = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();

    }
    
    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
    
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;
        
    }
    void AnimatePlayer()
    {
        //going right
        if (movementX == 1)
        {
            sr.flipX = false;
            anime.SetBool(WALK_ANIMATION, true);
        }
        //going left
        else if (movementX == -1)
        {
            sr.flipX = true;
            anime.SetBool(WALK_ANIMATION, true);
        }
        //idle
        else
        {
            anime.SetBool(WALK_ANIMATION, false);
        }
    }
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }

}
