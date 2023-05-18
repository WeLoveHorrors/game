using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRecoil : MonoBehaviour
{
    GameObject CamHolder;
    float CameraVelocity;

    public float offsetX, offsetY;
	Vector3 targetRotation, currentRotation;
    private void Awake()
    {
        CamHolder = GameObject.FindGameObjectWithTag("CamWeaponHolder");
    }
	void Update()
	{
		targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, Time.deltaTime * 8);
		currentRotation = Vector3.Slerp(currentRotation, targetRotation, Time.fixedDeltaTime * 10);
		CamHolder.transform.localRotation = Quaternion.Euler(currentRotation);
    }

	public void Fire()
	{
		targetRotation += new Vector3(Random.Range(-offsetX, offsetX), Random.Range(-offsetY, offsetY), Random.Range(-offsetY, offsetY));
	}
}
