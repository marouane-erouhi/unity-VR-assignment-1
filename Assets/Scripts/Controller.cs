using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    void Start() {
        
    }

    void Update() {
        Vector3 r = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote).eulerAngles;
        Vector3 e = new Vector3(r.x,r.y+90,r.z);
        transform.rotation = Quaternion.Euler(e);
    }
}
