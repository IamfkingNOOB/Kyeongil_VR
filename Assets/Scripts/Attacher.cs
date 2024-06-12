using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Attacher : MonoBehaviour
{
    private IXRSelectInteractable _selectInteractable;

    protected void OnEnable()
    {
        _selectInteractable = GetComponent<IXRSelectInteractable>();

        // Null Check
        if (_selectInteractable as Object == null)
        {
            Debug.LogError("Attacher Needs SelectInteractable!");
            return;
        }

        // Add Event
        _selectInteractable.selectEntered.AddListener(OnSelectEntered);
    }

    protected void OnDisable()
    {
        if (_selectInteractable as Object != null)
        {
            // Remove Event
            _selectInteractable.selectEntered.RemoveListener(OnSelectEntered);
        }
    }

    // Interactable Events
    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if ((args.interactorObject is XRRayInteractor) == false) return;

        Transform attachTransform = args.interactorObject.GetAttachTransform(_selectInteractable);
        Pose originAttachPos = args.interactorObject.GetLocalAttachPoseOnSelect(_selectInteractable);

        attachTransform.SetLocalPose(originAttachPos);
    }
}
