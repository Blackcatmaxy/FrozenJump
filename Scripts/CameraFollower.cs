using Godot;
using System;

public partial class CameraFollower : Camera2D
{
	[Export]
	public RichTextLabel Label;
	private RigidPlayer _player;

	public int highest;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_player = GetNode<RigidPlayer>("../Player");
		GD.Print($"Hello, world! {_player.Position.X}");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		int height = -(int)(_player.Position.Y / 32);
		if (height > highest)
			highest = height;
		Label.Text = $"Height: {height}/{highest}m";
	}
	
	public override void _PhysicsProcess (double delta)
	{
		var yTarget = Position.Y;
		if (yTarget > _player.Position.Y)
			yTarget = _player.Position.Y;
		var target = new Vector2(_player.Position.X, yTarget);
		var speed = 0.666f * Mathf.Abs(Position.X - _player.Position.X) * (float)delta;
		Position = Position.MoveToward(target, speed);
	}
}
