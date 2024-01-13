using Godot;
using System;
using Vector2 = System.Numerics.Vector2;

public partial class Platform : RigidBody2D
{
	private Player _player;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_player = GetNode<Player>("../../Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		var gravity = 10f - (MathF.Abs(_player.Velocity.X) / _player.Speed + 0.5f) * 10;
		if (gravity < 0)
		{
			gravity = 0.5f;
		}

		MoveAndCollide(new Godot.Vector2(0, gravity));
	}
}
