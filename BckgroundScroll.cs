using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BckgroundScroll : MonoBehaviour
{
    private Material mt;
    private Vector2 offset;
    public float velx, vely;


    void Awake()
    {
        mt = GetComponent<Renderer>().material;
       
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector2(velx, vely);
        mt.mainTextureOffset += offset * Time.deltaTime;
    }
}
