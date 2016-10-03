using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {


    //Private Instance Variables; Stop looking here, its like, private man.
    private Transform playerTransform;
    private Vector2 currentPosition;
    private float playerInput;
    private float speed;
    //So that gun doesn't come out from the left/right of character
    private Quaternion rot = Quaternion.Euler(new Vector3(0, 0, 0));

    // Public Instance Variables things. So you can look here. I don't really care.
    public GameController gameController;
    public FoodController foodContoller;

    public Transform bullet;
    public float bulletDistance = .2f;

    public float timeBetweenFires = .3f;
    public float timeTilNextFire = 0.0f;

    public List<KeyCode> shootButton;

    

    // Use this for initialization
    void Start () {
        this.speed = 5;

        
        this.playerTransform = this.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        this.move();

        foreach (KeyCode element in shootButton)
        {
            if (Input.GetKey(element) && timeTilNextFire < 0)
            {
                timeTilNextFire = timeBetweenFires;
                shootGun();
                break;
            }
        }
        timeTilNextFire -= Time.deltaTime;
	}

    //Movement, because that's important for the game.
    private void move()
    {
        this.currentPosition = this.transform.position;

        this.playerInput = Input.GetAxis("Horizontal");

        if (this.playerInput > 0)
        {
            this.currentPosition += new Vector2(this.speed, 0);
        }

        if (this.playerInput < 0)
        {
            this.currentPosition -= new Vector2(this.speed, 0);
        }

        this.transform.position = new Vector3(Mathf.Clamp(this.currentPosition.x, -340f, 340f), -120f, -5f);
    }

    private void shootGun()
    {
        Vector3 bulletPos = this.transform.position;
        bulletPos.x = this.transform.position.x + 20f;
        bulletPos.y = this.transform.position.y + 75f;
        bulletPos.z = -5f;

        Instantiate(bullet, bulletPos, rot);

    }

    //Triggers in case you misidentify the player. Actually these are for Collision Detection
    private void OnCollision2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("food"))
        {
            this.gameController.ScoreValue += 1;
    
            
           
        }
        if (other.gameObject.CompareTag("enemy"))
        {
            this.gameController.LivesValue -= 1;
        }
    }
}
