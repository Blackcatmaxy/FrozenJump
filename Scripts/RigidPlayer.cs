using Godot;
using System;

public partial class RigidPlayer : RigidBody2D
{
	[Export]
	public float Accel = 10f, Speed = 30.0f, JumpForce = -40.0f;
	[Export]
	public float SpeedScale { get; private set;  }
	public Area2D jumpZone;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	// public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready()
	{
		ContactMonitor = true;
		MaxContactsReported = 99;

		jumpZone = GetNode<Area2D>("Area2D");
	}
	
	public override void _PhysicsProcess(double delta)
	{
		bool onFloor = jumpZone.GetOverlappingBodies().Count > 0;

		if (Input.IsActionJustPressed("ui_accept") && onFloor)
		{
			ApplyCentralImpulse(new Vector2(0, JumpForce));
			GD.Print("Juml");
		}
			

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		direction.Y = 0;
		
		// Don't accelerate over the max speed? Might not be working yet
		if (Mathf.Abs(LinearVelocity.X - (direction.X * Speed)) > 0)
			ApplyCentralImpulse(direction * Accel);

		SpeedScale = MathF.Abs(LinearVelocity.X) / Speed + 0.5f;
	}
}
