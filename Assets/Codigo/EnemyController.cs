using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
     private SpriteRenderer sr;
    private Rigidbody2D rb2d;
    private float speed = 8;
    // Start is called before the first frame update
    void Start()
    {
         sr= GetComponent<SpriteRenderer>();//obtengo el objeto spriterender de player
        rb2d = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
          sr.flipX = true;
            rb2d.velocity = new Vector2(-speed,rb2d.velocity.y); 
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "player"){
                Debug.Log("player");
                 Destroy(other.gameObject);
        }
    } 
}
