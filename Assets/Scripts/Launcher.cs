using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Launcher : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private float _projectileSpeed;

    private XRGrabInteractable _grabInteractable;

    private void OnEnable()
    {
        _grabInteractable = GetComponent<XRGrabInteractable>();
        _grabInteractable.activated.AddListener(Fire);
    }

    private void OnDisable()
    {
        if (_grabInteractable != null)
        {
            _grabInteractable.activated.RemoveListener(Fire);
        }
    }

    private void Fire(ActivateEventArgs args)
    {
        GameObject newObj = Instantiate(_projectilePrefab, _shootPosition.position, _shootPosition.rotation);
        
        if (newObj.TryGetComponent(out Rigidbody rb))
        {
            ApplyForce(rb);
        }
    }

    private void ApplyForce(Rigidbody rb)
    {
        Vector3 force = _shootPosition.forward * _projectileSpeed;
        rb.AddForce(force);
    }
}
