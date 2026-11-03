using UnityEngine;

public class PhysicsConstants : ScriptableObject
{
    [Header("Гравитационная постоянная")]
    public float gravitationalConstant = 6.674f * Mathf.Pow(10, -11); // G, м³/(кг·с²)

    [Header("Скорость света")]
    public float speedOfLight = 299792458f; // c, м/с

    [Header("Постоянная Планка")]
    public float planckConstant = 6.62607015f * Mathf.Pow(10, -34); // h, Дж·с

    [Header("Элементарный заряд")]
    public float elementaryCharge = 1.602176634f * Mathf.Pow(10, -19); // e, Кл

    [Header("Ускорение свободного падения")]
    public float gravityAcceleration = 9.81f; // g, м/с²
}