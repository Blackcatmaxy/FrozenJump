using Godot;
using System;

public partial class Shop : Sprite2D
{
	[Export] public Control shopToggle;
	[Export] public CameraFollower cameraFollower;
	[Export] public RigidPlayer player;
	private MenuButton menuButton;
	private PopupMenu popupMenu;
	private bool[] toggles = new bool[5];
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		menuButton = shopToggle.GetNode<MenuButton>("MenuButton");
		popupMenu = menuButton.GetPopup();
		popupMenu.IdPressed += id =>  OnPress((int)id);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public void OnEnter(Node2D body)
	{
		shopToggle.Visible = true;
		var meters = cameraFollower.highest;
		popupMenu.SetItemDisabled(0, (meters < 10));
		
	}

	public void OnPress(int index)
	{
		toggles[index] = !toggles[index];
		popupMenu.SetItemChecked(0, toggles[index]);
		if (popupMenu.IsItemChecked(index))
		{
			player.Accel = 7;
			player.Speed = 18;
			player.JumpForce = -750;
		}
		else
		{
			player.Accel = 5;
			player.Speed = 15;
			player.JumpForce = -500;
		}
	}
	
	public void OnLeave(Node2D body)
	{
		shopToggle.Visible = false;
	}
}
