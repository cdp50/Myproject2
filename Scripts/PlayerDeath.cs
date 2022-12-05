// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerDeath : MonoBehaviour
// {
//     [SerializeField] private AudioSource DeathSoundEffect;
//     private string GROUND_TAG = "Ground";
//     private string ENEMY_TAG = "Enemy";
//     private bool isGrounded = true;
//     private Rigidbody2D myBody;
//     private SpriteRenderer sr;
//     private Animator anim;
    
//     // Start is called before the first frame update
//     void Start()
//     {
//         myBody = GetComponent<Rigidbody2D>();
//         anim = GetComponent<Animator>();
//         sr = GetComponent<SpriteRenderer>();

//     }
    
//     // if we landed on an object with the tag ground isGrounded=true;
//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag(GROUND_TAG))
//         {
//             isGrounded = true;
//         }
//         // if we touch the flames we lose
//         if (collision.gameObject.CompareTag(ENEMY_TAG))
//         {
//             Debug.Log("Collision detected");
//             DeathSoundEffect.Play();
//             Destroy(gameObject);
//         }
//     }

//     // // Update is called once per frame
//     // void Update()
//     // {
//     //     
//     // }
// }
