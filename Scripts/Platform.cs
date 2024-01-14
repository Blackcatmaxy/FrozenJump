using Godot;
using System;
using Vector2 = System.Numerics.Vector2;

public partial class Platform : RigidBody2D
{
	private RigidPlayer _player;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_player = GetNode<RigidPlayer>("../../Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		var gravity = 10f - _player.SpeedScale * 10;
		if (gravity < 0)
		{
			gravity = 0.5f;
		}

		MoveAndCollide(new Godot.Vector2(0, gravity));
	}
}
