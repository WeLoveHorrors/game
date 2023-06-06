using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public GameObject[] loadout;
    public Transform weaponParent;
    public int currentWeaponType;
    public CanvasRenderer[] icons;
    public Image[] iconsInstances;

    public Dictionary<int, bool> WeaponAvailability;
    private GameObject currentWeapon;

    public bool EnableAllWeapons = false;

    // Start is called before the first frame update
    void Start()
    {
        if(EnableAllWeapons)
        {
            WeaponAvailability = new Dictionary<int, bool>(){
                {0, true},
                {1, true},
                {2, true}
            };
        }
        else
        {
            WeaponAvailability = new Dictionary<int, bool>(){
                {0, false},
                {1, false},
                {2, false}
            };
        }

        iconsInstances.ToList().ForEach(x=>x.enabled = false);

        currentWeaponType = -1;
        Equip(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) Equip(0);
        else if(Input.GetKeyDown(KeyCode.Alpha2)) Equip(1);
        else if(Input.GetKeyDown(KeyCode.Alpha3)) Equip(2);

        if(Input.GetKey(KeyCode.F)) currentWeapon.GetComponent<AnimationsHandle>().Inspect();
    }

    public void SetEnable(int p_ind){
        WeaponAvailability[p_ind] = true;
        iconsInstances[p_ind].enabled = true;
    }

    public void Equip(int p_ind)
    {
        if(WeaponAvailability[p_ind] && currentWeaponType != p_ind)
        {
            currentWeaponType = p_ind;

            if(currentWeapon != null)
            {
                Destroy(currentWeapon);
            }

            GameObject t_newWeapon = Instantiate (loadout[p_ind], weaponParent.position, weaponParent.rotation, weaponParent) as GameObject;
            t_newWeapon.transform.localPosition = Vector3.zero;
            t_newWeapon.transform.localEulerAngles = Vector3.zero;

            t_newWeapon.GetComponent<Animator>().Play("Equip", 0, 0);
            currentWeapon = t_newWeapon;

            DestroyAllSparks();
            icons.ToList().ForEach(x=>x.SetColor(new Color(1, 1, 1, 0.015f)));
            icons[p_ind].SetColor(new Color(0.97f, 0.97f, 0.97f, 0.5f));
        }
    }

    void DestroyAllSparks()
    {
        var Sparks = GameObject.FindGameObjectsWithTag("Spark");
        if(Sparks != null)
        {
            foreach(var item in Sparks)
            {
                Destroy(item, 0.15f);
            }
        }
        
        var Smokes = GameObject.FindGameObjectsWithTag("Smoke");
        if(Smokes != null)
        {
            foreach(var item in Smokes)
            {
                Destroy(item, 0.6f);
            }
        }
    }
}
