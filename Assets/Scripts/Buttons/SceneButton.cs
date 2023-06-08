using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    public AnimSelect animSelect;
    public string sceneName;

    public TextMeshProUGUI textField;

    private void Awake() {
        textField = GameObject.Find("ChangeText").GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        ChangeTextFun(textField, animSelect.animSelected);
    }
    public void SceneChange(){
        SceneManager.LoadScene(sceneName);
    }

    private void ChangeTextFun(TextMeshProUGUI textField, int a){
        switch(a){
            case 0:
                textField.text = "Animation Select: House Dance";
                break;
            case 1:
                textField.text = "Animation Select: Macarena Dance";
                break;
            case 2:
                textField.text = "Animation Select: Hip Hop Dance";
                break;
        }
    }
}
