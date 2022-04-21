using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CatController : MonoBehaviour
{
    private float speed = 9;
    private int amarillo = 0;
    private int rojo = 0;
    private int celeste = 0;
    private int puntaje = 0;
   
    public GameObject disparaDerecha;
    public GameObject disparaIzquierda;
    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb2d;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
         sr= GetComponent<SpriteRenderer>();//obtengo el objeto spriterender de player
      //  Debug.Log("hola mundo este es un metodo que se ejecuta una vez");
        //sr.flipX = true;
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "amarillo: "+amarillo +"     " +"rojo: " +rojo+"     "+"celeste: "+ celeste+"PUNTAJE: "+ puntaje;
         if(Input.GetKeyDown(KeyCode.X))
        {
           
            if(!sr.flipX)
            {
            var position = new Vector2(transform.position.x+2.5f,transform.position.y-0.5f);
                Instantiate(disparaDerecha,position,disparaDerecha.transform.rotation);
            }
            else{
             var position = new Vector2(transform.position.x-2f,transform.position.y-0.5f);
                Instantiate(disparaIzquierda,position,disparaIzquierda.transform.rotation);
            }
            
        }
         if(Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
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
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            sr.flipX = true;
            Caminar();
            rb2d.velocity = new Vector2(-speed,rb2d.velocity.y);
            if(Input.GetKey(KeyCode.UpArrow))
            {
            saltarF();
        
            }
             if(Input.GetKey(KeyCode.Space))
            {
            Deslizar();
            
            }
        }
        else
        {
            Quieto();
            rb2d.velocity = new Vector2(0,rb2d.velocity.y);
        }
    }
    void OnCollisionEnter2D(Collision2D other){
        
        if(other.gameObject.tag == "amarilla"){
             Destroy(other.gameObject);
             amarillo ++;
            
        }
        if(other.gameObject.tag == "roja"){
             Destroy(other.gameObject);
             rojo ++;
            
        }
        if(other.gameObject.tag == "celeste"){
             Destroy(other.gameObject);
             celeste ++;
            
        }
         
    }
     public void saltarF(){
        var upSpeed = 80f;
        rb2d.velocity = Vector2.up * upSpeed;
        Saltar();
    }
     public void Quieto(){
        animator.SetInteger("Estado", 0);
    }
    public void Caminar(){
       animator.SetInteger("Estado", 1);
    }
    public void Saltar(){
        animator.SetInteger("Estado", 2);        
    }
    public void Deslizar(){
        animator.SetInteger("Estado", 3);        
    }
    public void AumentaScore10(){
        puntaje += 10;      
    }
}
