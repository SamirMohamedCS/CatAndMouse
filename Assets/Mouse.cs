﻿using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

	public Transform cat;
	Rigidbody rb;
	float count = 0;
	bool doMouse = true;
	void Start () 
	{
		rb = this.GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		count ++;
		if(count > 350)
		{
			doMouse = !doMouse;
			count = 0;
		}
		
		ActMouse ();
	}


	void ActMouse()
	{
		Vector3 directionToCat = cat.position - transform.position;
		if( Vector3.Angle (transform.forward, directionToCat) < 180)
		{
			Ray mouseRay = new Ray(transform.position, directionToCat);
			RaycastHit mouseRayInfo;
			if(Physics.SphereCast(mouseRay, 1, out mouseRayInfo, 100))
			{
				if(mouseRayInfo.collider.tag == "Cat")
				{	
					if(mouseRayInfo.distance <3 && !doMouse)
					{
						Destroy(mouseRayInfo.collider.gameObject);
					}
					if(doMouse){rb.velocity = Vector3.Normalize (-directionToCat) * 1000f;}
					else {rb.velocity = Vector3.Normalize (directionToCat) * 900f;}
				}

			}
		}
	}
}
