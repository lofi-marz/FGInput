using Godot;
using System;

public class ArrowDisplay : HBoxContainer
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	public void AddDirection(Direction direction) {
		var newDirection = new Label();
		newDirection.Text = direction.ToString();
		AddChild(newDirection);
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
