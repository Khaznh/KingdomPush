using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Vector3> transformToMove;
    [SerializeField, UnityEngine.Range(0,20f)] public float line;

    private Color gizmoColor = Color.green;
    private Transform[] pathWay;

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        
        GetWayPoint();
        transformToMove.Clear();

        for (int i = 1; i < pathWay.Length; i++)
        {
            Vector3 current = pathWay[i].position;
            
            if (i > 1)
            {
                Vector3 prev = pathWay[i - 1].position;
                Gizmos.DrawLine(current, prev);
                Gizmos.DrawWireSphere(current, 0.3f);
            }
        }

        Vector3 startPoint = pathWay[1].position;

        for (int i = 1; i < pathWay.Length - 2; i += 2)
        {
            for (int j = 0; j <= line; j++)
            {
                Vector3 movePoint = GetPoint(pathWay[i].position, pathWay[i + 1].position, pathWay[i + 2].position, j / line);

                Gizmos.color = Color.red;
                Gizmos.DrawLine(startPoint, movePoint);

                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(startPoint, 0.1f);

                startPoint = movePoint;

                transformToMove.Add(startPoint);
            }
        }
    }

    private void GetWayPoint()
    {
        pathWay = transform.GetComponentsInChildren<Transform>();
    }

    private Vector3 GetPoint(Vector3 t0, Vector3 t1, Vector3 t2, float line)
    {
        return Vector3.Lerp(Vector3.Lerp(t0,t1,line), Vector3.Lerp(t1, t2, line), line);
    }
}
