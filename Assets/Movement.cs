using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	Rigidbody rb;
	float velocityMult = 20f;

	void Start()
	{
		rb = this.GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		rb.velocity = transform.forward * velocityMult + Physics.gravity;
		Ray moveRay = new Ray(transform.position, transform.forward);
		if(Physics.SphereCast (moveRay, 1, 3))
		{
			TurnAndRay(moveRay);
		}



	}

	void TurnAndRay(Ray moveRay)
	{
		transform.Rotate(0,Random.Range (-2,3) * 90,0);
		moveRay = new Ray(transform.position, transform.forward);
		if(Physics.SphereCast (moveRay, 1, 3))
		{
			TurnAndRay(moveRay);
		}
	}
}
