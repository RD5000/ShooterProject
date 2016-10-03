using UnityEngine;
using System.Collections;

public class ZombieBehavior : MonoBehaviour {

    //Private Variables. S-s-s-s-senpai. Stop looking here. It's Private
    private int speed;
    private int drift;
    private Transform zombieTransfom;

    //Public variables
    public int health = 2;

    //Public Properties
    public int Speed
    {
        get { return this.speed; }
        set { this.speed = value; }
    }
    public int Drift
    {
        get { return this.drift; }
        set { this.drift = value; }
    }

	// Use this for initialization
	void Start () {
        this.zombieTransfom = this.GetComponent<Transform>();

        this.reset();
	}
	
	// Update is called once per frame
	void Update () {
        this.move();
        this.checkBounds();
	}

    private void move()
    {
        Vector2 newPosition = this.transform.position;

        newPosition.y -= this.Speed;
        newPosition.x += this.Drift;
    }

    private void checkBounds()
    {
        if (this.transform.position.y <= -250f)
        {
            this.reset();
        }
    }

    private void OnCollisionEnter2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.CompareTag("bullet"))
        {
            BulletScript bullet = theCollision.gameObject.GetComponent("BulletScript") as BulletScript;
            health -= bullet.damage;
            Destroy(theCollision.gameObject);
        }
        if (theCollision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit" + theCollision.gameObject.name);

        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void reset()
    {
        
        this.Speed = Random.Range(400, 600);
        this.Drift = Random.Range(-200, 200);
        this.transform.position = new Vector3(Random.Range(-340f, 340f), 250f, -5f);
    }
}
