using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class DistOriginal
{
  public int distance; public int parentVert;
  public DistOriginal(int pv, int d)
  {
    distance = d; parentVert = pv;
  }
}
public class Vertex
{
  public string label; public bool isInTree;
  public Vertex(string lab) { label = lab; isInTree = false; }
}
public class Graph
{
  private const int max_verts = 20;
   int infinity = 1000000; Vertex[] vertexList; int[,] adjMat;
   int nVerts; int nTree; DistOriginal[] sPath;
   int currentVert; int startToCurrent;
  public Graph()
  {
    vertexList = new Vertex[max_verts];
    adjMat = new int[max_verts, max_verts];
    nVerts = 0; nTree = 0;
    for (int j = 0; j <= max_verts - 1; j++)
      for (int k = 0; k <= max_verts - 1; k++)
        adjMat[j, k] = infinity;
    sPath = new DistOriginal[max_verts];
  }
    public void AddVertex(string lab)
    {
    vertexList[nVerts] = new Vertex(lab); nVerts++;
    }
    public void AddEdge(int start, int theEnd, int weight)
    {
    adjMat[start, theEnd] = weight;
    adjMat[theEnd, start] = weight;
    }
    public void AddEdgeByValue(string source, string target, int weight)
    {
        int start = -1, eend = -1;
        for (int i = 0; i < nVerts; i++)
        {
            if (vertexList[i].label == source)
                start = i;
            if (vertexList[i].label == target)
                eend = i;
        }
        AddEdge(start, eend, weight);
    }
    public string Path( string e)
    {
        string result;
        int end = 0;

        for (int i = 0; i < nVerts; i++)
        {
            if (vertexList[i].label == e) end = i;
        }
        if (end == 0) return "(ERROR) Không tìm thấy đường đi";
        else return Path( end);
    }

    // khi ấn vào button sẽ thực hiện hàm này
    public string Path( int e)
    {
        string result = "";
        int startTree = 0;
        vertexList[startTree].isInTree = true;
        nTree = 1;
        for (int j = 0; j <= nVerts; j++)
        {
            int tempDist = adjMat[startTree, j];
            sPath[j] = new DistOriginal(startTree, tempDist);
        }
        while (nTree < nVerts)
        {
            int indexMin = GetMin();
            int minDist = sPath[indexMin].distance;
            currentVert = indexMin;
            startToCurrent = sPath[indexMin].distance;
            vertexList[currentVert].isInTree = true;
            nTree++;
            AdjustShortPath();
        }
        long s = sPath[e].distance;


        result = result + $"shortest path from {vertexList[0].label} to {vertexList[e].label}: ";
        result = result + "\r\n";
        par[0] = 0;
        Stack stack = new Stack();
        while (true)
        {
            stack.Push(e);
            if(e == 0) break;
            e = par[e];
        }
        foreach(int i in stack)
        {
            result = result + $"->{vertexList[i].label} ";
        }
        result = result + "\r\n";
        result = result + $"Tổng chi phí quảng đường di chuyển: {s}";
        return result;
    }
    //************
    
    static int[] par = new int[max_verts];

    public int GetMin()
    {
    int minDist = infinity;
    int indexMin = 0;
    for (int j = 1; j <= nVerts - 1; j++)
      if (!(vertexList[j].isInTree) && sPath[j].distance < minDist)
      {
        minDist = sPath[j].distance; indexMin = j;
      }
    return indexMin;
    }
    public void AdjustShortPath()
    {
        int column = 1;
        while (column < nVerts)
        if (vertexList[column].isInTree) column++;
        else
        {
            int currentToFring = adjMat[currentVert, column];
            int startToFringe = startToCurrent + currentToFring;
            int sPathDist = sPath[column].distance;
            if (startToFringe < sPathDist)
            {
                sPath[column].parentVert = currentVert;
                sPath[column].distance = startToFringe;
                par[column] = currentVert;
            }
        column++;
      }
    }
    
    // khi bắt đầu chương trình thì show ma trận bằng hàm này
 
    public string ShowToText()
    {
        string s = "";
        for(int i = 0; i < nVerts; i++)
        {
            for(int j = 0; j < nVerts; j++)
            {
                string t;
                if (adjMat[i, j] == 1000000) t = " ∞  ";
                else t =  adjMat[i, j].ToString() + "  ";
                s = s + t;
            }
            s = s + "\r\n";
        }
        return s;
    }

    //***********
}