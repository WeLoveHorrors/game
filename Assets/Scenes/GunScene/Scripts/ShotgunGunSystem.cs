using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunGunSystem : MonoBehaviour
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
    public ParticleSystem shotFlash;
    public TrailRenderer trail;

    public ParticleSystem sparks;
    public GameObject shell;
    public Transform shellFalling;

    public AudioSource m_shootingSound;
    private void Awake()
    {
        fpsCam = Camera.main;
        Invoke("AllowShoot", 0.44f);
        bulletsLeft = magazineSize;
        m_shootingSound = GetComponent<AudioSource>();
    }
    private void Update()
    {
        MyInput();
    }
    private void MyInput()
    {
        shooting = Input.GetKey(KeyCode.Mouse0);

        if (readyToShoot && shooting && bulletsLeft > 0)
        {
            Shoot();
            // GetComponentInChildren<DeagleWeaponRecoil>().Fire();
        }
    }

    private void Shoot()
    {
        if (readyToShoot && bulletsLeft > 0)
        {
            GetComponentInParent<SoundManager>().Play(0, 0.065f);
            bulletsLeft--;
            GetComponent<Animator>().Play("Reload", 0, 0);

            GetComponent<CamRecoil>().Fire();
            GetComponentInParent<PlayerMovement>().ShotJump();

            for (int i = 0; i < bulletsPerTap; i++)
            {
                float x = bulletsShot == 0 ? 0 : Random.Range(-spread, spread);
                float y = bulletsShot == 0 ? 0 : Random.Range(-spread, spread);
                float z = bulletsShot == 0 ? 0 : Random.Range(-spread, spread);
                x = bulletsShot < 5 ? Mathf.Sqrt(bulletsShot / 3.5f) * x : x;
                y = bulletsShot < 5 ? Mathf.Sqrt(bulletsShot / 3.5f) * y : y;
                z = bulletsShot < 5 ? Mathf.Sqrt(bulletsShot / 3.5f) * z : z;

                bulletsShot++;

                Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, z);

                if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
                {
                    Debug.Log(rayHit.collider.name);

                    if (rayHit.collider.CompareTag("Enemy"))
                    {
                       // GetComponent<AnemySpawn>().IsAnemyDead(rayHit.collider.GetComponent<Anemy>().IsAlive, rayHit.collider.GetComponent<Anemy>().name);
                         rayHit.collider.GetComponentInParent<Anemy>().TakeDamage(this.damage);
                    }
                    else if (rayHit.collider.CompareTag("Head"))
                    {
                        rayHit.collider.GetComponentInParent<Anemy>().TakeDamage(this.damage * 2);
                    }
                    else if(rayHit.collider.CompareTag("BulletDropped")){
                        Destroy(rayHit.collider.gameObject, 0.05f);
                    }

                    if (rayHit.rigidbody != null)
                    {
                        rayHit.rigidbody.AddForce(-rayHit.normal * 60);
                        rayHit.rigidbody.transform.parent = null;
                    }
                }

                TrailRenderer trailTemp = Instantiate(trail, attackPoint.position + new Vector3(0.25f, -0.05f, 0.05f), Quaternion.identity);
                StartCoroutine(SpawnTrail(trailTemp, rayHit));

                GameObject impact = Instantiate(bulletHoleGraphic, rayHit.point + (rayHit.normal * .01f), Quaternion.LookRotation(rayHit.normal));
                impact.transform.parent = rayHit.transform;

                

                if (rayHit.collider != null)
                {
                    if (rayHit.collider.CompareTag("Door"))
                    {
                        var doors = rayHit.collider.gameObject;
                        doors.GetComponentInParent<FastOpen>().OpenFastDoorWithShotgun();
                    }
                    else if(!rayHit.collider.CompareTag("Enemy") && !rayHit.collider.CompareTag("Head"))
                    {
                        ParticleSystem sparksTemp = Instantiate(sparks, rayHit.point + (rayHit.normal * .01f), Quaternion.LookRotation(rayHit.normal));
                        sparksTemp.transform.parent = rayHit.transform;
                        StartCoroutine(SpawnSparks(sparksTemp, rayHit));
                    }
                }
            }
            
            muzzleFlash.Play();
            // shotFlash.Play();
            var tempSmoke = Instantiate(shotFlash, shotFlash.transform.position, shotFlash.transform.rotation);
            tempSmoke.Play();
            tempSmoke.tag = "Smoke";

            readyToShoot = false;
            Invoke("ResetShot", 1.06f);
        }
    }
    public void SpawnShells()
    {
        GameObject tempshell = Instantiate(shell, shellFalling.transform.position + new Vector3(Random.Range(0,2f),Random.Range(0,2f),Random.Range(0,2f)), Quaternion.LookRotation(-fpsCam.transform.forward));
        GameObject tempshell2 = Instantiate(shell, shellFalling.transform.position + new Vector3(Random.Range(0,2f),Random.Range(0,2f),Random.Range(0,2f)), Quaternion.LookRotation(-fpsCam.transform.forward));
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
