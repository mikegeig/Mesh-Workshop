using UnityEngine;
using System.Collections;

public class SineDeform : MonoBehaviour 
{
	Mesh mesh;
	MeshFilter filter;
	
	public float scale = .1f;
	
	void Start () 
	{
		filter = GetComponent<MeshFilter>();
		mesh = filter.mesh;
	}
}
