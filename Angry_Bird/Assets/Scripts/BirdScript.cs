using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    private Vector3 inital_position;  //Initial position of the bird
    private Vector3 end_position;  //Final position of the bird
    public int initial_speed;  //Initial Speed of the Bird
    public string Scene_Name;  //Current Scene 
    
    public GameObject trajectoryDot;
    private GameObject[] trajectoryDots;
    public int number;
    private Vector3 forceAtPlayer;
   
    public Vector2 pos {get {return transform.position;}}  //Return current position of the bird

    public void Awake()
    {
        inital_position = transform.position;  //Getting the starting position
        trajectoryDots = new GameObject[number];
    }
    
    private void OnBecameInvisible() 
    {
       SceneManager.LoadScene(Scene_Name);   
    }

    public void OnMouseDown()
    {
       GetComponent<SpriteRenderer>().color = Color.red;
        for (int i = 0; i < number; i++)
        {
            trajectoryDots[i] = Instantiate(trajectoryDot, gameObject.transform);
        }
    }

    public void OnMouseUp()
    {
       GetComponent<SpriteRenderer>().color = Color.white;
       GetComponent<Rigidbody2D>().gravityScale = 1;

       Vector2 force = (inital_position - end_position) * initial_speed; //Calculating the force
       GetComponent<Rigidbody2D>().AddForce(force);
       GetComponent<Rigidbody2D>().drag = 1.0f;

       for (int i = 0; i < number; i++)
            {
                Destroy(trajectoryDots[i]);
            }  

    }

    public void OnMouseDrag()
    {
        end_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(end_position.x,end_position.y);
        forceAtPlayer = inital_position - end_position;

        for (int i = 0; i < number; i++)
        {
            trajectoryDots[i].transform.position = calculatePosition(i * 0.1f);
        }
        
    }

      private Vector2 calculatePosition(float elapsedTime) 
      {
        return new Vector2(end_position.x, end_position.y) + //X0 
        new Vector2(-forceAtPlayer.x * initial_speed, -forceAtPlayer.y * initial_speed) * elapsedTime + //ut
                0.5f * Physics2D.gravity * elapsedTime * elapsedTime ;
    }
}
