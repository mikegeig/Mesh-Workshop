using UnityEngine;
using System.Collections;

public class BasicDeform : MonoBehaviour 
{
	Mesh mesh;
	MeshFilter filter;
	
	void Start () 
	{
		filter = GetComponent<MeshFilter>();
		mesh = filter.mesh;
	}
}
