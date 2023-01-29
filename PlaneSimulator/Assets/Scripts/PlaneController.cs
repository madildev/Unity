using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneController : MonoBehaviour
{
     public float fwspd = 10;     //Forward Speed
     public float YawAmount = 120;  //Truning Speed
     public TextMeshProUGUI countText;  //The Score element
     public GameObject Player;  //The Player object
     public GameObject winTextObject;  //The Win Message
     public GameObject loseTextObject;  //The Lose Message 
     public GameObject loseButtonObject; //Retry Button
     public GameObject WinButtonObject;  //Play Again Button

     private float Yaw;  //The Horizontal Rotation
     private float Score;  //User's Score
   
    

    //It is called at the start of the scene  

    void Start()
    {
        Score = 0;    
        SetCountText();
        Player.SetActive(true);  //It sets the Player State
        winTextObject.SetActive(false);  //It sets the Win Text Objet
        loseTextObject.SetActive(false); //It sets the Lose Text Object
        loseButtonObject.SetActive(false);   //It sets the Retry Button
        WinButtonObject.SetActive(false);   //It sets the Play Again Button
        Time.timeScale = 1;   //It start the time of the frame
    } 


    // Update is called once per frame
    void Update()
    {    
        //moves forward
         transform.position += transform.forward * fwspd * Time.deltaTime;


         //inputs 
         float HorizontalInput = Input.GetAxis("Horizontal");
         float VerticalInput = -Input.GetAxis("Vertical");


         //Yaw , pitch and roll
         Yaw += HorizontalInput * YawAmount * Time.deltaTime;  //Left Right Movement 

         float Pitch = Mathf.Lerp(0,30,Mathf.Abs(VerticalInput)) * Mathf.Sign(VerticalInput); //Up and Down Movement 
         float Roll = Mathf.Lerp(0,20,Mathf.Abs(HorizontalInput)) * -Mathf.Sign(HorizontalInput);   //Right and Left Tilt Movement

         //apply roll
         transform.localRotation = Quaternion.Euler(Vector3.up * Yaw + Vector3.right * Pitch + Vector3.forward * Roll);
         

    }

    //This is will count the User Score
     void SetCountText()
	{
		countText.text = "Score: " + Score.ToString();  //It displays the User Score

       if (Score >= 5) 
		{
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);   
            WinButtonObject.SetActive(true);
            Time.timeScale = 0;
        }   
        
	}

    //This is called when a collision occurs
     private void OnTriggerEnter(Collider other)
    {
        //It checks the collision with the Goal
        if (other.gameObject.CompareTag("Goal")) 
        {

            // Add one to the score variable 'count'
			Score = Score + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText ();
        }

        //It Checks the Collision with the Hurdle
        if(other.gameObject.CompareTag("Hurdle"))
        {
            Player.SetActive(false);
            loseTextObject.SetActive(true);
            loseButtonObject.SetActive(true);
        }
        
    }



}
