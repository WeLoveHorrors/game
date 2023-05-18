using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeagleWeaponRecoil : MonoBehaviour
{
    [Header("Reference Points")]
	public Transform recoilPosition;
	public Transform rotationPoint;
	Vector3 Rot;

	Vector3 rotationalRecoil;
	Vector3 positionalRecoil;
    
	public Vector3 RecoilRotation = new Vector3(10, 5, 7);
	public Vector3 RecoilKickBack = new Vector3(0.015f, 0f, -0.2f);
	public Vector3 PositionalRecoil = new Vector3(0.0055f, 0.17f, 0f);
    
    [Space(10)]
	public float positionalReturnSpeed = 20f;
	public float rotationalReturnSpeed = 44.5f;

	[Header("Speed Settings")]
	public float positionalRecoilSpeed = 30f;
	public float rotationalRecoilSpeed = 70f;

	Vector3 targetRotation, currentRotation;
    private void Awake()
    {
	}

    // Update is called once per frame
    void Update()
	{
		// if (Input.GetKey(KeyCode.Mouse0))
		// {
		// 	Fire();
		// }
	}

	public void Fire()
	{
        float movingRight = Input.GetAxisRaw("Horizontal");
        positionalRecoil = PositionalRecoil;
		rotationalRecoil = new Vector3(RecoilRotation.x * (movingRight >= 0 ? 1 : 0.35f), 2f, Random.Range(-RecoilRotation.z, RecoilRotation.z));
		rotationalRecoil = new Vector3(Random.Range(-RecoilKickBack.x, RecoilKickBack.x), Random.Range(-RecoilKickBack.y, RecoilKickBack.y), RecoilKickBack.z - 80);
        
		recoilPosition.localPosition = Vector3.Slerp(recoilPosition.localPosition, positionalRecoil, positionalRecoilSpeed * Time.deltaTime);
		Rot = Vector3.Slerp(Rot, rotationalRecoil, rotationalRecoilSpeed * Time.deltaTime);
		rotationPoint.localRotation = Quaternion.Euler(Rot);
    }

	private void FixedUpdate()
	{
		rotationalRecoil = Vector3.Slerp(rotationalRecoil, Vector3.zero, rotationalReturnSpeed * Time.deltaTime);
		positionalRecoil = Vector3.Slerp(positionalRecoil, Vector3.zero, positionalReturnSpeed * Time.deltaTime * 0.2f);

		recoilPosition.localPosition = Vector3.Slerp(recoilPosition.localPosition, positionalRecoil, positionalRecoilSpeed * Time.deltaTime);
		Rot = Vector3.Slerp(Rot, rotationalRecoil, rotationalRecoilSpeed * Time.deltaTime);
		rotationPoint.localRotation = Quaternion.Euler(Rot);
		
		targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, Time.deltaTime * 0.2f);
		currentRotation = Vector3.Slerp(currentRotation, targetRotation, Time.fixedDeltaTime * 0.1f);
    }
}
