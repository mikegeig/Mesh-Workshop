using UnityEngine;
using System.Collections;

public class BumpDeform_Final : MonoBehaviour 
{
	Mesh mesh;
	MeshFilter filter;

	public float bumpAmount = .1f;
	
	void Start () 
	{
		filter = GetComponent<MeshFilter>();
		mesh = filter.mesh;
	}

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			Vector3[] verts = mesh.vertices;
			Vector3[] norms = mesh.normals;

			for(int i = 0; i < verts.Length; i++)
			{
				verts[i] += norms[i] * Random.Range(-bumpAmount, bumpAmount);
			}
			mesh.vertices = verts;
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
		}
	}
}
