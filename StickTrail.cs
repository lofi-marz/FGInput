using Godot;
using System;

public class StickTrail : Line2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		float xaxis = Input.GetJoyAxis(0, (int)JoystickList.Axis0);
		float yaxis = Input.GetJoyAxis(0, (int)JoystickList.Axis1);
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
