using Godot;
using System;

public partial class PlatformSpawner : Node2D
{
	[Export]
	public PackedScene platform;
	[Export]
	public float spawnRange = 10, spawnInterval = 3;

	private double timeSinceLastSpawn = 0;
	private Random _random = new Random();
	private RigidPlayer _player;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_player = GetNode<RigidPlayer>("../Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		timeSinceLastSpawn += delta / _player.SpeedScale;
		if (timeSinceLastSpawn > spawnInterval)
		{
			timeSinceLastSpawn = 0;
			var created = platform.Instantiate<Platform>();
			AddChild(created);
			var position = Position;
			float offset = _random.NextSingle() * spawnRange - spawnRange/2;
			position.X += offset;
			int scale = _random.Next() % 5;
			
			GD.Print($"Spawning {offset}, {position.X}");
			// created.Position = position;
			
			// PhysicsServer2D.BodySetState(created.GetRid(), PhysicsServer2D.BodyState.Transform, Transform2D.Identity.Translated(position));
			created.Position = position;
			created.Scale = new Vector2(1f/scale, 1);
		}
	}
}
