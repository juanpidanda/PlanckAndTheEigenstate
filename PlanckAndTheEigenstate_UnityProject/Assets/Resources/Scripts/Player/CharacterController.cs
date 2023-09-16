using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] Rigidbody2D characterRigidbody;
    [Header("Movement")]
    public float movementSpeed;
    public ForceMode2D movementForceMode;
    [Header("Jumping")]
    [SerializeField]bool jumpAvailable;
    //public float jumpCooldown;
    public float jumpForce;
    public ForceMode2D jumpingForceMode;
    private Coroutine jumpCooldownCoroutine;
    private void Awake()
    {
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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor") && collision.gameObject.transform.position.y < gameObject.transform.position.y)
        {
            Debug.Log("Happened");
            jumpAvailable = true;
            //StopCoroutine(jumpCooldownCoroutine);
        }
    }
    void Movement(float direction)
    {
        characterRigidbody.AddForce(movementSpeed * direction * Vector2.right, movementForceMode);
    }
    void Jump()
    {
        if (jumpAvailable)
        {
            jumpAvailable = false;
            characterRigidbody.AddForce(jumpForce * Vector2.up, jumpingForceMode);
            //jumpCooldownCoroutine = StartCoroutine(JumpCooldownCoroutine());
        }
    }
    //IEnumerator JumpCooldownCoroutine()
    //{
    //    jumpAvailable = false;
    //    if (GameManager.gameManagerInstance.wantPlayerDebug)
    //    {
    //        Debug.Log("Jump Cooldown Started");
    //    }
    //    yield return new WaitForSeconds(jumpCooldown);
    //    if (GameManager.gameManagerInstance.wantPlayerDebug)
    //    {
    //        Debug.Log("Jump Cooldown Finished");
    //    }
    //    jumpAvailable = true;

    //}
    
}
