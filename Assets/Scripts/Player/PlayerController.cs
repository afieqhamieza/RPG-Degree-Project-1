using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public Rigidbody2D rb; 
	public float moveSpeed;
    public bool isDead;
    public bool isAttacking;
	Vector2 movement;

    //enum Direction { Up, Right, Down, Left };

	public Animator animatorUp;
	public Animator animatorDown;
	public Animator animatorLeft;
	public Animator animatorRight;

    public CharacterSetup controller;
    Animator currentAnimator;

    public VectorValue startingPosition;

    void Start() { //fires when game starts
        //moves player to the vector value object
        transform.position = startingPosition.initialValue;
        currentAnimator = animatorDown;
    }
    
    void Update() //controls player movement and animations
    {
        if (!isDead && !PauseMenuBehaviour.isPaused && !isAttacking){ 
            movement.x = Input.GetAxisRaw("Horizontal");
    	    movement.y = Input.GetAxisRaw("Vertical");

            //MOVEMENT BLOCK
            if (movement.x != 0 || movement.y != 0) 
            {
                if (movement.y < 0) //down movement
                {
                    currentAnimator = animatorDown; 
                    controller.downDirection.SetActive(true);
                    controller.upDirection.SetActive(false);
                    controller.leftDirection.SetActive(false);
                    controller.rightDirection.SetActive(false);

                    animatorDown.SetFloat("Speed", movement.y);
                }
                else if (movement.y > 0) //up movement
                {
                    currentAnimator = animatorUp;
                    controller.downDirection.SetActive(false);
                    controller.upDirection.SetActive(true);
                    controller.leftDirection.SetActive(false);
                    controller.rightDirection.SetActive(false);

                    animatorUp.SetFloat("Speed", movement.y);
                }
                else if (movement.x > 0) //right movement
                {
                    currentAnimator = animatorRight;
                    controller.downDirection.SetActive(false);
                    controller.upDirection.SetActive(false);
                    controller.leftDirection.SetActive(false);
                    controller.rightDirection.SetActive(true);

                    animatorRight.SetFloat("Speed", movement.x);
                }
                else if (movement.x < 0) //left movement
                {
                    currentAnimator = animatorLeft;
                    controller.downDirection.SetActive(false);
                    controller.upDirection.SetActive(false);
                    controller.leftDirection.SetActive(true);
                    controller.rightDirection.SetActive(false);

                    animatorLeft.SetFloat("Speed", movement.x * -1);
                }
            }
            //SET TO IDLE -> if not moving
            else{
                currentAnimator.SetFloat("Speed", movement.x);
            }

            // Start Attack routine 
            if (Input.GetKeyDown(KeyCode.Space)){  // SWING ATTACK
                StartCoroutine(AttackCo());
            }
        }
    }

    void FixedUpdate(){ //Movement
        movement.Normalize();
        if (!isAttacking){
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    	
    }

    void OnCollisionEnter2D (Collision2D collision){

    }

    void OnTriggerEnter2D(Collider2D other){
    	
    }

    //Attack Routine
    IEnumerator AttackCo(){
        isAttacking = true;
        currentAnimator.SetTrigger("spaceKey");
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
    }

    public void Pickup(){
        currentAnimator.SetTrigger("Pickup");
    }
}

// if(other.gameObject.CompareTag("coins")){
    	// 	Destroy(other.gameObject);
    	// }
    	// if(other.gameObject.CompareTag("chest")){
    	// 	SceneManager.LoadScene("BetweenLevel");
    	// }
    	// if(other.gameObject.CompareTag("chest2")){
    	// 	SceneManager.LoadScene("GameOver");
    	// 	PersistentManagerScript.Instance.Value = 0;
    	// }