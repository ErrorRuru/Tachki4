using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	[SerializeField] private Transform _carTransform;
	[Range(1, 10)]
	[SerializeField] private float _followSpeed = 2;
	[Range(1, 10)]
	[SerializeField] private float _lookSpeed = 5;
	Vector3 initialCameraPosition;

	private void Start()
	{
		initialCameraPosition = gameObject.transform.position;
	}

	private void FixedUpdate()
	{
		
		Vector3 _lookDirection = (new Vector3(_carTransform.position.x, _carTransform.position.y, _carTransform.position.z)) - transform.position;
		Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, _rot, _lookSpeed * Time.deltaTime);

		Vector3 _targetPos = initialCameraPosition + _carTransform.transform.position;
		transform.position = Vector3.Lerp(transform.position, _targetPos, _followSpeed * Time.deltaTime);
	}

}
