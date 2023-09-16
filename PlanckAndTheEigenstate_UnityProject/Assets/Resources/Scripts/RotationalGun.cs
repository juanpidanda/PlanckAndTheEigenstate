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
    public GameObject bullet;
    public Sprite particle, wave;
    [SerializeField] float mouseOffset;

    Vector2 difference;
    Vector2 mouseTargetPos;

    void Start()
    {
        currentBulletTime = 0.0f;
    }

    void Update()
    {
        RotatePivotWithMouse();
        FireGun();
        if(bulletWasFired == false)
        {
            bullet.transform.position = transform.position;
            
        }
        else
        {
            MoveInDirection(mouseTargetPos);
            currentBulletTime += Time.deltaTime;
        }

        if (currentBulletTime > maxBulletTime)
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
            bullet.transform.position = bulletStartingPoint.position;
            mouseTargetPos = difference;
            bullet.tag = "Particle";
            bullet.GetComponent<SpriteRenderer>().sprite = particle;
        }

        if (GameManager.gameManagerInstance.inputManager.secondaryShotOutput && bulletWasFired == true)
        {
            ChangeType();
        }
    }

    void MoveInDirection(Vector2 direction)
    {
        direction.Normalize();
        bullet.transform.Translate(direction * bulletSpeed * Time.deltaTime);
    }

    void ChangeType()
    {
        if(bullet.GetComponent<SpriteRenderer>() is var bulletSprite && bullet.tag == "Particle")
        {
            bulletSprite.sprite = wave;
            bullet.tag = "Wave";
        }
    }
}
