using UnityEngine;

public class PhysicsConstants : ScriptableObject
{
    [Header("Гравитационная постоянная")]
    public float GravitationalConstant = 6.674f * Mathf.Pow(10, -11); // G, м³/(кг·с²)

    [Header("Скорость света")]
    public float SpeedOfLight = 299792458f; // c, м/с

    [Header("Постоянная Планка")]
    public float PlanckConstant = 6.62607015f * Mathf.Pow(10, -34); // h, Дж·с

    [Header("Элементарный заряд")]
    public float ElementaryCharge = 1.602176634f * Mathf.Pow(10, -19); // e, Кл

    [Header("Ускорение свободного падения")]
    public float GravityAcceleration = 9.81f; // g, м/с²
}