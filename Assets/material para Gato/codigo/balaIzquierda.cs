using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaIzquierda : MonoBehaviour
{
    public float velocityX=-20f;
    private Rigidbody2D rb2d;
    private CatController playerController; 
    // Start is called before the first frame update
    void Start()
    {
         rb2d = GetComponent<Rigidbody2D>();
        playerController = FindObjectOfType<CatController>(); //lo busca
        //para eliminar gameobject
        Destroy(gameObject,4);
    }

    // Update is called once per frame
    void Update()
    {
        
             rb2d.velocity = Vector2.right * velocityX;
        
        
         //rb2d.velocity = new Vector2(10,rb2d.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D other){
        
        if(other.gameObject.tag == "traspaso" ){
            
            
                 Debug.Log("Entra");
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                playerController.AumentaScore10();
        }
      
    }
}
