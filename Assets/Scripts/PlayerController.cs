using UnityEngine;

[RequireComponent(typeof(Slide))]
[RequireComponent(typeof(Swing))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool _multipleJump = false;
    [SerializeField] private float _jumpSpeed = 7f;

    private Swing _swing;
    private Slide _slide;

    private void Start()
    {
        _swing = GetComponent<Swing>();
        _slide = GetComponent<Slide>();
    }

    private void Update()
    {
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && (_slide.Grounded || _multipleJump))
            _slide.Velocity = new Vector2(_slide.Velocity.x, _jumpSpeed);

        // Detach from rope
        if (Input.GetMouseButtonDown(0))
            _swing.Detach();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.TryGetComponent<Rope>(out Rope rope))
            _swing.Attach(col.gameObject);
    }
}