using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    public int damage;
    public float timeBetweenShooting,spread,range,reloadTime,timeBetweenShots;
    public int magazineSize,bulletsPerTap;
    public bool allowButtonHold;
    public int bulletsLeft, bulletsShot;

    bool shooting,readyToShoot,reloading;

    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    public GameObject bulletHoleGraphic;
    public ParticleSystem muzzleFlash;
    public ParticleSystem ribbonSmoke;
    public ParticleSystem cartridge;

    public bool isRibbonEnabled;
    public float RibbonTimeAlive = 2f;
    private void Awake()
    {
        fpsCam = Camera.main;
        Invoke("AllowShoot", 0.2f);
        ribbonSmoke.Stop();
        bulletsLeft = magazineSize;
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

        if(shooting)
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
        if(readyToShoot && bulletsLeft > 0)
        {
            bulletsLeft--;
            bulletsShot++;
            readyToShoot = false;
            cartridge.Play();

            float x = bulletsShot == 0 ? 0 : Random.Range(-spread, spread) + bulletsShot * spread * Random.Range(-0.2f, 0.2f);
            float y = bulletsShot == 0 ? 0 : Random.Range(-spread, spread) + bulletsShot * spread * Random.Range(0.02f, 0.06f);

            Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

            if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
            {
                Debug.Log(rayHit.collider.name);

                if (rayHit.collider.CompareTag("Enemy"))
                {
                    // rayHit.collider.GetComponent
                }
            }
            
            HandleAllBulletsLeftRibbon();

            Instantiate(bulletHoleGraphic, rayHit.point + (rayHit.normal * .01f), Quaternion.LookRotation(rayHit.normal));
            muzzleFlash.Play();

            Invoke("ResetShot", timeBetweenShooting); 
        }
    }
    private void HandleRibbon()
    {
        if(bulletsShot != 30 && bulletsShot > 20 && !shooting)
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
        if(bulletsLeft <= 0 && bulletsShot == 30)
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
        if(Muzzle != null)
        {
            Destroy(Muzzle);
        }
    }
}
