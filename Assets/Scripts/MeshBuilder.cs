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
			MakeTriangle();
		else if(Input.GetKeyDown(KeyCode.Alpha2))
			MakeQuad();
		else if(Input.GetKeyDown(KeyCode.Alpha3))
			MakeCubeManually();
		else if(Input.GetKeyDown(KeyCode.Alpha4))
			MakeCubeFromQuads();
		else if(Input.GetKeyDown(KeyCode.Alpha5))
			MakePlane();
	}

	void MakeTriangle()
	{
		mesh.Clear();

		Vector3[] verts = new Vector3[3];
		verts[0] = new Vector3(-.5f, -.5f, 0);
		verts[1] = new Vector3(-.5f, .5f, 0);
		verts[2] = new Vector3(.5f, -.5f, 0);

		int[] tris = new int[3];
		tris[0] = 0;
		tris[1] = 1;
		tris[2] = 2;

		Vector2[] uvs = new Vector2[3];
		uvs[0] = new Vector2(0, 0);
		uvs[1] = new Vector2(1, 0);
		uvs[2] = new Vector2(0, 1);

		mesh.vertices = verts;
		mesh.triangles = tris;
		mesh.uv = uvs;

		mesh.RecalculateNormals();
	}

	void MakeQuad()
	{
		mesh.Clear();
		
		Vector3[] verts = new Vector3[4];
		verts[0] = new Vector3(-.5f, -.5f, 0);
		verts[1] = new Vector3(-.5f, .5f, 0);
		verts[2] = new Vector3(.5f, .5f, 0);
		verts[3] = new Vector3(.5f, -.5f, 0);
		
		int[] tris = new int[6];
		tris[0] = 0;
		tris[1] = 1;
		tris[2] = 2;
		tris[3] = 0;
		tris[4] = 2;
		tris[5] = 3;
		
		Vector2[] uvs = new Vector2[4];
		uvs[0] = new Vector2(0, 0);
		uvs[1] = new Vector2(0, 1);
		uvs[2] = new Vector2(1, 1);
		uvs[3] = new Vector2(1, 0);
		
		mesh.vertices = verts;
		mesh.triangles = tris;
		mesh.uv = uvs;
		
		mesh.RecalculateNormals();
	}

	void MakeCubeManually()
	{
		mesh.Clear();
		
		Vector3[] verts = new Vector3[8];
		verts[0] = new Vector3(-.5f, -.5f, -.5f);
		verts[1] = new Vector3(-.5f, .5f, -.5f);
		verts[2] = new Vector3(.5f, .5f, -.5f);
		verts[3] = new Vector3(.5f, -.5f, -.5f);
		verts[4] = new Vector3(-.5f, -.5f, .5f);
		verts[5] = new Vector3(-.5f, .5f, .5f);
		verts[6] = new Vector3(.5f, .5f, .5f);
		verts[7] = new Vector3(.5f, -.5f, .5f);
		
		int[] tris = new int[36];
		tris[0] = 0;
		tris[1] = 1;
		tris[2] = 2;

		tris[3] = 0;
		tris[4] = 2;
		tris[5] = 3;

		tris[6] = 3;
		tris[7] = 2;
		tris[8] = 7;
		
		tris[9] = 2;
		tris[10] = 6;
		tris[11] = 7;

		tris[12] = 7;
		tris[13] = 6;
		tris[14] = 4;
		
		tris[15] = 6;
		tris[16] = 5;
		tris[17] = 4;

		tris[18] = 4;
		tris[19] = 5;
		tris[20] = 0;
		
		tris[21] = 5;
		tris[22] = 1;
		tris[23] = 0;

		tris[24] = 1;
		tris[25] = 5;
		tris[26] = 2;
		
		tris[27] = 5;
		tris[28] = 6;
		tris[29] = 2;

		tris[30] = 4;
		tris[31] = 0;
		tris[32] = 7;
		
		tris[33] = 0;
		tris[34] = 3;
		tris[35] = 7;
		
		Vector2[] uvs = new Vector2[4];
		uvs[0] = new Vector2(0, 0);
		uvs[1] = new Vector2(0, 1);
		uvs[2] = new Vector2(1, 1);
		uvs[3] = new Vector2(1, 0);
		
		mesh.vertices = verts;
		mesh.triangles = tris;
		//mesh.uv = uvs;
		
		mesh.RecalculateNormals();
	}

	void MakeCubeFromQuads()
	{
		mesh.Clear();

		Vector3[] verts = new Vector3[8];
		verts[0] = new Vector3(-.5f, -.5f, -.5f);
		verts[1] = new Vector3(-.5f, .5f, -.5f);
		verts[2] = new Vector3(.5f, .5f, -.5f);
		verts[3] = new Vector3(.5f, -.5f, -.5f);
		verts[4] = new Vector3(-.5f, -.5f, .5f);
		verts[5] = new Vector3(-.5f, .5f, .5f);
		verts[6] = new Vector3(.5f, .5f, .5f);
		verts[7] = new Vector3(.5f, -.5f, .5f);

		CombineInstance[] combine = new CombineInstance[6];
		combine[0] = BuildAndReturnQuad(verts[0], verts[1], verts[2], verts[3]);
		combine[1] = BuildAndReturnQuad(verts[3], verts[2], verts[6], verts[7]);
		combine[2] = BuildAndReturnQuad(verts[7], verts[6], verts[5], verts[4]);
		combine[3] = BuildAndReturnQuad(verts[4], verts[5], verts[1], verts[0]);
		combine[4] = BuildAndReturnQuad(verts[1], verts[5], verts[6], verts[2]);
		combine[5] = BuildAndReturnQuad(verts[4], verts[0], verts[3], verts[7]);

		mesh.CombineMeshes(combine, true, false);
		mesh.RecalculateNormals();
		mesh.RecalculateBounds();
	}

	CombineInstance BuildAndReturnQuad(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4)
	{
		Mesh tempMesh = new Mesh();
		CombineInstance combine = new CombineInstance();

		Vector3[] verts = new Vector3[4];
		verts[0] = p1;
		verts[1] = p2;
		verts[2] = p3;
		verts[3] = p4;
		
		int[] tris = new int[6];
		tris[0] = 0;
		tris[1] = 1;
		tris[2] = 2;
		tris[3] = 0;
		tris[4] = 2;
		tris[5] = 3;
		
		Vector2[] uvs = new Vector2[4];
		uvs[0] = new Vector2(0, 0);
		uvs[1] = new Vector2(0, 1);
		uvs[2] = new Vector2(1, 1);
		uvs[3] = new Vector2(1, 0);
		
		tempMesh.vertices = verts;
		tempMesh.triangles = tris;
		tempMesh.uv = uvs;
	
		combine.mesh = tempMesh;
		combine.transform = filter.transform.localToWorldMatrix;

		return combine;
	}

	void MakePlane()
	{
		mesh.Clear();

		int length = 10;
		int width = 10;
		int numQuads = length * width;
		int numVerts = ++length * ++width;
		
		Vector3[] verts = new Vector3[ numVerts ];
		Vector2[] uvs = new Vector2[ numVerts ];
		for (int n = 0; n < verts.Length; n++)
		{
			verts[n] = new Vector3( n / length, 0, n % length );
			uvs[n] = new Vector2( n / length / (length - 1f), n % length / (length - 1f));
		}

		int numTris = numQuads * 2;
		int[] tris = new int[ numTris * 3 ];
		
		int ti = 0;
		for (int triNum = 0; triNum < numVerts - length; triNum++)
		{
			if(triNum % length == length - 1) continue;
			
			tris[ti++] = triNum;
			tris[ti++] = triNum + 1;
			tris[ti++] = triNum + length;
			
			
			tris[ti++] = triNum + 1;
			tris[ti++] = triNum + length + 1;
			tris[ti++] = triNum + length;
	
		}

		mesh.vertices = verts;
		mesh.triangles = tris;
		mesh.uv = uvs;
		mesh.RecalculateNormals();
	}
}
