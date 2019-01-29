using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private Vector3 initialPosition;
	private Quaternion inicialRotation;
	public bool isDestroy;
	private bool _instantiated;

	[SerializeField]
	GameObject pokeBallPrefab;

	[SerializeField]
	private Camera mainCamera;


	void Start()
	{
		pokeBallPrefab.GetComponent<DragAndThrow> ().mainCamera = mainCamera;
		StartCoroutine (SpawnBall ());
	}

	void Update(){
		
		if (isDestroy && !_instantiated) {
			_instantiated = true;
			StartCoroutine (SpawnBall ());
		}
	}

	//Creamos una corutina 
	IEnumerator SpawnBall()
	{
		yield return new WaitForSeconds(3f);

		Instantiate (pokeBallPrefab, pokeBallPrefab.transform.position, Quaternion.identity);

		_instantiated = false;
		isDestroy = false;
	}
}
