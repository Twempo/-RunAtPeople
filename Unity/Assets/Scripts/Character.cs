using UnityEngine;

//[CreateAssetMenu()]
public class Character : ScriptableObject
{
    PlayerController.Character enumValue;
    new string name;

    float jumpForce;
    float moveSpeed;

    Vector2 footColliderOffset;
    Vector2 footColliderScale;
}
