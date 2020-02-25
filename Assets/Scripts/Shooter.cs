using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Projectile projectile = null;
    [SerializeField] private GameObject gun = null;

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, Quaternion.identity);
    }
}