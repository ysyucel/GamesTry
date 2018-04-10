using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class LineChart2 : MonoBehaviour {


    public float mThickness = 0.015f;
    public float mDepthPitch = 0.001f;
    public static float mMax, mMin;
    public bool Fill = false;
    private Mesh mesh;
    private MeshFilter meshFilter;
    private Vector3[] vertices;
    private int[] triangles;
    private float mWidth = 1.0f, mHeight = 1.0f;

    //****************
    private float[][] mData;

    public void UpdateData(float[] data)
    {
        if (data.Length == 0)
        {
            Debug.LogError("data is not set. ");
            return;
        }
        mData = new float[1][];
        mData[0] = new float[data.Length];
        data.CopyTo(mData[0], 0);
        CreateChartData();
    }

    //*******************
    LineChart2()
    {
        int length = 32;
        mData = new float[1][];
        mData[0] = new float[length];
        for (int i = 0; i < mData[0].Length; i++)
        {
            mData[0][i] = 1.0f / (float)(i + 2.0f);
        }
    }

    protected void CreateChartData()
    {
       
        meshFilter = (MeshFilter)this.gameObject.GetComponent("MeshFilter");
        mesh = meshFilter.mesh;//new Mesh();
        if (mesh == null)
        {
            mesh = new Mesh();
        }
        vertices = new Vector3[mData.Length * mData[0].Length * 2];
        //mMax = 50000;
        mMin = 0;
        int imax = 0;
        for (int i = 0; i < mData.Length; i++)
        {
            if (imax < mData[i].Length)
            {
                imax = mData[i].Length;
            }
        }

        float dur = mMax - mMin;
        float[] sum = new float[imax];

        for (int j = 0; j < imax; j++)
        {
            sum[j] = 0.0f;
        }

        for (int i = 0; i < mData.Length; i++)
        {
            for (int j = 0; j < mData[i].Length; j++)
            {
                float t = (float)mWidth * (float)j / (float)(mData[i].Length - 1);
                float v = (mData[i][j] - mMin) / (mMax - mMin) * mHeight;
                float v2 = v;
                Vector3 tck;
                if (j < mData[i].Length - 1)
                {
                    tck = new Vector3((float)mWidth / (float)mData[i].Length, mData[i][j + 1] - mData[i][j], 0);
                    tck = Vector3.Normalize(tck) * mThickness;
                }
                else
                {
                    tck = new Vector3((float)mWidth / (float)mData[i].Length, mData[i][j] - mData[i][j - 1], 0);
                    tck = Vector3.Normalize(tck) * mThickness;
                }
                if (Fill)
                {
                    vertices[(i * mData[i].Length + j) * 2 + 0] = new Vector3(t, sum[j], (mData.Length - 1 - i) * mDepthPitch);
                    vertices[(i * mData[i].Length + j) * 2 + 1] = new Vector3(t, v, (mData.Length - 1 - i) * mDepthPitch);
                }
                else
                {
                    vertices[(i * mData[i].Length + j) * 2 + 0] = new Vector3(t, v - mThickness * 0.5f, (mData.Length - 1 - i) * mDepthPitch);
                    vertices[(i * mData[i].Length + j) * 2 + 1] = new Vector3(t, v + mThickness * 0.5f, (mData.Length - 1 - i) * mDepthPitch);
                }
            }
        }

        triangles = new int[3 * 2 * mData.Length * (mData[0].Length - 1)];
        for (int i = 0; i < mData.Length; i++)
        {
            for (int j = 0; j < mData[i].Length - 1; j++)
            {
                triangles[(i * (mData[i].Length - 1) + j) * 6 + 0] = 0 + (i * mData[i].Length + j) * 2;
                triangles[(i * (mData[i].Length - 1) + j) * 6 + 1] = 1 + (i * mData[i].Length + j) * 2;
                triangles[(i * (mData[i].Length - 1) + j) * 6 + 2] = 2 + (i * mData[i].Length + j) * 2;
                triangles[(i * (mData[i].Length - 1) + j) * 6 + 3] = 1 + (i * mData[i].Length + j) * 2;
                triangles[(i * (mData[i].Length - 1) + j) * 6 + 4] = 3 + (i * mData[i].Length + j) * 2;
                triangles[(i * (mData[i].Length - 1) + j) * 6 + 5] = 2 + (i * mData[i].Length + j) * 2;
            }
        }

        if (mesh.vertices.Length != vertices.Length)
        {
            mesh.triangles = null;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        //mesh.Optimize();

        //meshFilter.sharedMesh = mesh;
        //meshFilter.sharedMesh.name = "LineChartMesh";

    }

}
