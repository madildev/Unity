using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0;
    
    public TextMeshProUGUI countText;
	public GameObject winTextObject;
    
    private Rigidbody rb;
    
    private float movementX;
    private float movementY;

    private int count;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        winTextObject.SetActive(false);
        SetCountText();
    }

    //This will get the poistion when the ball moves
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    //This is will run when the player collides with the Cube
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);

            // Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText ();
        }
    }

//This is will count the User Score
     void SetCountText()
	{
		countText.text = "Score: " + count.ToString();

		if (count >= 8) 
		{
                    // Set the text value of your 'winText'
            winTextObject.SetActive(true);
		}
	}

}