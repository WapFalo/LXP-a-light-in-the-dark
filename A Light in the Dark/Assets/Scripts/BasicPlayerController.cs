using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


namespace Platformer.Mechanics {
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class BasicPlayerController : MonoBehaviour
    {

        private float h; // horizontal input
        private bool jump;
        private bool isSliding;
        private float oldH; // used for wall jumping
        private float modifierOverTime; // used for wall jumping
        private bool wallJumping;
        private JumpState jumpState = JumpState.Grounded;
        
        public float speed = 10f;
        public float jumpForce = 20f; 
        public float wallSlidingSpeed = 1f;
        public float wallJumpDuration = 0.5f;
        public Vector2 wallJumpForce = new Vector2(10f, 20f);

        [SerializeField] private Rigidbody2D rb;

        public float lightPoints = 0f;
        public Light2D light;

        public enum JumpState
        {
            Grounded,
            WallSlide,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
        }

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
    
        void Update()
        {

            h = Input.GetAxisRaw("Horizontal");
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }

            if (jumpState == JumpState.WallSlide && h != 0)
            {
                isSliding = true;
            } else {
                isSliding = false;
            }

        }

        void FixedUpdate()  
        {
            if (jump)
            {
                Jump();
            }

            if (isSliding)
            {
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y - wallSlidingSpeed, -wallSlidingSpeed, float.MaxValue));
            }

            if (wallJumping)
            {
                modifierOverTime -= Time.deltaTime * 1.5f;
                rb.velocity = new Vector2(-oldH * wallJumpForce.x, wallJumpForce.y * modifierOverTime);
            } 
            else { // basic value
                rb.velocity = new Vector2(h * speed, rb.velocity.y);
            }
        }

        void Jump()
        {
            if (jumpState == JumpState.Grounded)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpState = JumpState.PrepareToJump;
            }
            else if (isSliding) 
            {
                wallJumping = true;
                oldH = h;
                modifierOverTime = 1;
                Invoke("StopWallJump", wallJumpDuration);
            }

            jump = false;
        }

        void StopWallJump()
        {
            wallJumping = false;
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            var contact = other.contacts[0];

            if (contact.normal.y > 0.9)
            {
                Debug.Log("Grounded");
                jumpState = JumpState.Grounded;
            }
            else if (contact.normal.y < -0.9 && jumpState != JumpState.Grounded)
            {
                Debug.Log("Wall Top");
                jumpState = JumpState.InFlight;
            }
            else if (contact.normal.x > 0.9 && jumpState != JumpState.Grounded)
            {
                Debug.Log("Wall Left");
                jumpState = JumpState.WallSlide;
            }
            else if (contact.normal.x < -0.9 && jumpState != JumpState.Grounded)
            {
                Debug.Log("Wall Right");
                jumpState = JumpState.WallSlide;
            }
            
        }

        void OnCollisionStay2D(Collision2D other)
        {
            foreach (ContactPoint2D contact in other.contacts)
            {
                if (contact.normal.y > 0.9)
                {
                    jumpState = JumpState.Grounded;
                    return;
                }
                else if (contact.normal.y < -0.9)
                {
                    jumpState = JumpState.InFlight;
                }
                else if (contact.normal.x > 0.9)
                {
                    jumpState = JumpState.WallSlide;
                }
                else if (contact.normal.x < -0.9)
                {
                    jumpState = JumpState.WallSlide;
                }
                else
                {
                    jumpState = JumpState.InFlight;
                }
            }
        }

        void OnCollisionExit2D(Collision2D other)
        {
            jumpState = JumpState.InFlight;
        }
    }
}