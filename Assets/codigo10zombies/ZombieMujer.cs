using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMujer : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rb2d;
    private float speed = 50;
    private bool limiteInicio = true;
    private bool limiteFin = false;
    // Start is called before the first frame update
    void Start()
    {
         sr= GetComponent<SpriteRenderer>();//obtengo el objeto spriterender de player
        rb2d = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
      
          if(limiteInicio){
             sr.flipX = true;
             rb2d.velocity = new Vector2(rb2d.velocity.x,speed);  
             
        }
         if(limiteFin){
              sr.flipX = false;
            rb2d.velocity = new Vector2(rb2d.velocity.x,-speed-50);  
        }       
    }
     void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.layer == 9){
                limiteInicio = false;
                limiteFin = true;
        }
        if(other.gameObject.layer == 10){
                 
                limiteFin = false;
                limiteInicio = true;
        }
    }
}
