using UnityEngine;

public class NeWsCrIpt : MonoBehaviour
{
    GameObject pyramid;
    MeshRenderer pyramidRend;

    // Start is called before the first frame update
    void Start()
    {
        pyramid = CreatePyramid();
        pyramidRend = pyramid.GetComponent<MeshRenderer>();
        pyramidRend.material = new Material(Shader.Find("Unlit/Color"));
    }

    // Update is called once per frame
	private void Update()
    {
        pyramid.transform.Rotate(new Vector3(Mathf.Sin(Time.time) * 2, 45f, Mathf.Cos(Time.time) * 2) * Time.deltaTime);
        pyramidRend.material.color = Color.HSVToRGB(Mathf.Repeat(Time.time / 40, 1f), 1f, 1f);
	}

	GameObject CreatePyramid() {
        const float dx = 2f, dy = 2f, dz = 2f; // dimensions (max dst from center)
        Vector3[] vertices = { new Vector3(-dx, 0, -dz), new Vector3(-dx, 0, dz), new Vector3(dx, 0, dz), new Vector3(dx, 0, -dz), new Vector3(0f, dy, 0f), new Vector3(-dx, 0, -dz), new Vector3(-dx, 0, dz), new Vector3(dx, 0, dz), new Vector3(dx, 0, -dz) };
        //int[] tris = { 0,1,3, 1,2,3, 3,4,2, 2,4,1, 1,4,0, 0,4,3 };
        int[] tris = { 0,1,3, 1,2,3, 5,4,6, 6,4,7, 7,4,8, 8,4,5 };
#if true
        // calculate normals manually
        Vector3[] normals = new Vector3[vertices.Length];
        int index = 0;
        foreach(Vector3 v in vertices) {
			normals[index] = (v - Vector3.zero).normalized;
            index++;
		}
		_ = ~index;
        normals[0] = Vector3.down;
        normals[1] = Vector3.down;
        normals[2] = Vector3.down;
        normals[3] = Vector3.down;
#endif

        Mesh m = new Mesh();
        m.vertices = vertices;
        m.triangles = tris;
        m.normals = normals;
        //m.RecalculateNormals();
        m.RecalculateBounds();

        GameObject g = new GameObject("Pyramid");
        MeshFilter mf = g.AddComponent<MeshFilter>();
        MeshRenderer mr = g.AddComponent<MeshRenderer>();

        mf.mesh = m;

        return g;
	}
}
