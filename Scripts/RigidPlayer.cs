using Godot;
using System;

public partial class RigidPlayer : RigidBody2D
{
	[Export]
	public float Accel = 10f, Speed = 30.0f, JumpForce = -40.0f;
	[Export]
	public float SpeedScale { get; private set;  }

	[Export] public int maxJumps = 1;
	private int currentJumps = 0;
	private double deltaJump = 0;
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
		deltaJump += delta;
		
		bool onFloor = jumpZone.GetOverlappingBodies().Count > 0;
		if (onFloor && deltaJump > 0.2)
			currentJumps = 0;
		
		// hacked together double jump
		if (Input.IsActionJustPressed("jump") && (onFloor || (currentJumps < maxJumps && maxJumps > 1)))
		{
			deltaJump = 0;
			GD.Print($"{currentJumps}, {maxJumps}");
			ApplyCentralImpulse(new Vector2(0, JumpForce));
			currentJumps++;
		}
			

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("left", "right", "ui_up", "ui_down");
		direction.Y = 0;
		
		// Don't accelerate over the max speed? Might not be working yet
		if (Mathf.Abs(LinearVelocity.X - (direction.X * Speed)) > 0)
			ApplyCentralImpulse(direction * Accel);

		SpeedScale = MathF.Abs(LinearVelocity.X) / Speed + 0.5f;
	}
}
