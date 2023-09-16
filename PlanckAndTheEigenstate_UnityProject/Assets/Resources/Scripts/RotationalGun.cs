using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotationalGun : MonoBehaviour
{
    [Header("Bullet Settigns")]
    public Transform bulletStartingPoint;
    [SerializeField] float maxBulletTime;
    [SerializeField] float bulletSpeed;
    float currentBulletTime;
    bool bulletWasFired = false;

    [Header("Gun Rotation Settings")]
    public GameObject gun_pivot;
    public GameObject bulletParticle;
    public GameObject bulletWave;
    [SerializeField] float mouseOffset;

    Vector2 difference;
    Vector2 mouseTargetPos;
    Rigidbody2D bulletRb;

    void Start()
    {
        bulletRb = bulletParticle.GetComponent<Rigidbody2D>();
        currentBulletTime = 0.0f;
    }

    void Update()
    {
        RotatePivotWithMouse();
        FireGun();
        if(bulletWasFired == false)
        {
            bulletParticle.transform.position = transform.position;
            bulletRb.velocity = Vector2.zero;
        }
        else
        {
            MoveInDirection(mouseTargetPos);
            currentBulletTime += Time.deltaTime;
        }

        if (currentBulletTime > 5)
        {
            currentBulletTime = 0;
            bulletWasFired = false;
        }
    }

    void RotatePivotWithMouse()
    {
        difference = Camera.main.ScreenToWorldPoint(GameManager.gameManagerInstance.inputManager.aimingOutput) - transform.position;
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        gun_pivot.transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + mouseOffset);
    }

    void FireGun()
    {
        if(GameManager.gameManagerInstance.inputManager.primaryShotOutput && bulletWasFired == false){
            bulletWasFired = true;
            bulletParticle.transform.position = bulletStartingPoint.position;
            mouseTargetPos = difference;
        }
    }

    void MoveInDirection(Vector2 direction)
    {
        direction.Normalize();
        bulletParticle.transform.Translate(direction * bulletSpeed * Time.deltaTime);
    }
}
