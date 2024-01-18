using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        // Create a new GameObject named "test"
        GameObject testGO = new GameObject("test");

        // Add MeshFilter component to the GameObject
        MeshFilter meshFilter = testGO.AddComponent<MeshFilter>();

        // Create a new Mesh
        Mesh mesh = new Mesh();

        // Define the vertices of a simple triangle with correct winding order
        Vector3[] triangleVertices = new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0)
        };

        // Define the indices to form a triangle
        int[] triangleIndices = new int[] { 0, 1, 2 };

        // Assign vertices and triangles to the mesh
        mesh.vertices = triangleVertices;
        mesh.triangles = triangleIndices;

        // Recalculate normals for the mesh
        mesh.RecalculateNormals();

        // Assign the mesh to the MeshFilter
        meshFilter.mesh = mesh;

        // Add MeshRenderer component to the GameObject
        MeshRenderer meshRenderer = testGO.AddComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Standard"));


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
