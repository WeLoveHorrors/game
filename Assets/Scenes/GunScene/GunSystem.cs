using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    public int damage;
    public float timeBetweenShooting,spread,range,reloadTime,timeBetweenShots;
    public int magazineSize,bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft,bulletsShot;

    bool shooting,readyToShoot,reloading;

    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    public GameObject bulletHoleGraphic;
    public ParticleSystem muzzleFlash;
    public ParticleSystem ribbonSmoke;

    public bool isRibbonEnabled;
    public float RibbonTimeAlive = 2f;
    private void Awake()
    {
        fpsCam = Camera.main;
        Invoke("AllowShoot", 0.2f);
        ribbonSmoke.Stop();
    }
    private void Update()
    {
        bulletsLeft = 1000;
        MyInput();
    }
    private void MyInput()
    {
        if (allowButtonHold)
            shooting = Input.GetKey(KeyCode.Mouse0);
        else
            shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (readyToShoot && shooting)
        {
            Shoot();
        }

        if(shooting)
        {
            GetComponent<Animator>().SetBool("isShooting", true);
            isRibbonEnabled = true;
            RibbonTimeAlive = 2f;
        }
        else
        {
            GetComponent<Animator>().SetBool("isShooting", false);
        }

        if(isRibbonEnabled && !shooting)
        {
            RibbonTimeAlive -= Time.deltaTime;
            if(RibbonTimeAlive > 0)
            {
                ribbonSmoke.Play();
            }
            else
            {
                ribbonSmoke.Stop();
                isRibbonEnabled = false;
            }
            //  = new Color(255,255,255,0);
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("Enemy"))
            {
                // rayHit.collider.GetComponent
            }
        }

        Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.identity);
        muzzleFlash.Play();
        // foreach(GameObject tmp in GameObject.FindGameObjectsWithTag("Muzzle"))
        // {
        //     Destroy(tmp);
        // }
        // Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity).Play();

        Invoke("ResetShot", timeBetweenShooting);
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
        if(Muzzle != null)
        {
            Destroy(Muzzle);
        }
    }
}
