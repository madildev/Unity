using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float SmoothedSpeed = 0.125f;
    public Vector3 offset;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position,desiredPosition,SmoothedSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(player);
    }
    
    public void RestartGame()
    {
       
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
 
    }
     

}

