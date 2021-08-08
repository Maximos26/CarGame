using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraCarros : MonoBehaviour
{
    public GameObject[] car;
    public float contador;
    void Start()
    {
        contador = Random.Range(1f,15f);
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = new Vector2(Random.Range(-2f, 2f), 5.7f);
        contador -= Time.deltaTime;
        if(contador <= 0)
        {
            GameObject.Instantiate(car[Random.Range(1,3)], position, Quaternion.identity);
            contador = Random.Range(1f,5f);
        }
    }
}
