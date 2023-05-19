using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform fireSpawnPoint;
    public float fireRate = 0.25f;

    private Animator anim;
    private float nextBullet;
    private PlayerScript playerScript;

    private AudioSource audioManager;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        playerScript = GetComponent<PlayerScript>();
        audioManager = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!audioManager.isPlaying)
            {
                audioManager.Play();
            }
            playerScript.isShooting = true;
            anim.SetBool("Fire", true);
            if(Time.time > nextBullet)
            {
                nextBullet = Time.time + fireRate;

                GameObject Bullet = Instantiate(bulletPrefab, fireSpawnPoint.position, Quaternion.identity);
                Bullet.GetComponent<Rigidbody>().velocity = transform.forward * 20;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            audioManager.Stop();
            playerScript.isShooting = false;
            anim.SetBool("Fire", false);
        }
    }
}
