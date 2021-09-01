using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramotor : MonoBehaviour
{
	public Transform lookat;
	public float boundx = 0.30f;
	public float boundy = 0.15f;

	private void LateUpdate()
	{
		Vector3 delta = Vector3.zero;
		// to check if we are inside the bounds on the x axis
		float deltax = lookat.position.x - transform.position.x;
		if (deltax > boundx || deltax < -boundx)
		{
			if(transform.position.x < lookat.position.x)
			{
				delta.x = deltax - boundx;
			}
			else
			{
				delta.x = deltax + boundx;
			}
		}

		// to check if we are inside the bounds on the y axis
		float deltay = lookat.position.y - transform.position.y;
		if (deltay > boundy || deltay < -boundy)
		{
			if (transform.position.y < lookat.position.y)
			{
				delta.y = deltay - boundy;
			}
			else
			{
				delta.y = deltay + boundy;
			}
		}
		transform.position += new Vector3(delta.x, delta.y, 0);
	}

	

}
