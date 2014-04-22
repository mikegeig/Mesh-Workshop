using UnityEngine;
using System.Collections;

public class BasicDeform_Final : MonoBehaviour 
{
	Mesh mesh;
	MeshFilter filter;
	
	void Start () 
	{
		filter = GetComponent<MeshFilter>();
		mesh = filter.mesh;

		Vector3[] verts = mesh.vertices;
		Vector3[] norms = mesh.normals;
		
		for(int i = 0; i < verts.Length; i++)
		{
			verts[i].x += 1;
		}
		mesh.vertices = verts;
		mesh.RecalculateBounds();
	}
}
