using Godot;
using System;
using FrozenJump.Scripts;

public partial class Shop : Sprite2D
{
	[Export] public Control shopToggle;
	[Export] public CameraFollower cameraFollower;
	[Export] public RigidPlayer player;
	private MenuButton menuButton;
	private PopupMenu popupMenu;
	private bool[] toggles = new bool[5];

	private PlayerUpgrade[] upgrades = new[] { 
		new PlayerUpgrade() { Accel = 2, Speed = 3, JumpForce = -200 }, 
		new PlayerUpgrade() { JumpForce = 175, MaxJumps = 1}
	};
	
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
		popupMenu.SetItemDisabled(1, (meters < 20));
	}

	public void OnPress(int index)
	{
		toggles[index] = !toggles[index];
		popupMenu.SetItemChecked(index, toggles[index]);
		if (popupMenu.IsItemChecked(index))
		{
			upgrades[index].ApplyUpgrade(player);
		}
		else
		{
			upgrades[index].RemoveUpgrade(player);
		}
	}
	
	public void OnLeave(Node2D body)
	{
		shopToggle.Visible = false;
	}
}
