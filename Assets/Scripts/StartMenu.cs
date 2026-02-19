using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class XRStartButton : MonoBehaviour {
    public InputActionReference startAction;

    void Start() {
        startAction.action.Enable();
        
        startAction.action.performed += (ctx) => {
            SceneManager.LoadScene("SampleScene");
        };
    }
}