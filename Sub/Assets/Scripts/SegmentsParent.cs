using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentsParent : MonoBehaviour
{
    [SerializeField] Segment[] allSegments;
    [SerializeField] Transform centerSegmentMarker;

    public Segment FindMiddleSegment()
    {
        foreach (Segment segment in allSegments)
        {
            Debug.Log("Distance: " + Vector3.Distance(segment.gameObject.transform.position, centerSegmentMarker.position));
            if (Vector3.Distance(segment.gameObject.transform.position, centerSegmentMarker.position) < 5f)
            {
                return segment;
            }
        }
        return null;
    }
}
