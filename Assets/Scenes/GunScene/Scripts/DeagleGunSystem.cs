using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeagleGunSystem : MonoBehaviour
{
    public int damage;
    public Animator m_animator;
    bool shooting,
        readyToShoot,
        reloading;
    public float bulletsLeft, range;
    public float timeBetweenShooting;

    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    public GameObject bulletHoleGraphic;
    public ParticleSystem muzzleFlash;
    public TrailRenderer trail;

    public ParticleSystem sparks;

    public AudioSource m_shootingSound;
    void Awake()
    {
        bulletsLeft = 100;
        Invoke("AllowShoot", 0.67f);
        fpsCam = Camera.main;
        m_shootingSound = GetComponent<AudioSource>();
        // Invoke("AllowShoot", 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
    }

    private void MyInput()
    {
        // shooting = Input.GetKey(KeyCode.Mouse0);
        shooting = Input.GetKey(KeyCode.Mouse0);

        if (shooting && readyToShoot)
        {
            bulletsLeft = 100;
            readyToShoot = false;
            GetComponentInChildren<DeagleWeaponRecoil>().Fire();

            Invoke("ResetShot", timeBetweenShooting);
            Shoot();
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

    private void AllowShoot()
    {
        readyToShoot = true;
    }

    private void Shoot()
    {
        GetComponent<Animator>().Play("Shooting", 0, 0);
        bulletsLeft--;
        readyToShoot = false;
        GetComponentInParent<SoundManager>().Play(2, 1f);

        GetComponentInChildren<CamRecoil>().Fire();

        Vector3 direction = attackPoint.transform.forward;

        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            // Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("Enemy"))
            {
                rayHit.collider.GetComponentInParent<Anemy>().TakeDamage(this.damage);
            }
            else if(rayHit.collider.CompareTag("Head")){
                rayHit.collider.GetComponentInParent<Anemy>().TakeDamage(this.damage*4);
            }
            else if(rayHit.collider.CompareTag("BulletDropped")){
                Destroy(rayHit.collider.gameObject, 0.05f);
            }

            // if (rayHit.rigidbody != null)
            // {
            //     rayHit.rigidbody.AddForce(-rayHit.normal * 100);
            //     rayHit.rigidbody.transform.parent = null;
            // }
        }

        TrailRenderer trailTemp = Instantiate(trail, attackPoint.position + new Vector3(0.25f, -0.05f, 0.05f), Quaternion.identity);
        StartCoroutine(SpawnTrail(trailTemp, rayHit));

        GameObject impact = Instantiate(bulletHoleGraphic, rayHit.point + (rayHit.normal * .01f), Quaternion.LookRotation(rayHit.normal));
        impact.transform.parent = rayHit.transform;
        if (rayHit.collider != null && !rayHit.collider.CompareTag("Enemy")&& !rayHit.collider.CompareTag("Head"))
        {
            ParticleSystem sparksTemp = Instantiate(sparks, rayHit.point + (rayHit.normal * .01f), Quaternion.LookRotation(rayHit.normal));
            sparksTemp.transform.parent = rayHit.transform;
            StartCoroutine(SpawnSparks(sparksTemp, rayHit));
        }
        muzzleFlash.Play();

        Invoke("ResetShot", timeBetweenShooting);
    }

    private IEnumerator SpawnSparks(ParticleSystem sparks, RaycastHit hit)
    {
        float time = 0;
        Vector3 startPosition = sparks.transform.position;

        while (time < 0.001)
        {
            time += Time.deltaTime / 1;

            yield return null;
        }

        sparks.transform.position = hit.point;
        Destroy(sparks.gameObject, 0.2f);

    }

    private IEnumerator SpawnTrail(TrailRenderer trail, RaycastHit hit)
    {
        float time = 0;
        Vector3 startPosition = trail.transform.position;

        while (time < 1)
        {
            trail.transform.position = Vector3.Lerp(startPosition, hit.point, time);
            time += Time.deltaTime / trail.time;

            yield return null;
        }

        trail.transform.position = hit.point;
        Destroy(trail.gameObject, trail.time);
    }
}
