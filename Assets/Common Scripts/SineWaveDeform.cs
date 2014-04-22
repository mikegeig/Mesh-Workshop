using UnityEngine;
using System.Collections;

public class SineWaveDeform : MonoBehaviour 
{
	Mesh mesh;
	MeshFilter filter;
	
	void Start () 
	{
		filter = GetComponent<MeshFilter>();
		mesh = filter.mesh;
	}
	
	
	void Update () 
	{
		if(Input.GetKey(KeyCode.Alpha1))
		{
			Vector3[] verts = mesh.vertices;

			int length = (int)Mathf.Sqrt(verts.Length);

			for(int i = 0; i < verts.Length; i++)
			{
				verts[i].y = (Mathf.Sin (Time.time + i / length));
			}
			mesh.vertices = verts;
			mesh.RecalculateBounds();
		}
	}
}
