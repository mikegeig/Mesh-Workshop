using UnityEngine;
using System.Collections;

public class ExpandContractDeform : MonoBehaviour 
{
	Mesh mesh;
	MeshFilter filter;

	public float scale = .1f;
	
	void Start () 
	{
		filter = GetComponent<MeshFilter>();
		mesh = filter.mesh;
	}
	
	
	void Update () 
	{
		Vector3[] verts = mesh.vertices;
		Vector3[] norms = mesh.normals;
		
		for(int i = 0; i < verts.Length; i++)
		{
			verts[i] += norms[i] * (Mathf.Sin (Time.time) * scale);
		}
		mesh.vertices = verts;
		mesh.RecalculateBounds();
	}
}
