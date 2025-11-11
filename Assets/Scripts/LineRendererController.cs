using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    [SerializeField] List<LineRenderer> lineRenderer = new List<LineRenderer>();

    public void SetPosition(Transform startPos, Transform endPos)
    {
        if (lineRenderer.Count > 0)
        {
            for (int i = 0; i < lineRenderer.Count; i++)
            {
                if (lineRenderer[i].positionCount >= 2)
                {
                    lineRenderer[i].SetPosition(0, startPos.position);
                    lineRenderer[i].SetPosition(1, endPos.position);
                }
                else
                {
                    Debug.LogWarning("해당 랜더러는 2개의 점이 있어야 합니다.");
                }
            }
        }
    }
}
