using UnityEngine;
using System.Collections;

public class MeshInverter_Final : MonoBehaviour 
{
	Mesh mesh;
	MeshFilter filter;
	
	void Start () 
	{
		filter = GetComponent<MeshFilter>();
		mesh = filter.mesh;

		int[] tris = mesh.triangles;
		
		for(int i = 0; i < tris.Length; i += 3)
		{
			int x = tris[i];
			tris[i] = tris[i + 2];
			tris[i + 2] = x;
		}
		mesh.triangles = tris;
		mesh.RecalculateNormals();
		mesh.RecalculateBounds();
	}
}
