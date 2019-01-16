using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndThrow : MonoBehaviour {

	private bool dragging = false;
	public bool isThrow = false;
	private float distance;
	public float ThrowSpeed;
	public float ArchSpeed;
	public float Speed;
	[SerializeField]
	private Camera mainCamera;


	// Use this for initialization
	void OnMouseDown () {
		//Obtenemos la distancia entre la camara y la pokebola
		distance = Vector3.Distance (this.transform.position, mainCamera.transform.position);

		dragging = true;
	}

	void OnMouseUp () {
		//Activamos la gravedad en la pokebola
		this.GetComponent<Rigidbody> ().useGravity = true;
		//Le damos una velocidad a la bola hacia adelante y hacia arriva
		this.GetComponent<Rigidbody> ().velocity += this.transform.forward * ThrowSpeed;
		this.GetComponent<Rigidbody> ().velocity += this.transform.up * ArchSpeed;
		dragging = false;
		isThrow = true;
	}

	
	// Update is called once per frame
	void Update () {
		if (dragging) {
			//Generamos un rayo de la posición del mouse
			//esto nos servira para mover con el mouse la pokebola, 
			//acomodarla y despues lanzarla
			Ray ray = mainCamera.ScreenPointToRay (Input.mousePosition);
			Vector3 rayPoint = ray.GetPoint (distance);
			transform.position = Vector3.Lerp (this.transform.position, rayPoint, Speed * Time.deltaTime);
		}
	}
}
