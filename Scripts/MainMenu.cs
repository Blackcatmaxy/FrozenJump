using Godot;
using System;

public partial class MainMenu : Control
{
	[Export] public PackedScene gameScene;
	[Export] public PanelContainer credits;
	
	public void PlayGame()
	{
		GetTree().ChangeSceneToPacked(gameScene);
	}

	public void ShowCredits()
	{
		credits.Show();
	}
	
	public void Exit()
	{
		GetTree().Quit();
	}
}
