using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour{
    Vector2 StartPos;
    Vector2 CheckpointPos;
    private Animator anim;
    private Rigidbody2D rb;

public PlayerHearts ph;
     void Start()
    {
         Physics2D.IgnoreLayerCollision(8,9);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ph = GetComponent<PlayerHearts>();
        CheckpointPos = transform.position;
        StartPos = transform.position;
    }
    IEnumerator Respawn(float duration){
        
        anim.SetTrigger("Death");
        rb.velocity = new Vector2(0,0);
        rb.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(duration);
        transform.position = StartPos;
        ph.health=3;
        rb.bodyType = RigidbodyType2D.Dynamic;
    } 
        private void Die()
    {
        StartCoroutine(Respawn(1.1f));
        anim.SetTrigger("Respawn");
    }
       
        
       IEnumerator GetHurt(){
        Physics2D.IgnoreLayerCollision(7,8);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(7,8, false);
    }

        
    

   private void OnCollisionEnter2D (Collision2D collision){
        Debug.Log("it triggered");
        if (collision.gameObject.CompareTag("death")){
           ph.health--;


           if(ph.health <=0)  {
                        Die(); 
  
            }
            
            else{
                StartCoroutine(GetHurt());
            }
        }
            if (collision.gameObject.CompareTag("losetwo")){
           ph.health = ph.health-2;


           if(ph.health <=0)  {
                        Die(); 
  
            }
            
       
            else{
                StartCoroutine(GetHurt());
            }

           }
         if (collision.gameObject.CompareTag("instantdeath")){
       ph.health = 0; 
       Die();
      }
   }
}