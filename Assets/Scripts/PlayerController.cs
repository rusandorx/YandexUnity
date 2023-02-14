using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly float _swingVelocity = 100f;

    private bool _attached = false;

    private HingeJoint2D _lastRopeSegment;
    private DistanceJoint2D _rope;
    private Rigidbody2D _rigidbody;

    void Attach(GameObject ropeGameObject)
    {
        if (_attached)
            return;

        _rope = ropeGameObject.transform.parent.gameObject.GetComponent<DistanceJoint2D>();
        _lastRopeSegment = ropeGameObject.GetComponent<HingeJoint2D>();

        _lastRopeSegment.connectedBody = _rigidbody;
        _rope.connectedBody = _rigidbody;
        _lastRopeSegment.enabled = true;
        _rope.enabled = true;
        _attached = true;

        transform.position = new Vector2(ropeGameObject.transform.position.x,
            ropeGameObject.GetComponent<CapsuleCollider2D>().bounds.min.y - GetComponent<CapsuleCollider2D>().size.y / 2);
    }

    void Detach()
    {
        if (!_attached)
            return;

        _lastRopeSegment.connectedBody = null;
        _rope.connectedBody = null;
        _lastRopeSegment.enabled = false;
        _rope.enabled = false;
        _attached = false;
    }

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Detach();
        }

        _rigidbody.AddForce(new Vector2(Input.GetAxis("Horizontal") * _swingVelocity * Time.deltaTime, 0));
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        string colTag = col.gameObject.tag;
        switch (colTag)
        {
            case "Rope":
                Attach(col.gameObject);
                break;
        }
    }
}