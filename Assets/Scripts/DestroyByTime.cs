using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    [SerializeField]
    private float lifeTime;

	private bool _dragAndThrow;
	private bool _hasCaughted;



	void Update()
    {
		_dragAndThrow = this.GetComponent<DragAndThrow> ().isThrow;
		_hasCaughted = this.GetComponent<PokeballManager> ().HasCaught;

        if (_dragAndThrow) {
            StartCoroutine(Espera());
        }
    }



    IEnumerator Espera()
    {
        yield return new WaitForSeconds(3f);

		if (!_hasCaughted)
        {
			GameObject.Find ("GameManager").GetComponent<GameManager> ().isDestroy = true;
            Destroy(gameObject, lifeTime);
        }
    }

}
