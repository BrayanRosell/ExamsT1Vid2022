using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 9;
    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb2d;
    private int contador = 0;
    // Start is called before the first frame update
    void Start()
    {
          sr= GetComponent<SpriteRenderer>();//obtengo el objeto spriterender de player
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
       
        if(contador<10){
             Caminar();
             rb2d.velocity = new Vector2(speed,rb2d.velocity.y);
            if(Input.GetKey(KeyCode.UpArrow))
            {
            saltarF();
            }
            if(Input.GetKey(KeyCode.Space))
            {
            Deslizar();
             
            }
        }else{
            Quieto();
              rb2d.velocity = new Vector2(0,rb2d.velocity.y);
        }
        
    }
    void OnCollisionEnter2D(Collision2D other){
         if(Input.GetKey(KeyCode.Space))
            {
            Deslizar();
              if(other.gameObject.layer == 6){
                Destroy(other.gameObject);
                speed += 5f;
                 contador++;
                 }
            }
          
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "traspaso"){
                Debug.Log("traspaso");
                 speed += 5f;
                 contador++;
        }
         if(other.gameObject.tag == "muere"){
                 Destroy(this.gameObject);
        }
    } 

     public void saltarF(){
        var upSpeed = 80f;
        rb2d.velocity = Vector2.up * upSpeed;
        Saltar();
    }
    
    public void Caminar(){
       animator.SetInteger("Estado", 0);
    }
    public void Deslizar(){
        animator.SetInteger("Estado", 1);        
    }
    public void Quieto(){
        animator.SetInteger("Estado", 2);        
    }
    
     public void Saltar(){
        animator.SetInteger("Estado", 3);        
    }
    public void Morir(){
        animator.SetInteger("Estado", 4);        
    }
}
