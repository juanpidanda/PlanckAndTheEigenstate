using UnityEngine;

public class ParticleSwitcher : MonoBehaviour
{
    [Header("References")]
    [SerializeField] bool isParticle = true;
    [SerializeField] GameObject particle;
    [SerializeField] GameObject platform;
    RotationalGun gun;

    [Header("Settings")]
    [SerializeField] float hitDistance = 1;
    bool WatchDistance = false;

    private void Awake()
    {
        gun = FindAnyObjectByType<RotationalGun>();
    }

    void Start()
    {
        gun.OnFire += () => WatchDistance = true;
        gun.OnAmmoRestored += () => WatchDistance = false;
    }

    void Update()
    {
        if (WatchDistance)
        {
            if ((!isParticle && gun.bullet.CompareTag("Particle")) || (isParticle && gun.bullet.CompareTag("Wave")))
                return;

            if (Vector3.Distance(gun.bullet.transform.position, transform.position) < hitDistance)
            {
                particle.SetActive(false);
                platform.SetActive(true);
            }
        }
    }


}
