using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4GunSystem : MonoBehaviour
{
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    public int bulletsLeft, bulletsShot;

    bool shooting, readyToShoot, reloading;

    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    public GameObject bulletHoleGraphic;
    public ParticleSystem muzzleFlash;
    public ParticleSystem ribbonSmoke;
    public ParticleSystem cartridge;
    public TrailRenderer trail;

    public ParticleSystem sparks;

    public AudioSource m_shootingSound;

    public bool isRibbonEnabled;
    public float RibbonTimeAlive = 2f;
    private void Awake()
    {
        fpsCam = Camera.main;
        Invoke("AllowShoot", 0.25f);
        ribbonSmoke.Stop();
        bulletsLeft = magazineSize;
        m_shootingSound = GetComponent<AudioSource>();
    }
    private void Update()
    {
        MyInput();
    }
    private void MyInput()
    {
        if (allowButtonHold)
            shooting = Input.GetKey(KeyCode.Mouse0);
        else
            shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (readyToShoot && shooting && bulletsLeft > 0)
        {
            Shoot();
        }

        if (shooting)
        {
            GetComponent<Animator>().SetBool("isShooting", true);
            isRibbonEnabled = true;
            RibbonTimeAlive = 2f;
        }
        else
        {
            GetComponent<Animator>().SetBool("isShooting", false);
            HandleRibbon();
            bulletsShot = 0;
        }

        // if(isRibbonEnabled && !shooting)
        // {
        //     bulletsShot = 0;
        //     RibbonTimeAlive -= Time.deltaTime;
        //     if(RibbonTimeAlive > 0)
        //     {
        //         ribbonSmoke.Play();
        //     }
        //     else
        //     {
        //         ribbonSmoke.Stop();
        //         isRibbonEnabled = false;
        //     }
        //     //  = new Color(255,255,255,0);
        // }
    }

    private void Shoot()
    {
        if (readyToShoot && bulletsLeft > 0)
        {
            GetComponentInParent<SoundManager>().Play(1, 0.12f);
            bulletsLeft--;
            readyToShoot = false;
            cartridge.Play();

            GetComponentInChildren<AdvancedWeaponRecoil>().Fire();

            float x = bulletsShot == 0 ? 0 : Random.Range(-spread, spread) + bulletsShot * spread * Random.Range(-0.06f, 0.06f);
            float y = bulletsShot == 0 ? 0 : Random.Range(-spread, spread) + bulletsShot * spread * Random.Range(0.02f, 0.06f);
            float z = bulletsShot == 0 ? 0 : x * (Random.Range(0, 1) > 0.5f ? -1 : 1) / 2f;
            x = bulletsShot < 5 ? Mathf.Sqrt(bulletsShot / 3.5f) * x : x;
            y = bulletsShot < 5 ? Mathf.Sqrt(bulletsShot / 3.5f) * y : y;
            z = bulletsShot < 5 ? Mathf.Sqrt(bulletsShot / 3.5f) * z : z;

            bulletsShot++;

            Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, z);

            if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
            {
                Debug.Log(rayHit.collider.name);

                if (rayHit.collider.CompareTag("Enemy")){
                    rayHit.collider.GetComponentInParent<Anemy>().TakeDamage(this.damage);
                }
                else if(rayHit.collider.CompareTag("Head")){
                    rayHit.collider.GetComponentInParent<Anemy>().TakeDamage(this.damage*4);
                }
                else if (rayHit.collider.CompareTag("Boss")){
                    rayHit.collider.GetComponentInParent<BossScript>().TakeDamage(this.damage);
                }
                else if (rayHit.collider.CompareTag("BossHead")){
                    rayHit.collider.GetComponentInParent<BossScript>().TakeDamage(this.damage * 2);
                }
                else if(rayHit.collider.CompareTag("BulletDropped")){
                    Destroy(rayHit.collider.gameObject, 0.05f);
                }
                // if (rayHit.rigidbody != null)
                // {
                //     rayHit.rigidbody.AddForce(-rayHit.normal * 30);
                //     rayHit.rigidbody.transform.parent = null;
                // }
            }

            TrailRenderer trailTemp = Instantiate(trail, attackPoint.position + new Vector3(0.25f, -0.05f, 0.05f), Quaternion.identity);
            StartCoroutine(SpawnTrail(trailTemp, rayHit));

            HandleAllBulletsLeftRibbon();

            GameObject impact = Instantiate(bulletHoleGraphic, rayHit.point + (rayHit.normal * .01f), Quaternion.LookRotation(rayHit.normal));
            impact.transform.parent = rayHit.transform;
            if (rayHit.collider!=null&&!rayHit.collider.CompareTag("Enemy")&& !rayHit.collider.CompareTag("Head"))
            {
                ParticleSystem sparksTemp = Instantiate(sparks, rayHit.point + (rayHit.normal * .01f), Quaternion.LookRotation(rayHit.normal));
                sparksTemp.transform.parent = rayHit.transform;
                StartCoroutine(SpawnSparks(sparksTemp, rayHit));
            }
            

            muzzleFlash.Play();

            Invoke("ResetShot", timeBetweenShooting);
        }
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
    private void HandleRibbon()
    {
        if (bulletsShot != 30 && bulletsShot > 20 && !shooting)
        {
            Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 90, 0));
            isRibbonEnabled = true;
            RibbonTimeAlive = 2f;
            ribbonSmoke.Play();
            Invoke("StopRibbon", 2f);
        }
    }
    private void HandleAllBulletsLeftRibbon()
    {
        if (bulletsLeft <= 0 && bulletsShot == 30)
        {
            isRibbonEnabled = true;
            RibbonTimeAlive = 3f;
            ribbonSmoke.Play();
            Invoke("StopRibbon", 3f);
        }
    }

    private void StopRibbon()
    {
        ribbonSmoke.Stop();
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

    private void AllowShoot()
    {
        readyToShoot = true;
    }

    private void RemoveMuzzle(ParticleSystem Muzzle)
    {
        if (Muzzle != null)
        {
            Destroy(Muzzle);
        }
    }
}
