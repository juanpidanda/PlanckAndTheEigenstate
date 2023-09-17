using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] Rigidbody2D characterRigidbody;
    [Header("Movement")]
    public float movementSpeed;
    public ForceMode2D movementForceMode;
    public float maxMovementSpeed;
    [Header("Jumping")]
    [SerializeField]bool jumpAvailable;
    public float jumpCooldown;
    public float jumpForce;
    public ForceMode2D jumpingForceMode;
    private Coroutine jumpCooldownCoroutine;
    private Animator animator;
    private bool istrue;
    private bool isJumping;
    private void Awake()
    {
        isJumping = false;
        jumpAvailable = true;
        if(characterRigidbody == null)
        {
            characterRigidbody = GetComponent<Rigidbody2D>();
        }
    }
    private void FixedUpdate()
    {
        Movement(GameManager.gameManagerInstance.inputManager.movementOutput);
        if (GameManager.gameManagerInstance.inputManager.jumpOutput)
        {
            Jump();
            
        }
        if (istrue == false)
        {
            animator.SetBool("running", false);

        }
    }
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor") && collision.gameObject.transform.position.y < gameObject.transform.position.y)
        {
            jumpAvailable = true;
            animator.SetBool("isJumping", false);
            isJumping=false;
            //StopCoroutine(jumpCooldownCoroutine);
        }
        if (collision.gameObject.tag == "Plataform/Mobile")
        {
            transform.parent = collision.transform;
        }
    }
    void Movement(float direction)
    {
        istrue = true;
        Vector2 movement = movementSpeed * direction * Vector2.right;
        characterRigidbody.AddForce(movement, movementForceMode);
        if(direction ==0)
            istrue = false;
        if (istrue)
        {
            animator.SetBool("running", true);
        }
        if (GameManager.gameManagerInstance.wantPlayerDebug)
        {
            Debug.Log("Magnitude: " + characterRigidbody.velocity.magnitude.ToString());
        }
        characterRigidbody.velocity = truncate(characterRigidbody.velocity, maxMovementSpeed);
        if(direction <0) 
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
        }
        else
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;

    }
    void Jump()
    {
        if (jumpAvailable)
        {
            jumpAvailable = false;
            characterRigidbody.AddForce(jumpForce * Vector2.up, jumpingForceMode);
            jumpCooldownCoroutine = StartCoroutine(JumpCooldownCoroutine());
            animator.SetBool("isJumping", true);
            isJumping = true;
        }
            

    }
    IEnumerator JumpCooldownCoroutine()
    {
        jumpAvailable = false;
        if (GameManager.gameManagerInstance.wantPlayerDebug)
        {
            Debug.Log("Jump Cooldown Started");
        }
        yield return new WaitForSeconds(jumpCooldown);
        if (GameManager.gameManagerInstance.wantPlayerDebug)
        {
            Debug.Log("Jump Cooldown Finished");
        }
        jumpAvailable = true;

    }
    private static Vector3 truncate(Vector3 vector, float maxValue)
    {
        //Condicional Sentinela
        if (vector.magnitude <= maxValue)
        {
            return vector;
        }

        vector.Normalize();
        return vector *= maxValue;
    }
}
