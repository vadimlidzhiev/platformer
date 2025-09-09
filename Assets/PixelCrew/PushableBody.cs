using UnityEngine;

public class PushableBody : MonoBehaviour
{
    [SerializeField] private float _pushImpulse = 200f;
    [SerializeField] private float _maxHorizontalSpeed = 0.8f;
    [SerializeField] private float _topTolerance = 0.02f; // допуск для проверки "герой на бочке"

    private Rigidbody2D _rigidbody;
    private Collider2D _сollider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _сollider = GetComponent<Collider2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.rigidbody == null)
            return;
        if (!collision.rigidbody.TryGetComponent<PlayerPusher>(out _))
            return;

        var myTop = _сollider.bounds.max.y;
        var playerBottom = collision.collider.bounds.min.y;
        bool playerOnTop = playerBottom >= myTop - _topTolerance;
        if (playerOnTop)
            return;

        if (Mathf.Abs(_rigidbody.velocity.x) >= _maxHorizontalSpeed)
            return;

        float pushDirection = Mathf.Sign(_rigidbody.position.x - collision.rigidbody.position.x);
        if (pushDirection == 0f)
            return;

        _rigidbody.AddForce(new Vector2(pushDirection * _pushImpulse, 0f), ForceMode2D.Impulse);
    }
}