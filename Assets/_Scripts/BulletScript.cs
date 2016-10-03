using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    //Public Variables
    public float lifeTime = 2.0f;
    public float speed = 500.0f;
    public int damage = 1;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
	
	}
}
