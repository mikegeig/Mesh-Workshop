using UnityEngine;
using System.Collections;

public class SineDeform_Final : MonoBehaviour 
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

		//int length = (int)Mathf.Sqrt(verts.Length); //For SineWave

		for(int i = 0; i < verts.Length; i++)
		{
			//verts[i].y = (Mathf.Sin (Time.time + i / length)); //For SineWave
			verts[i] += norms[i] * (Mathf.Sin (Time.time) * scale); //For ExpandContract
		}
		mesh.vertices = verts;
		mesh.RecalculateBounds();
	}
}
