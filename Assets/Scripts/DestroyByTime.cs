using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    [SerializeField]
    private float lifeTime;

    private DragAndThrow _dragAndThrow;
    private PokeballManager _pokeballManager;

    void Start()
    {
        _dragAndThrow = GameObject.Find("PokeballManager").GetComponent<DragAndThrow>();
        _pokeballManager = GameObject.Find("PokeballManager").GetComponent<PokeballManager>();

        
    }
    void Update()
    {
        if (_dragAndThrow.isThrow) {

            StartCoroutine(Espera());
        }
    }

    IEnumerator Espera()
    {
        yield return new WaitForSeconds(3);

		if (!_pokeballManager.HasCaught)
        {
            Destroy(gameObject, lifeTime);
        }
    }

}
