using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinerendererCollision : MonoBehaviour
{
    public LayerMask obstacleLayerMask; // Define the layer mask for the obstacles

    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        // Update the line renderer positions
        // ...

        // Check for obstacles along the line
        CheckForObstacles();
    }

    private void CheckForObstacles()
    {
        // Get the positions of the line renderer
        Vector3 startPosition = lineRenderer.GetPosition(0);
        Vector3 endPosition = lineRenderer.GetPosition(1);

        // Perform raycast from the start position to the end position
        RaycastHit hit;
        if (Physics.Raycast(startPosition, (endPosition - startPosition).normalized, out hit, Vector3.Distance(startPosition, endPosition), obstacleLayerMask))
        {
            // An obstacle is detected along the line, so adjust the end position
            lineRenderer.SetPosition(1, hit.point);
        }
    }
}
