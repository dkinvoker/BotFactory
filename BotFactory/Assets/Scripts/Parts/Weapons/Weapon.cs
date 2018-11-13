namespace Assets.Scripts.Parts.Weapons
{
    public abstract class Weapon
    {
        public double Damage { get; protected set; }
        public double ReloadTime { get; protected set; }
        public double BulletSpeed { get; protected set; }
    }
}

