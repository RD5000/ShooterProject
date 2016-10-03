using UnityEngine;
using System.Collections;
using System;

public class FoodController : MonoBehaviour {

    //Private Variables. Please stop lookg over here. Its Private.
    private int speed;
    private Transform enemyTransform;

    //Public Properties. Unfortunately not for lease.
    public int Speed
    {
        get
        {
            return this.speed;
        }
        set
        {
            this.speed = value;
        }
    }
	// Use this for initialization
	void Start () {
        this.enemyTransform = this.GetComponent<Transform>();

        this.reset();
	}
	
	// Update is called once per frame
	void Update () {
        this.move();
        this.checkBounds();
	}

    //Method for moving Food.
    private void move()
    {
        Vector3 newPosition = this.transform.position;

        newPosition.y -= this.speed;

        this.transform.position = newPosition;
    }
    //Makes sure that food doesn't go beyond the bounds.
    private void checkBounds()
    {
        if (this.transform.position.y <= -250f)
        {
            this.reset();
        }
    }
    //Makes sure that food resets.
    private void reset()
    {
        this.speed = UnityEngine.Random.Range(4, 6);
        this.transform.position = new Vector3(UnityEngine.Random.Range(-340f, 340f), 250f, -5f);
    }


}
