using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFiringRate = 0.5f;

    [Header("AI Settings")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0.5f;
    [SerializeField] float minFireRate = 0.1f;

    Coroutine fireCoroutine;

    AudioPlayer audioPlayer;

    [HideInInspector] public bool isFiring;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring &&  fireCoroutine !=null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
        
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb2d = projectile.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                rb2d.velocity = transform.up * projectileSpeed;
            }
            Destroy(projectile, projectileLifetime);
            
            float timeToNextFire = Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
            timeToNextFire = Mathf.Clamp(timeToNextFire, minFireRate, float.MaxValue);

            audioPlayer?.PlayShootingClip();

            yield return new WaitForSeconds(timeToNextFire); 
        }
    }
}
