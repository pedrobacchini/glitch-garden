using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

public class Projectile : SerializedMonoBehaviour
{
    [PropertyRange(0f, 5f)]
    [OdinSerialize]
    public float MovementSpeed { get; set; } = 1f;
    
    private void Update()
    {
        transform.Translate(MovementSpeed * Time.deltaTime * Vector2.right);
    }
}
