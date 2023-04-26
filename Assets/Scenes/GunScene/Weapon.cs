using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject[] loadout;
    public Transform weaponParent;

    private GameObject currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        Equip(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) Equip(0);
        else if(Input.GetKeyDown(KeyCode.Alpha2)) Equip(1);
    }

    void Equip(int p_ind)
    {
        if(currentWeapon != null) Destroy(currentWeapon);

        GameObject t_newWeapon = Instantiate (loadout[p_ind], weaponParent.position, weaponParent.rotation, weaponParent) as GameObject;
        t_newWeapon.transform.localPosition = Vector3.zero;
        t_newWeapon.transform.localEulerAngles = Vector3.zero;

        currentWeapon = t_newWeapon;
    }
}
