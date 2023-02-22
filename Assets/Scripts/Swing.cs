using UnityEngine;

public class Swing : MonoBehaviour
{
    private readonly float _swingVelocity = 130f;

    private bool _attached;

    private HingeJoint2D _lastRopeSegment;
    private DistanceJoint2D _rope;
    private Rigidbody2D _rigidbody;

    private CapsuleCollider2D _collider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();
    }

    public void Attach(GameObject ropeGameObject)
    {
        if (_attached)
            return;

        transform.position = new Vector2(ropeGameObject.transform.position.x,
            GetMinGameObjectPoint<CapsuleCollider2D>(ropeGameObject.transform).y -
            _collider.size.y / 2);

        _rope = ropeGameObject.transform.parent.gameObject.GetComponent<DistanceJoint2D>();
        _lastRopeSegment = ropeGameObject.GetComponent<HingeJoint2D>();
        transform.rotation = _lastRopeSegment.transform.rotation;

        _lastRopeSegment.connectedBody = _rigidbody;
        _rope.connectedBody = _rigidbody;
        _lastRopeSegment.connectedAnchor = new Vector2(0, _collider.size.y / 2);
        _rope.connectedAnchor = new Vector2(0, _collider.size.y / 2);
        _lastRopeSegment.enabled = true;
        _rope.enabled = true;
        _attached = true;
    }

    public void Detach()
    {
        if (!_attached)
            return;

        _lastRopeSegment.connectedBody = null;
        _rope.connectedBody = null;
        _lastRopeSegment.enabled = false;
        Rigidbody2D ropeSegmentRigidbody = _lastRopeSegment.transform.GetComponent<Rigidbody2D>();
        _rope.connectedBody = ropeSegmentRigidbody;
        _rope.connectedAnchor = Vector2.zero;
        _attached = false;
    }

    private static Vector2 GetMinGameObjectPoint<T>(Transform target) where T : Collider2D =>
        target.GetComponent<T>().bounds.min;

    private void Update()
    {
        _rigidbody.AddForce(new Vector2(Input.GetAxis("Horizontal") * _swingVelocity * Time.deltaTime, 0));
    }
}