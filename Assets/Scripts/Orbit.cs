using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour
{
    public float RotationSpeed = 5;
    public bool Rorating = true;
    public Transform  Sun;
    public GameObject CenterOfGravity;
    GameUI gui;
    

	void Start ()
    {
        Instantiate(CenterOfGravity, Sun.position, Sun.rotation);
        transform.parent = GameObject.Find(CenterOfGravity.name + "(Clone)").transform;
        transform.parent.name = CenterOfGravity.name + "To" + transform.name;
        gui = GameObject.Find("Player").GetComponent<GameUI>();
    }
	
    void Update()
    {
        transform.GetComponent<TrailRenderer>().startWidth = gui.TrailWidth;
        transform.GetComponent<TrailRenderer>().endWidth = gui.TrailWidth;
    }
    
	void FixedUpdate ()
    {
        if (Rorating)
        {
            transform.parent.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime * GameObject.Find("Player").GetComponent<GameUI>().CoefOfPlanetsSpeed));
        }
    }
}
