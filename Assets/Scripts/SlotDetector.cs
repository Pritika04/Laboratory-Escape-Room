using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SlotDetector : MonoBehaviour
{
    public int slotIndex;
    public WinScript winScript;
	private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;

	void Awake() {
        socket = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>();
    }

	void OnEnable() {
        socket.selectEntered.AddListener(OnTubePlaced);
        socket.selectExited.AddListener(OnTubeRemoved);
    }

	void OnDisable() {
        socket.selectEntered.RemoveListener(OnTubePlaced);
        socket.selectExited.RemoveListener(OnTubeRemoved);
    }

	private void OnTubePlaced(SelectEnterEventArgs args) {
        GameObject tube = args.interactableObject.transform.gameObject;

        if (tube.CompareTag("KeyTube")) {
			winScript.currentPlacedTubes[slotIndex] = tube.name;
			Debug.Log("SUCCESS: " + tube.name + " added to index " + slotIndex);
		} else {
			Debug.Log("FAILURE: Object is missing the KeyTube tag!");
		}
    }

    private void OnTubeRemoved(SelectExitEventArgs args) {
        winScript.currentPlacedTubes[slotIndex] = "";
    }
}