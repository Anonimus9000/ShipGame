using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] private float _rateOfTurn = 1.0f;
    [SerializeField] private float _health = 100f;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Camera _aimLeftCamera;
    [SerializeField] private Camera _aimRightCamera;

    private Rigidbody _rigidbody;
    private Vector3 _moveDirection = Vector3.zero;
    private ShipController _ship;
    private CannonController[] _cannons;
    private bool _isRightFire = true;

    private enum ActionCamera
    {
        MainCamera,
        LeftDeck,
        RightDeck
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _ship = GetComponent<ShipController>();
        _aimLeftCamera.gameObject.SetActive(false);
        _aimRightCamera.gameObject.SetActive(false);
    }

    private void Start()
    {
        _cannons = GetComponentsInChildren<CannonController>();
    }

    private void Update()
    {
        Aim();
    }

    private void FixedUpdate()
    {
        MovementLogic();
    }

    public void TakeDamage(float damage)
    {
        if (_health > 0)
            _health -= damage;
    }

    private void Aim()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _isRightFire = false;

            SetCamera(ActionCamera.LeftDeck);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            _isRightFire = true;

            SetCamera(ActionCamera.RightDeck);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            Invoke(nameof(SetMainCamera), 1.5f);
            Fire(_isRightFire);
        }

        if (Input.GetButtonUp("Fire2"))
        {
            Invoke(nameof(SetMainCamera), 1.5f);
            Fire(_isRightFire);
        }
    }

    private void SetMainCamera()
    {
        _mainCamera.gameObject.SetActive(true);
        _aimRightCamera.gameObject.SetActive(false);
        _aimLeftCamera.gameObject.SetActive(false);
    }

    private void SetCamera(ActionCamera actionCamera)
    {
        if (actionCamera == ActionCamera.MainCamera)
        {
            _mainCamera.gameObject.SetActive(true);
            _aimRightCamera.gameObject.SetActive(false);
            _aimLeftCamera.gameObject.SetActive(false);
        }

        else if (actionCamera == ActionCamera.LeftDeck)
        {
            _mainCamera.gameObject.SetActive(false);
            _aimRightCamera.gameObject.SetActive(false);
            _aimLeftCamera.gameObject.SetActive(true);
        }

        else if (actionCamera == ActionCamera.RightDeck)
        {
            _mainCamera.gameObject.SetActive(false);
            _aimRightCamera.gameObject.SetActive(true);
            _aimLeftCamera.gameObject.SetActive(false);
        }
    }

    private void MovementLogic()
    {
        _rigidbody.AddRelativeForce(Vector3.forward * (Input.GetAxis("Vertical") * _moveSpeed * Time.fixedDeltaTime));

        _rigidbody.AddTorque(new Vector3(0.0f, Input.GetAxis("Horizontal"), 0.0f) *
                             (_rateOfTurn * Time.fixedDeltaTime));
    }

    private void Fire(bool rightFire)
    {
        if (rightFire)
            foreach (var cannon in _cannons)
                if (cannon.IsRightCannon())
                    cannon.Fire();

        if (!rightFire)
            foreach (var cannon in _cannons)
                if (!cannon.IsRightCannon())
                    cannon.Fire();
    }
}