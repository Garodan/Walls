using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour {

	public Vector2[] flatPoints;
	public float unitSize = 1f;
	public float wallHeight = 3f;

	private Mesh mesh;
	private List<Vector3> verts;
	private List<int> triangles;

	// Use this for initialization
	void Start () {
		mesh = GetComponent<MeshFilter> ().mesh;
		Generate ();
	}
	
	public void Generate(){
		//Clears the mesh and buffers
		mesh.Clear();
		verts = new List<Vector3> ();
		triangles = new List<int> ();
			
		//Adds walls for each pair of points
		for (int i = 0; i < flatPoints.Length; i+=2) {
			AddDoubleSidedWall (flatPoints[i], flatPoints[i + 1]);
		}

		//Updates the mesh
		mesh.SetVertices (verts);
		mesh.SetTriangles (triangles, 0);
	}

	private void AddDoubleSidedWall(Vector2 a, Vector2 b){
		//We need a base index to refer to the position of the vertices in the list
		int bIdx = verts.Count;

		//Adding the vertices in a specific order, base then top
		//   2---3
		//   | \ |
		//   0---1
		verts.Add(new Vector3(a.x * unitSize, 0f, a.y * unitSize));
		verts.Add (new Vector3 (b.x * unitSize, 0f, b.y * unitSize));
		verts.Add(new Vector3(a.x * unitSize, wallHeight, a.y * unitSize));
		verts.Add (new Vector3 (b.x * unitSize, wallHeight, b.y * unitSize));

		//Adds front face triangles
		triangles.Add(bIdx + 1);
		triangles.Add(bIdx + 0);
		triangles.Add(bIdx + 2);

		triangles.Add(bIdx + 2);
		triangles.Add(bIdx + 3);
		triangles.Add(bIdx + 1);

		//Adds back face triangles

		triangles.Add(bIdx + 2);
		triangles.Add(bIdx + 0);
		triangles.Add(bIdx + 1);

		triangles.Add(bIdx + 1);
		triangles.Add(bIdx + 3);
		triangles.Add(bIdx + 2);

	}

	//zum laden der punkte wird eine Arrayliste benoetigt, die Objekte werden dann in den Vektor geladen
	void SetPointsFromArrayList(ArrayList arr){
		flatPoints = (Vector2[])arr.ToArray (typeof(Vector2));
	}


}
