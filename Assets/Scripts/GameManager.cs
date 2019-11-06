using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] GameObject[] RoomLocations;
    int maxRooms = 2;
    [SerializeField] int CurrentRoom;
    [SerializeField] GameObject cam;
    void Start() {
        
    }

    void Update() {
        cam.transform.position = RoomLocations[CurrentRoom].gameObject.transform.position;
    }

    public void SetCurrentRoom(int val){
        if(val > maxRooms)  CurrentRoom = maxRooms;
        else if(val < 0)    CurrentRoom = 0;
        else                CurrentRoom = val;
    }
    public int GetCurrentRoom(){
        return CurrentRoom;
    }
    public void NextRoom(){
        CurrentRoom = CurrentRoom==maxRooms ? 0 : ++CurrentRoom; //FLAG: potential bug, test later
    }
    public void PreviousRoom(){
        CurrentRoom = CurrentRoom==0 ? maxRooms : --CurrentRoom; //FLAG: potential bug, test later
    }
}
