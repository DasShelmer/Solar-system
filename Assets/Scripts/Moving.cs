using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour {
    public float CamSpeed = 20;
    public Vector2 Sensivity = new Vector2(3 , 3);
    Rigidbody PlayerRb;


    void Start (){
        PlayerRb = transform.GetComponent<Rigidbody>();

    }
	
	void FixedUpdate () {

        Vector3 forward = transform.TransformDirection(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));


        if (Input.GetAxisRaw("Fire2") != 0){

            PlayerRb.velocity = forward * CamSpeed;
            transform.Rotate(-Input.GetAxis("Mouse Y") * Sensivity.y, +Input.GetAxis("Mouse X") * Sensivity.x, +0);

        }
        else{

            PlayerRb.velocity = forward * 0;
        }

    }
}
