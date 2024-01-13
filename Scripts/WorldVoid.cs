using Godot;
using System;

public partial class WorldVoid : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	public void _body_entered(Node2D body)
	{
		// GD.Print($"Body enters {body.GetNode<Platform>(".") != null}");
		if (body.GetNodeOrNull<Platform>(".") != null)
			body.Position = new Vector2(body.Position.X, -700);
		else if (body.GetNodeOrNull<Player>(".") != null)
			body.Position = new Vector2(-284, -18);
	}
}
