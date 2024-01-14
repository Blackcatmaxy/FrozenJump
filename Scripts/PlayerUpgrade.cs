namespace FrozenJump.Scripts;

public class PlayerUpgrade
{
    public int MaxJumps;
    public float Accel, Speed, JumpForce;

    public void ApplyUpgrade(RigidPlayer player)
    {
        player.maxJumps += MaxJumps;
        player.Accel += Accel;
        player.Speed += Speed;
        player.JumpForce += JumpForce;
    }

    public void RemoveUpgrade(RigidPlayer player)
    {
        player.maxJumps -= MaxJumps;
        player.Accel -= Accel;
        player.Speed -= Speed;
        player.JumpForce -= JumpForce;
    }
}