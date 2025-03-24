using UnityEngine;

[CreateAssetMenu(fileName = "New Spell Data", menuName = "ScriptableObject/Spell Data")]
public class SpellData : ScriptableObject
{
    public string Name;
    public bool IsAcsessed;
    public bool IsActive;
    public Sprite AnimatedImage;
    public GameObject VFX_Effect;
    public float CastDelay;
    public float Damage;
    public float CastSpeed;
    public AudioClip ActivationSound;
    public AudioClip DeactivationSound;
}