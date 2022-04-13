using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    private float speed = 12;
    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb2d;
    private bool  colision=false;

    // Start is cald before the first frame update
    void Start()
    {
          sr= GetComponent<SpriteRenderer>();//obtengo el objeto spriterender de player
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
       
       
             Caminar();
             rb2d.velocity = new Vector2(speed,rb2d.velocity.y);
            if(Input.GetKey(KeyCode.UpArrow))
            {
                 Saltar();
                saltarF();
               
            }
            if(colision){
                 Morir();
                 rb2d.velocity = new Vector2(0,rb2d.velocity.y);
            }
        
        
    }
    void OnCollisionEnter2D(Collision2D other){       
              if(other.gameObject.layer == 6){
               colision=true;
                 } 
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "traspaso"){
                Debug.Log("traspaso");
                 speed += 5f;
                 
        }
         if(other.gameObject.tag == "muere"){
                 Destroy(this.gameObject);
        }
    } 

     public void saltarF(){

        var upSpeed = 80f;
        rb2d.velocity = Vector2.up * upSpeed;
       
    }
    
    public void Caminar(){
       animator.SetInteger("Estado", 0);
    }
     public void Saltar(){
        animator.SetInteger("Estado", 1);        
    }
    public void Morir(){
        animator.SetInteger("Estado", 2);        
    }
}
