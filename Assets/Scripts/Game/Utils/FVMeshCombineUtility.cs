using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FVMeshCombineUtility
{

	#if UNITY_EDITOR
	private readonly List<Color> _colors = new List<Color>();
	private readonly List<Vector3> _normals = new List<Vector3>();
	private readonly Dictionary<int, List<int>> _strip = new Dictionary<int, List<int>>();
	private readonly List<Vector4> _tangents = new List<Vector4>();
	private readonly Dictionary<int, List<int>> _triangles = new Dictionary<int, List<int>>();
	private readonly List<Vector2> _uv = new List<Vector2>();
	private readonly List<Vector2> _uv1 = new List<Vector2>();
	private readonly List<Vector3> _vertices = new List<Vector3>();

	/// <summary>
	/// Creates a new, empty FVMeshCombineUtility object for combining meshes.
	/// </summary>
	public FVMeshCombineUtility()
	{
	}

	/// <summary>
	/// Allocate space for adding a load more vertex data.
	/// </summary>
	/// <param name="numVertices">The number of vertices you're about to add.</param>
	public void PrepareForAddingVertices(int numVertices)
	{
		int shortfall = numVertices - (_vertices.Capacity - _vertices.Count);

		_vertices.Capacity += shortfall;
		_normals.Capacity += shortfall;
		_tangents.Capacity += shortfall;
		_uv.Capacity += shortfall;
		_uv1.Capacity += shortfall;
		_colors.Capacity += shortfall;
	}

	/// <summary>
	/// Allocate space for adding a load more triangles to the triangle list.
	/// </summary>
	/// <param name="targetSubmeshIndex">The index of the submesh that you're going to add triangles to.</param>
	/// <param name="numIndices">The number of triangle indicies (number of triangles * 3) that you want to reserve space for.</param>
	public void PrepareForAddingTriangles(int targetSubmeshIndex, int numIndices)
	{
		if (!_triangles.ContainsKey(targetSubmeshIndex))
			_triangles.Add(targetSubmeshIndex, new List<int>());

		int shortfall = numIndices - (_triangles[targetSubmeshIndex].Capacity - _triangles[targetSubmeshIndex].Count);
		_triangles[targetSubmeshIndex].Capacity += shortfall;
	}

	/// <summary>
	/// Add multiple mesh instances to the combiner, allocating space for them all up-front.
	/// </summary>
	/// <param name="instances">The instances to add.</param>
	public void AddMeshInstances(IEnumerable<MeshInstance> instances)
	{
		// statistics for vertices number and triangles number
		int vertNum = 0;
		List<int> meshVertNums = new List<int> ();
		List<int> subTriNums = new List<int> ();
		foreach (MeshInstance mi in instances) {
			MeshFilter mf = mi.go.GetComponent<MeshFilter> ();
			Mesh mesh = mf.sharedMesh;
			vertNum += mesh.vertexCount;
			meshVertNums.Add (mesh.vertexCount);
			for (int i = subTriNums.Count; i < mesh.subMeshCount; ++i) {
				subTriNums.Add (0);
			}
			for (int i = 0; i < mesh.subMeshCount; ++i) {
				subTriNums [0] += mesh.GetTriangles (i).Length;
			}
		}
		PrepareForAddingVertices (vertNum);
		for (int i = 0; i < subTriNums.Count; ++i) {
			PrepareForAddingTriangles (i, subTriNums [i]);
		}

		// calculate vertex offset for setting indices
		List<int> baseVertexIndices = new List<int>();
		int acc = 0;
		baseVertexIndices.Add (0);
		foreach (int mvn in meshVertNums) {
			baseVertexIndices.Add (mvn + acc);
			acc += mvn;
		}
			
		int idx = 0;
		foreach (MeshInstance mi in instances) {
			// add vertices
			MeshFilter mf = mi.go.GetComponent<MeshFilter> ();
			Mesh mesh = mf.sharedMesh;
			_vertices.AddRange (mesh.vertices.Select (t => {
				return mi.transform.MultiplyPoint(t);
			}));
			_normals.AddRange(
				mesh.normals.Select(n => mi.transform.inverse.transpose.MultiplyVector(n).normalized));
			_tangents.AddRange(mesh.tangents.Select(t =>
				{
					var p = new Vector3(t.x, t.y, t.z);
					p =
						mi.transform.inverse.transpose.
						MultiplyVector(p).normalized;
					return new Vector4(p.x, p.y, p.z, t.w);
				}));
			_uv.AddRange(mesh.uv);
			_uv1.AddRange(mesh.uv2);
			_colors.AddRange(mesh.colors);

			// add indices
			for (int j = 0; j < mesh.subMeshCount; ++j) {
				int[] tris = mesh.GetTriangles (j);
				_triangles [j].AddRange (tris.Select(t => t + baseVertexIndices[idx]));
			}
			++idx;
		}
	}

	/// <summary>
	/// Generate a single mesh from the instances that have been added to the combiner so far.
	/// </summary>
	/// <returns>A combined mesh.</returns>
	public Mesh CreateCombinedMesh()
	{
		var mesh = new Mesh
		{
			name = "Combined Mesh",
			vertices = _vertices.ToArray(),
			normals = _normals.ToArray(),
			colors = _colors.ToArray(),
			uv = _uv.ToArray(),
			uv2 = _uv1.ToArray(),
			tangents = _tangents.ToArray(),
			subMeshCount = _triangles.Count
		};


		foreach (var targetSubmesh in _triangles)
			mesh.SetTriangles(targetSubmesh.Value.ToArray(), targetSubmesh.Key);

		return mesh;
	}

	/// <summary>
	/// Combine the given mesh instances into a single mesh and return it.
	/// </summary>
	/// <param name="instances">The mesh instances to combine.</param>
	/// <returns>A combined mesh.</returns>
	public static Mesh Combine(IEnumerable<MeshInstance> instances)
	{
		var processor = new FVMeshCombineUtility();
		processor.AddMeshInstances(instances);
		return processor.CreateCombinedMesh();
	}

	#region Nested type: MeshInstance

	public class MeshInstance
	{
		/// <summary>
		/// The source mesh.
		/// </summary>
		public GameObject go;

		public MeshFilter filter;

		public int subMeshCount;
		/// <summary>
		/// The instance transform.
		/// </summary>
		public Matrix4x4 transform;
	}

	#endregion

	#endif
}