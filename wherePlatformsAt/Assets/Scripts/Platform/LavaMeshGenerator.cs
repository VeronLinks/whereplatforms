using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class LavaMeshGenerator : MonoBehaviour {

    #region Public Attributes
    public int xSize = 50;
    public int zSize = 50;

    public float scale = 15f;
    public float speed = 0.1f;
    #endregion

    #region Private Attributes
    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;
    private float offsetZ = 100f;
    private float offsetX = 100f;
    #endregion

    #region Properties
    #endregion

    void Start () {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
	}

    void Update()
    {
        CreateShape();
        UpdateMesh();
    }

    #region Methods

    void CreateShape()
    {
        offsetZ += speed;
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int i = 0, z = 0; z <= zSize; ++z)
        {
            for (int x = 0; x <= xSize; ++x)
            {
                float y = CalculateY(z, x);
                vertices[i] = new Vector3(x, y, z);
                ++i;
            }
        }

        triangles = new int[xSize * zSize * 6];

        for (int vert = 0, tris = 0, z = 0; z < zSize; ++z)
        {
            for (int x = 0; x < xSize; ++x)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                ++vert;
                tris += 6;
            }
            ++vert;
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    float CalculateY(int z, int x)
    {
        float zCoord = (float)z / zSize * scale + offsetZ;
        float xCoord = (float)x / xSize * scale + offsetX;

        return Mathf.PerlinNoise(zCoord, xCoord);
    }

    #endregion
}
