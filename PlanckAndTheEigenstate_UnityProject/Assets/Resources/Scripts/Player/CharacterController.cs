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
            jumpAvailable = true;
            //StopCoroutine(jumpCooldownCoroutine);
        }
        if (collision.gameObject.tag == "Plataform/Mobile")
        {
            transform.parent = collision.transform;
        }
    }
    void Movement(float direction)
    {
        Vector2 movement = movementSpeed * direction * Vector2.right;
        characterRigidbody.AddForce(movement, movementForceMode);
        if (GameManager.gameManagerInstance.wantPlayerDebug)
        {
            Debug.Log("Magnitude: " + characterRigidbody.velocity.magnitude.ToString());
        }
        characterRigidbody.velocity = truncate(characterRigidbody.velocity, maxMovementSpeed);
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
