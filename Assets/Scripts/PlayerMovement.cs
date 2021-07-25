using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class PlayerMovement : MonoBehaviour
{
    public Transform GroundCheckTransform;
    private bool m_Grounded;            // Whether or not the player is grounded.

    public LayerMask playerMask;
    private bool JumpCounter;
    private float HorizontalInputs;
    private Rigidbody myBall;
    public Animator animator;

    private bool m_FacingRight = true;  // For determining which way the player is currently facing.

    private int coinCount;
    //private bool onGround;
    
    public UnityEvent OnLandEvent;

    public void onLanding(){
        animator.SetBool("IsJump", false);
    }

    // Start is called before the first frame update
    void Start()
    {
        myBall = GetComponent<Rigidbody>();

        if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
    }

    // Update is called once per frame
    void Update()
    {   
        //Rigidbody myBall = this.GetComponent<Rigidbody>();
        HorizontalInputs = Input.GetAxis("Horizontal") * 2;

        animator.SetFloat("Speed", Mathf.Abs(HorizontalInputs));

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            JumpCounter = true;
            animator.SetBool("IsJump", true);
        }
    }

    //Update is called once every physics engine update
    void FixedUpdate() {
        //Rigidbody myBall = this.GetComponent<Rigidbody>();
        /*if (!onGround){
            return;
        }*/
        myBall.velocity = new Vector3(HorizontalInputs, myBall.velocity.y , 0);

        bool wasGrounded = m_Grounded;
		m_Grounded = false;

        /*if (Physics.OverlapSphere(GroundCheckTransform.position, 0.1f).Length == 1){//use 1 as its colliding with itself, if more than 1 then its touching/colliding iwth ground as well, but not the best way to do if player has other outfits like a weapon, in that case use layerMask method
            return;
        }*/

        if (Physics.OverlapSphere(GroundCheckTransform.position, 0.1f, playerMask).Length == 0){
            m_Grounded = true;
            if (!wasGrounded)
					OnLandEvent.Invoke();
            return;
        }

        if (JumpCounter){
                JumpCounter = false;
                m_Grounded = false;
                onLanding();
                //myBall.AddForce(Vector3 (0,10,0));
                Vector3 forceVector = new Vector3 (0,350,0);
                myBall.AddForce (forceVector);
        }

        if (HorizontalInputs > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (HorizontalInputs < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}

    }

    /*private void OnCollisionEnter(Collision other) {
        onGround = true;
    }

    private void OnCollisionExit(Collision other) {
        onGround = false;
    }*/

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 7){
            Destroy(other.gameObject);
            coinCount++;
            ScoreCounter.instance.AddPoint();
        }

        if (other.gameObject.layer == 8){
            ScoreCounter.instance.EndGame();
            GameOverScript.instance.GameOverScore();//needed to attached game over script to player else game won't know which scene to go to next when trigger. 
        }

        if (other.gameObject.layer == 9){
            ScoreCounter.instance.EndGame();
            GameOverScript.instance.GameOverScore();//needed to attached game over script to player else game won't know which scene to go to next when trigger. 
        }
    }

    private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
