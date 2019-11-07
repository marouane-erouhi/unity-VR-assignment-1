using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
    [SerializeField] GameObject LaserStart;
    LineRenderer lineRenderer;
    LineDrawer lineDrawer;
    void Start() {
        lineRenderer = GetComponent<LineRenderer>();
        lineDrawer = new LineDrawer(lineRenderer);
    }

    void Update() {
        // m_pointerEvent.position = LaserPointer.
        Vector3 r = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote).eulerAngles;
        Vector3 e = new Vector3(r.x,r.y+90,r.z);
        transform.rotation = Quaternion.Euler(e);
        OVRInput.Update();
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTrackedRemote)){
            //trigger button
            //select button
        }

        if(OVRInput.GetDown(OVRInput.Button.Back, OVRInput.Controller.RTrackedRemote)){
            //back button
            //show map
        }

        //line renderer
        lineDrawer.DrawLineInGameView(LaserStart.transform.position, 
            LaserStart.transform.position+LaserStart.transform.forward*50, 
            Color.blue);



    }
}




public struct LineDrawer
{
    LineRenderer lineRenderer;
    private float lineSize;

    public LineDrawer(LineRenderer lineRenderer_, float lineSize = 0.05f)
    {
        GameObject lineObj = new GameObject("LineObj");
        lineRenderer = lineRenderer_;
        //Particles/Additive
        lineRenderer.material = new Material(Shader.Find("Default-Line"));
        
        this.lineSize = lineSize;
    }

    private void init(float lineSize = 0.05f)
    {
        if (lineRenderer == null)
        {
            GameObject lineObj = new GameObject("LineObj");
            lineRenderer = lineObj.AddComponent<LineRenderer>();
            //Particles/Additive
            lineRenderer.material = new Material(Shader.Find("Hidden/Internal-Colored"));

            this.lineSize = lineSize;
        }
    }

    //Draws lines through the provided vertices
    public void DrawLineInGameView(Vector3 start, Vector3 end, Color color)
    {
        if (lineRenderer == null)
        {
            init(0.05f);
        }

        //Set color
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;

        //Set width
        lineRenderer.startWidth = lineSize;
        lineRenderer.endWidth = lineSize;

        //Set line count which is 2
        lineRenderer.positionCount = 2;

        //Set the postion of both two lines
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }

    public void Destroy()
    {
        if (lineRenderer != null)
        {
            UnityEngine.Object.Destroy(lineRenderer.gameObject);
        }
    }
}