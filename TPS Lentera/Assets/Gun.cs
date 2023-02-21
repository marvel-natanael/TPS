using UnityEngine.InputSystem;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputAction _shootAction;
    private Transform _cameraTransform;
    private Transform _gunPointTransform;

    [SerializeField]
    private GameObject _bulletPrefab;

    private void Awake()
    {
        _playerInput = GetComponentInParent<PlayerInput>();
        _shootAction = _playerInput.actions["Shoot"];
        _gunPointTransform = gameObject.transform.GetChild(0).transform;
        _cameraTransform = Camera.main.transform;
    }

    private void OnEnable()
    {
        _shootAction.performed += _ => Shoot();
    }

    private void OnDisable()
    {
        _shootAction.performed -= _ => Shoot();
    }

    private void Shoot()
    {
        RaycastHit hit;
        GameObject bulletObj = GameObject.Instantiate(_bulletPrefab, _gunPointTransform.position, Quaternion.identity);
        Bullet bullet = bulletObj.GetComponent<Bullet>();

        if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out hit, Mathf.Infinity))
        {
            bullet.target = hit.point;
            bullet.hit = true;
        }
        else
        {
            bullet.target = _cameraTransform.position + _cameraTransform.forward * 25f;
            bullet.hit = false;

        }
    }
}
