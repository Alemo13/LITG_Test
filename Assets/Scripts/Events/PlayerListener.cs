using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListener : MonoBehaviour
{
    public AnimEventChannel buttonChannel;
    [SerializeField] public AnimSelect animationSelect;
    private void OnEnable()
    {
        if(buttonChannel != null) buttonChannel.OnEventRaised += ButtonAnimation; //subscribe to the function when the game is running
        Debug.Log("Event Raised");
    }
    private void OnDisable() //de-subscribe when the game is turn off 
    {
        if(buttonChannel != null) buttonChannel.OnEventRaised -= ButtonAnimation;
        Debug.Log("Event DesRaised");
    }
    private void Start() {
        ButtonAnimation(animationSelect.animSelected); //when the game starts play the last animation that was selected
    }
    void ButtonAnimation(int anim) //received the int of the animation from the broadcaster
    {
        switch(anim){
            case 0:
                GetComponent<Animator>().Play("House Dancing"); //take the animation with that name in the animator and star playing to the object that is listening
                animationSelect.animSelected = anim;
                Debug.Log("house anim play");
                break;
            case 1:
                GetComponent<Animator>().Play("Macarena Dance");
                animationSelect.animSelected = anim;
                Debug.Log("macarena anim play");
                break;
            case 2:
                GetComponent<Animator>().Play("Wave Hip Hop Dance");
                animationSelect.animSelected = anim;
                Debug.Log("hiphop anim play");
                break;
        }      
    }
}
