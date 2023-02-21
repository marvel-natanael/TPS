using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine;
using System;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField]
    private PlayerInput _playerInput;
    [SerializeField]
    private int _priorityAmount = 5;
    [SerializeField]
    private Canvas _mainCanvas;
    [SerializeField]
    private Canvas _aimCanvas;
    private CinemachineVirtualCamera _vCam;

    private InputAction _aimAction;

    private void Awake()
    {
        _vCam = GetComponent<CinemachineVirtualCamera>();
        _aimAction = _playerInput.actions["Aim"];
    }

    private void OnEnable()
    {
        _aimAction.performed += _ => StartAim();
        _aimAction.canceled += _ => CancelAim();
    }

    private void OnDisable()
    {
        _aimAction.performed -= _ => StartAim();
        _aimAction.canceled -= _ => CancelAim();
    }

    private void StartAim()
    {
        _vCam.Priority += _priorityAmount;
        _aimCanvas.enabled = true;
        _mainCanvas.enabled = false;
    }

    private void CancelAim()
    {
        _vCam.Priority -= _priorityAmount;
        _aimCanvas.enabled = false;
        _mainCanvas.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
