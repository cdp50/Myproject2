using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;

    //[SerializeField] private float jumpForce = 11f;
	[SerializeField] private AudioSource JumpSoundEffect;
	// [SerializeField] private AudioSource DeathSoundEffect;
    public AudioSource[] sounds;
    // public AudioSource JumpSoundEffect;
    public AudioSource DeathSoundEffect;
    public AudioSource sfx;
	
	[SerializeField] private float speed;

    private float movementX;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "walk";

    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    private void Awake()
    {

        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        sounds = GetComponents<AudioSource>();
        // JumpSoundEffect = sounds[1];
        DeathSoundEffect = sounds[0];

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
    }

    // FixedUpdate is called a fixed amount per frame.
    private void FixedUpdate()
    {
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        // GetAxisRaw("Horizontal") takes the input on the horizontal arrow keys and the 
        // "A" "D" keys
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;

        // transform.position = transform.position + new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        // Animate if moving to the left
        if (movementX > 0)
        {
            sr.flipX = false;
            anim.SetBool(WALK_ANIMATION, true);
        }
        // Animate if moving to the right
        else if (movementX < 0)
        {
            sr.flipX = true;
            anim.SetBool(WALK_ANIMATION, true);
        }
        // don't animate if the character is still
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        // It will get the default button, usually "W" or "arrow up", to jump (here it was the spacebar)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
			JumpSoundEffect.Play();
            // myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
			myBody.velocity = new Vector2(myBody.velocity.x, speed);
            isGrounded = false;
        }
    }

     // if we landed on an object with the tag ground isGrounded=true;
     private void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.CompareTag(GROUND_TAG))
         {
            //physics2D.boxCast
            isGrounded = true;
            Debug.Log("Is grounded");
         }
		// // if we touch the flames we lose
         if (collision.gameObject.CompareTag(ENEMY_TAG))
         {
             Debug.Log("Collision detected");
		 	 DeathSoundEffect.Play();
             Destroy(gameObject);
         }
     }
}
