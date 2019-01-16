using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnder : MonoBehaviour
{
	public GameObject _ballPrefab;


	void Start()
	{
		
	}

	public void StartCourutine(){
		StartCoroutine(SpawnBall());
	}

	//Creamos una corutina 
	IEnumerator SpawnBall()
	{
        yield return new WaitForSeconds(1);
    }
}
