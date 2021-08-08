using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mudaCena : MonoBehaviour
{
    public string cena;
    public bool passaCena;
    void Start()
    {
        passaCena = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            passaCena = true;
        }
       //else if(Input.GetTouch(0).phase == TouchPhase.Began)
       // {
            
       //     passaCena = true;
        //}

        //if(passaCena && Input.GetTouch(0).phase == TouchPhase.Ended)
        //{
        //    SceneManager.LoadScene(cena);
       // }

        if(Input.GetKey(KeyCode.Space) && passaCena)
        {
            SceneManager.LoadScene(cena);
        }
            

    }

    public void clear()
    {
        PlayerPrefs.DeleteAll();
    }

}
