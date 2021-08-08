using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCarros : MonoBehaviour
{
    public Rigidbody2D rb;
    private float speed;    
    private MovePlayer scriptPlayer;
    void Start()
    {
        scriptPlayer = GameObject.Find("player").GetComponent<MovePlayer>();
        rb = GetComponent<Rigidbody2D>();
        speed = Random.Range(100,300);
        rb.velocity = Vector2.down * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(scriptPlayer.pontoReal > 3000)
        {
            speed = 400;
        }
        else if(scriptPlayer.pontoReal > 5000)
        {
            speed = 500;
        }
        else if(scriptPlayer.pontoReal > 10000)
        {
            speed = Random.Range(700, 900);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("destruir") || other.gameObject.CompareTag("inimigo"))
        {
            Destroy(this.gameObject);
        }
    }
}
