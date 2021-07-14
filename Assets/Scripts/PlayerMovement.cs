using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Transform GroundCheckTransform;
    public LayerMask playerMask;
    private bool JumpCounter;
    private float HorizontalInputs;
    private Rigidbody myBall;

    private int coinCount;
    //private bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        myBall = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Rigidbody myBall = this.GetComponent<Rigidbody>();
        HorizontalInputs = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            JumpCounter = true;
        }
    }

    //Update is called once every physics engine update
    void FixedUpdate() {
        //Rigidbody myBall = this.GetComponent<Rigidbody>();
        /*if (!onGround){
            return;
        }*/
        myBall.velocity = new Vector3(HorizontalInputs, myBall.velocity.y , 0);

        /*if (Physics.OverlapSphere(GroundCheckTransform.position, 0.1f).Length == 1){//use 1 as its colliding with itself, if more than 1 then its touching/colliding iwth ground as well, but not the best way to do if player has other outfits like a weapon, in that case use layerMask method
            return;
        }*/

        if (Physics.OverlapSphere(GroundCheckTransform.position, 0.1f, playerMask).Length == 0){
            return;
        }

        if (JumpCounter){
                JumpCounter = false;
                //myBall.AddForce(Vector3 (0,10,0));
                Vector3 forceVector = new Vector3 (0,350,0);
                myBall.AddForce (forceVector);
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
        }
    }

}
