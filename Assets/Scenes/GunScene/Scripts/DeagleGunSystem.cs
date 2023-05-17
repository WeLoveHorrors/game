using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeagleGunSystem : MonoBehaviour
{
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

    void Awake()
    {
        bulletsLeft = 100;
        Invoke("AllowShoot", 0.1f);
        fpsCam = Camera.main;
        // Invoke("AllowShoot", 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
    }

    private void MyInput()
    {
        shooting = Input.GetKey(KeyCode.Mouse0);

        if (readyToShoot && shooting)
        {
            bulletsLeft = 100;
            // m_animator.SetTrigger("Shooting");
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
        bulletsLeft--;
        readyToShoot = false;

        // GetComponentInChildren<AdvancedWeaponRecoil>().Fire();

        Vector3 direction = fpsCam.transform.forward;

        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("Enemy"))
            {
                // rayHit.collider.GetComponent
            }

            if (rayHit.rigidbody != null)
            {
                rayHit.rigidbody.AddForce(-rayHit.normal * 100);
                rayHit.rigidbody.transform.parent = null;
            }
        }

            TrailRenderer trailTemp = Instantiate(trail, attackPoint.position + new Vector3(0.25f, -0.05f, 0.05f), Quaternion.identity);
            StartCoroutine(SpawnTrail(trailTemp, rayHit));

            GameObject impact = Instantiate(bulletHoleGraphic, rayHit.point + (rayHit.normal * .01f), Quaternion.LookRotation(rayHit.normal));
            impact.transform.parent = rayHit.transform;

            ParticleSystem sparksTemp = Instantiate(sparks, rayHit.point + (rayHit.normal * .01f), Quaternion.LookRotation(rayHit.normal));
            sparksTemp.transform.parent = rayHit.transform;
            StartCoroutine(SpawnSparks(sparksTemp, rayHit));

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
