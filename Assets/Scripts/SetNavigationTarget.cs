using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SetNavigationTarget : MonoBehaviour
{
    [SerializeField]
    private Camera topDownCamera;
    [SerializeField]
    private GameObject navTargetObject;

    private UnityEngine.AI.NavMeshPath path; // current calculated path
    private LineRenderer line; // linerenderer to display path

    private bool lineToggle = false;

    private void Start()
    {
        path = new UnityEngine.AI.NavMeshPath();
        line = transform.GetComponent<LineRenderer>(); // create new path and get the line component
    }

    private void Update()
    {
        if ((Input.touchCount > 0) && (Input. GetTouch(0).phase == TouchPhase.Began))
        {
            lineToggle = !lineToggle; // everytime touch the screen, the line toggle will be toggled
        }
        if (lineToggle) // if true, the nav mesh will calculate out part from current position
        {
            NavMesh.CalculatePath(transform.position, navTargetObject.transform.position, NavMesh.AllAreas, path);
            line.positionCount = path.corners.Length;
            line.SetPositions(path.corners);
            line.enabled = true; // nav target and configure the line renderer initially
        }
    }
   
}
