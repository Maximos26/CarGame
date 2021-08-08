using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private int currentLane = 1;
    private Vector2 verticaltargetPosition;
    //public float speed;
    public float laneSpeed;
    private bool isSwipping = false;
    private Vector2 startingTouch;
    public Text pontos;
    public Text recorde;
    public int recordes;
    public int pontoReal;
    private bool vivo = true;
    public bool comecar = false;
    
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        if(PlayerPrefs.HasKey("recordes"))
        {
            recordes = PlayerPrefs.GetInt("recordes");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        checaScore();
        recorde.text = recordes.ToString();
        //print(recordes);
        //recorde.text = recordes.ToString();
        pontos.text = pontoReal.ToString();

         
        if(vivo)
        {
            pontoReal += 1;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            changeLane(-2);
        }

        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            changeLane(2);
        }

        if(Input.touchCount == 1)
        {
            
            if(isSwipping)
            {
                Vector2 diff = Input.GetTouch(0).position - startingTouch;
                diff = new Vector2(diff.x / Screen.width, diff.y / Screen.width);
                if(diff.magnitude > 0.01f)
                {
                    if(diff.x < 0)
                    {
                        changeLane(-2);
                    }
                    else
                    {
                        changeLane(2);
                    }

                    isSwipping = false;
                }
            }
             if(Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startingTouch = Input.GetTouch(0).position;
            isSwipping = true;
        }

        else if(Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            isSwipping = false;
        }
       
    }

       

        Vector2 targerPosition = new Vector2 (verticaltargetPosition.x, -3.4f);
        transform.position = Vector3.MoveTowards(transform.position, targerPosition, laneSpeed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        //rb.velocity = Vector2.up * speed;
    }

    void changeLane(int direction)
    {
        int targetLane = currentLane + direction;
        if(targetLane < -1 || targetLane > 3)
            return;
            currentLane = targetLane;
        verticaltargetPosition = new Vector2 (currentLane - 1, -3.4f);
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("inimigo"))
        {
            
            vivo = false;
            Destroy(this.gameObject);
            comecar = true;
            
        }
    }

    void checaScore()
    {
        if(pontoReal > recordes)
            {
                recordes = pontoReal;
                PlayerPrefs.SetInt("recordes", recordes);
            }
    }
}
