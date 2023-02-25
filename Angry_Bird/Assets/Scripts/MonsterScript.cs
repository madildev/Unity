using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Bird"))
        {
            gameObject.SetActive(false);
        }
      //  if(other.gameObject.CompareTag("Crate"))
       // {
         //   gameObject.SetActive(false);
       // }
    }

}
