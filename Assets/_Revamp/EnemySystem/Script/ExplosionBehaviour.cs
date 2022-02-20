using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    private async void Awake()
    {
        Destroy(gameObject, 2.5f);
    }
}
