using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "New Entity", menuName = "Entity")]
public class Entity : ScriptableObject
{
    public new string name;
    public int health;
    public int maxhealth;
    public int damage;

    public void ResetHealth()
    {
        health = maxhealth;
    }
    public void takeDamage(int damage)
    {
        health -= damage;
    }
    public bool isDead()
    {
        return health == 0;
    }
}