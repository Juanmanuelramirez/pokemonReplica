using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeballManager : MonoBehaviour
{
	public bool HasCaught = false;
	public float finalShake;


	void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Pokemon") {

            Debug.Log(HasCaught);
            HasCaught = true;
            StartCoroutine ("CatchPokemon", other.gameObject);
		}
    }

    // Update is called once per frame
	IEnumerator CatchPokemon(GameObject Pokemon)
    {
        

        transform.Translate (Vector3.up * 0.1f, Space.World);
		this.GetComponent<Rigidbody> ().useGravity = false;
		this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		Destroy (Pokemon.gameObject);
		yield return new WaitForSeconds (1);

		this.GetComponent<Rigidbody> ().useGravity = true;
		yield return new WaitForSeconds (1);

		this.GetComponent<Rigidbody> ().isKinematic = true;
		this.GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0f, 0f, 0f);

		GameObject.FindGameObjectWithTag ("Player").transform.LookAt (this.transform);
		GameObject.FindGameObjectWithTag ("Player").gameObject.GetComponent<Camera> ().fieldOfView = 8.2f;

		for (int i = 0; i <= 3; i++) {
			if (i == 3)
				finalShake = +(finalShake * 3f);
			yield return new WaitForSeconds (1);
			transform.Rotate (Vector3.right * finalShake);
			yield return new WaitForSeconds (0.1f);
			transform.Rotate (-Vector3.right * finalShake);
		}

    }
}
