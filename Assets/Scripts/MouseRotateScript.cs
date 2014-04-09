using UnityEngine;
using System.Collections;

public class MouseRotateScript : MonoBehaviour 
{
	float speed = 1.5f;

	void Update () 
	{
		transform.Rotate(new Vector3(Input.GetAxis ("Mouse Y") * speed, -Input.GetAxis ("Mouse X") * speed, 0));

		if(Input.GetKeyDown(KeyCode.R))
			transform.rotation = Quaternion.identity;
	}
}
