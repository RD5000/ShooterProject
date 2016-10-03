using UnityEngine;
using System.Collections;

public class FloorScript : MonoBehaviour {

    private int speed;

    private Transform floorTransform;

    public int Speed {
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
        this.floorTransform = this.GetComponent<Transform>();

        this.reset();
	}
	
	// Update is called once per frame
	void Update () {
        this.move();
        this.checkbounds();
	}

    private void move()
    {
        Vector2 newPosition = this.transform.position;

        newPosition.y -= this.speed;

        this.transform.position = newPosition;
    }

    private void checkbounds()
    {
        if (this.transform.position.y <= -440f)
        {
            this.reset();
        }
    }

    private void reset()
    {
        this.speed = 5;
        this.transform.position = new Vector2(0f, 440f);
    }
}
