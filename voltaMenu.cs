using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class voltaMenu : MonoBehaviour
{
    public float contador = 3;
    public MovePlayer mv;
    void Start()
    {
        mv = GameObject.Find("player").GetComponent<MovePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(contador <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
        if(mv.comecar == true)
        {
            contador -= Time.deltaTime; 
        }
    }
}
