using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] GameObject[] RoomLocations;
    [SerializeField] int CurrentRoom;
    [SerializeField] GameObject cam;
    void Start() {
        
    }

    void Update() {
        cam.transform.position = RoomLocations[CurrentRoom].gameObject.transform.position;
    }
}
