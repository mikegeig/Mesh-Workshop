using UnityEngine;
using System.Collections;

public class BumpDeform : MonoBehaviour 
{
	Mesh mesh;
	MeshFilter filter;
	
	public float bumpAmount = .1f;
	
	void Start () 
	{
		filter = GetComponent<MeshFilter>();
		mesh = filter.mesh;
	}
}
