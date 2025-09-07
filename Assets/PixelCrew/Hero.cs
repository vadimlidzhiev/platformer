using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector2 _direction;

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private void Update()
    {
        Vector2 delta = _speed * Time.deltaTime * _direction;
        transform.position += (Vector3)delta;
    }

    public void SaySomething()
    {
        Debug.Log("Something!");
    }
}