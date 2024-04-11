
public enum WeaponType
{
    Pistol,
    Revolver,
    AutoRifle,
    Shotgun,
    Rifle
}


[System.Serializable] // Makes class visible in the inspector
public class Weapon 
{
    public WeaponType weaponType;
    public int ammo;
    public int maxAmmo;
}
