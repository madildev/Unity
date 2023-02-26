using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    private bool Collide;  //If the monster has reached the other side
    
    // Update is called once per frame
    void Update()
    {   
        if(!Collide)
        {
              transform.Translate(new Vector3(Time.deltaTime,0,0));
              gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            transform.Translate(new Vector3(-(Time.deltaTime),0,0));
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
       
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
       if(other.gameObject.CompareTag("Stone"))
       {
          Collide = !(Collide);     
       }   
    }

}
