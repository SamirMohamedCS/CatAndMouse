using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {
	
	public Transform mouse;
	Rigidbody rb;
	float count = 0;
	bool doCat = true;
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
			doCat = !doCat;
			count = 0;
		}
		
		ActCat ();
	}
	
	
	void ActCat()
	{
		Vector3 directionToMouse = mouse.position - transform.position;
		if( Vector3.Angle (transform.forward, directionToMouse) <= 180)
		{
			Ray catRay = new Ray(transform.position, directionToMouse);
			RaycastHit catRayInfo;
			float distance = 20;
			if(doCat)
				distance = 15;
			if(Physics.Raycast(catRay, out catRayInfo, distance))
			{

				if(catRayInfo.collider.tag == "Mouse")
				{	
					if(catRayInfo.distance <3 && doCat)
					{
						Destroy(catRayInfo.collider.gameObject);
					}
					if(!doCat){rb.velocity =  (Vector3.Normalize (-directionToMouse) * 40f);}
					else {rb.velocity = (Vector3.Normalize (directionToMouse) * 30f);}
				}
				
			}
		}
	}

}
