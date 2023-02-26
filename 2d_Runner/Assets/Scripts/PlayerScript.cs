using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int PlayerSpeed = 4;
    public int JumpForce = 6;
    private Animator PlayerAnimator;
    private SpriteRenderer SpriteRenderer;
    private Rigidbody2D _RigidBody;
    private AudioManager AudioManager;
    private ScoreBoard ScoreBoard;
     
    // Start is called before the first frame update
    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        _RigidBody = GetComponent<Rigidbody2D>();
        AudioManager = GameObject.FindObjectOfType<AudioManager>();
        ScoreBoard = ScoreBoard.getInstance();
    }

    // Update is called once per frame
    void Update()
    {
       float x = Input.GetAxis("Horizontal");
       if(x != 0 && x > 0)
       {
          PlayerAnimator.enabled = true;
          SpriteRenderer.flipX = false;
       }
       else if(x != 0 && x < 0)
       {
           SpriteRenderer.flipX = true;
           PlayerAnimator.enabled = true;
       }
       else
       {
          PlayerAnimator.enabled = false;
       }

       if(Input.GetButtonDown("Jump"))
       {
          _RigidBody.AddForce(new Vector2(0,JumpForce),ForceMode2D.Impulse);
          AudioManager.PlaySound("Jump");
       }
       Vector3 movement = new Vector3(x,0,0);
       transform.Translate(movement * PlayerSpeed * Time.deltaTime); 
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Fruit"))
        {
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Monster"))
        {
            ScoreBoard.AddScore(-10);
        }
    }

}
