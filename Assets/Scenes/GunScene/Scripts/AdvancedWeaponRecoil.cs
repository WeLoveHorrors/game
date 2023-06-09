using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedWeaponRecoil : MonoBehaviour
{
	[Header("Reference Points")]
	public Transform recoilPosition;
	public Transform rotationPoint;
    public Transform MuzzlePosition;
	[Space(10)]

	[Header("Speed Settings")]
	public float positionalRecoilSpeed = 30f;
	public float rotationalRecoilSpeed = 70f;
	[Space(10)]

	public float positionalReturnSpeed = 20f;
	public float rotationalReturnSpeed = 44.5f;
	[Space(10)]

	[Header("Amount Settings:")]
	public Vector3 RecoilRotation = new Vector3(10, 5, 7);
	public Vector3 RecoilKickBack = new Vector3(0.015f, 0f, -0.2f);
	[Space(10)]
	public Vector3 RecoilRotationAim = new Vector3(10, 4, 6);
	public Vector3 RecoilKickBackAim = new Vector3(0.015f, 0f, -0.2f);
	[Space(10)]

	Vector3 rotationalRecoil;
	Vector3 rotationalMuzzleRecoil;
	Vector3 positionalRecoil;
	Vector3 Rot;
	Vector3 MuzzleRot;

    Camera fpsCam;
    GameObject CamHolder;
	float CameraVelocity;

	Vector3 targetRotation, currentRotation;
    private void Awake()
    {
		fpsCam = Camera.main;
        CamHolder = GameObject.FindGameObjectWithTag("CamWeaponHolder");
	}

	void Update()
	{
		rotationalRecoil = Vector3.Slerp(rotationalRecoil, Vector3.zero, rotationalReturnSpeed * Time.deltaTime);
		positionalRecoil = Vector3.Slerp(positionalRecoil, Vector3.zero, positionalReturnSpeed * Time.deltaTime * 0.6f);
        rotationalMuzzleRecoil = Vector3.Lerp(rotationalMuzzleRecoil, Vector3.zero,  rotationalReturnSpeed * Time.deltaTime);

		recoilPosition.localPosition = Vector3.Slerp(recoilPosition.localPosition, positionalRecoil, positionalRecoilSpeed * Time.deltaTime);
		Rot = Vector3.Slerp(Rot, rotationalRecoil, rotationalRecoilSpeed * Time.deltaTime);
		rotationPoint.localRotation = Quaternion.Euler(Rot);
        MuzzlePosition.localPosition = Vector3.Slerp(recoilPosition.localPosition + new Vector3(Random.Range(-0.045f, 0.045f), 0, 0) + new Vector3(-0.06f, -0.005f, +0f), positionalRecoil, positionalRecoilSpeed * Time.deltaTime);
        MuzzlePosition.localScale = new Vector3(Random.Range(1.3f, 3f), Random.Range(1.3f, 3f), Random.Range(1.3f, 3f));

        MuzzleRot = Vector3.Slerp(MuzzleRot, rotationalRecoil, rotationalRecoilSpeed * Time.deltaTime);
        // MuzzlePosition.localRotation = Quaternion.Euler(Random.Range(0, 360), 270, 0);
		
		targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, Time.deltaTime * 8);
		currentRotation = Vector3.Slerp(currentRotation, targetRotation, Time.fixedDeltaTime * 10);
		CamHolder.transform.localRotation = Quaternion.Euler(currentRotation);

		// if (Input.GetKey(KeyCode.Mouse0) && GetComponentInParent<M4GunSystem>().bulletsLeft > 0)
		// {
		// 	Fire();
		// }
	}

	public void Fire()
	{
        float movingRight = Input.GetAxisRaw("Horizontal");
        positionalRecoil += new Vector3(0.08f, 0.03f, 0f);
		rotationalRecoil += new Vector3(RecoilRotation.x * (movingRight >= 0 ? 1 : 0.35f), Random.Range(-RecoilRotation.y, RecoilRotation.y), Random.Range(-RecoilRotation.z, RecoilRotation.z));
		rotationalRecoil += new Vector3(Random.Range(-RecoilKickBack.x, RecoilKickBack.x), Random.Range(-RecoilKickBack.y, RecoilKickBack.y), RecoilKickBack.z);
		
		// fpsCam.transform.localRotation = Quaternion.Euler(fpsCam.transform.localRotation.x, fpsCam.transform.localRotation.y - Random.Range(0.01f, 0.012f), fpsCam.transform.localRotation.z);
		
		// var RotationX = Mathf.SmoothDamp(CamHolder.transform.localRotation.x - , fpsCam.transform.localRotation.x, ref CameraVelocity, 100);
		// var RotationY = Mathf.SmoothDamp(CamHolder.transform.localRotation.y + Random.Range(1f, 3f), fpsCam.transform.localRotation.y, ref CameraVelocity, 100);
		// CamHolder.transform.localRotation = Quaternion.Euler(RotationX, RotationY, fpsCam.transform.localRotation.z);
		
		targetRotation += new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), 0);

		// rotationalMuzzleRecoil += new Vector3(RecoilRotation.x * (movingRight >= 0 ? 1 : 0.35f), Random.Range(-RecoilRotation.y, RecoilRotation.y), Random.Range(-RecoilRotation.z, RecoilRotation.z));
		// rotationalMuzzleRecoil += new Vector3(Random.Range(-RecoilKickBack.x, RecoilKickBack.x), Random.Range(-RecoilKickBack.y, RecoilKickBack.y), RecoilKickBack.z);

	}
}