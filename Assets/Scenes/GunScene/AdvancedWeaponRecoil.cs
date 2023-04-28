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
	public float positionalRecoilSpeed = 8f;
	public float rotationalRecoilSpeed = 8f;
	[Space(10)]

	public float positionalReturnSpeed = 18f;
	public float rotationalReturnSpeed = 38f;
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

	private void FixedUpdate()
	{
		rotationalRecoil = Vector3.Lerp(rotationalRecoil, Vector3.zero, rotationalReturnSpeed * Time.deltaTime);
		positionalRecoil = Vector3.Lerp(positionalRecoil, Vector3.zero, positionalReturnSpeed * Time.deltaTime);
        rotationalMuzzleRecoil = Vector3.Lerp(rotationalMuzzleRecoil, Vector3.zero,  rotationalReturnSpeed * Time.deltaTime);

		recoilPosition.localPosition = Vector3.Slerp(recoilPosition.localPosition, positionalRecoil, positionalRecoilSpeed * Time.deltaTime);
		Rot = Vector3.Slerp(Rot, rotationalRecoil, rotationalRecoilSpeed * Time.deltaTime);
		rotationPoint.localRotation = Quaternion.Euler(Rot);
        MuzzlePosition.localPosition = Vector3.Slerp(recoilPosition.localPosition + new Vector3(Random.Range(-0.025f, 0.025f), Random.Range(-0.025f, 0.025f), Random.Range(-0.025f, 0.025f)), positionalRecoil, positionalRecoilSpeed * Time.deltaTime);

        MuzzleRot = Vector3.Slerp(MuzzleRot, rotationalRecoil, rotationalRecoilSpeed * Time.deltaTime);
        MuzzlePosition.localRotation = Quaternion.Euler(Random.Range(0, 360), 270, Random.Range(-10, 10));
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.Mouse0))
		{
			Fire();
		}
	}

	public void Fire()
	{
        float movingRight = Input.GetAxisRaw("Horizontal");
		rotationalRecoil += new Vector3(RecoilRotation.x * (movingRight >= 0 ? 1 : 0.35f), Random.Range(-RecoilRotation.y, RecoilRotation.y), Random.Range(-RecoilRotation.z, RecoilRotation.z));
		rotationalRecoil += new Vector3(Random.Range(-RecoilKickBack.x, RecoilKickBack.x), Random.Range(-RecoilKickBack.y, RecoilKickBack.y), RecoilKickBack.z);

		// rotationalMuzzleRecoil += new Vector3(RecoilRotation.x * (movingRight >= 0 ? 1 : 0.35f), Random.Range(-RecoilRotation.y, RecoilRotation.y), Random.Range(-RecoilRotation.z, RecoilRotation.z));
		// rotationalMuzzleRecoil += new Vector3(Random.Range(-RecoilKickBack.x, RecoilKickBack.x), Random.Range(-RecoilKickBack.y, RecoilKickBack.y), RecoilKickBack.z);

	}
}