using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationButton : MonoBehaviour //Broadcaster of the Animation event, who raised the event to the listener
{
    public enum AnimEnum { House, Macarena, HipHop }; //Enum who list all the animations
    
    public AnimEventChannel buttonChannel; 
    //button functions
    public void HouseAnimation(){
        int house = (int) AnimEnum.House; // convert the enum to a int
        buttonChannel.RaiseEvent(house); // send the int that the enum list for the animation
        //Debug.Log("HouseAnim Event Raised");
    }
    public void MacarenaAnimation(){
        int macarena = (int) AnimEnum.Macarena;
        buttonChannel.RaiseEvent(macarena);
        //Debug.Log("MacarenaAnim Event Raised");
    }
    public void HipHopAnimation(){
        int hiphop = (int) AnimEnum.HipHop;
        buttonChannel.RaiseEvent(hiphop);
        //Debug.Log("HipHopAnim Event Raised");
    }
}
