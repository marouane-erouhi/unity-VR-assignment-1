using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
    [SerializeField] GameObject LaserStart;
    void Start() {

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




    }
}
