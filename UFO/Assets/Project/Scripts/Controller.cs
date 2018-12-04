using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Controller : MonoBehaviour {
    
    [SerializeField]
    float speed;
    protected Joystick joystick;
    protected Up upButton;
    protected Down downButton;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>();
        upButton = FindObjectOfType<Up>();
        downButton = FindObjectOfType<Down>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 1f, Mathf.Infinity), transform.position.z);
        rb.velocity = new Vector3(joystick.Horizontal * speed,  rb.velocity.y, joystick.Vertical * speed);
        print(upButton.pressed);
        print(downButton.pressed);
        if (upButton.pressed)
        {
            //rb.velocity += Vector3.up * speed/5;
           rb.AddForce(Vector3.up * speed/100, ForceMode.Impulse);
        }
        if (downButton.pressed)
        {
            rb.AddForce(Vector3.down * speed / 100, ForceMode.Impulse);
        }
    }
}
