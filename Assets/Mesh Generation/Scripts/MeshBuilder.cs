using UnityEngine;
using System.Collections;

public class MeshBuilder : MonoBehaviour 
{
	MeshFilter filter;
	Mesh mesh;
	
	void Start () 
	{
		filter = GetComponent<MeshFilter>();
		mesh = new Mesh();
		filter.mesh = mesh;
	}
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{}
		else if(Input.GetKeyDown(KeyCode.Alpha2))
		{}
		else if(Input.GetKeyDown(KeyCode.Alpha3))
		{}
		else if(Input.GetKeyDown(KeyCode.Alpha4))
		{}
		else if(Input.GetKeyDown(KeyCode.Alpha5))
		{}
	}
}
