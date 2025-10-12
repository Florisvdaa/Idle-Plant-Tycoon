using UnityEngine;

public class DiagonalMover : MonoBehaviour
{
    [SerializeField] private Vector2 direction = new Vector2(1, 1);
    [SerializeField] private float speed = 0.5f;

    private void Update()
    {
        transform.position += (Vector3)(direction.normalized * speed * Time.deltaTime);
    }
}
