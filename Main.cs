using Godot;
using System;

public class Main : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;`s
	// private string b = "text";
	private Sprite stickGate;
	private Sprite stickHead;
	// Called when the node enters the scene tree for the first time.
	private Vector2 stickOrigin;

	private int maxTravel = 30;
	public override void _Ready()
	{
		stickGate = GetNode("./StickGate") as Sprite;
		stickHead = GetNode("./StickGate/StickHead") as Sprite;
		
		stickOrigin = stickGate.Position;
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		float xaxis = Input.GetJoyAxis(0, (int)JoystickList.Axis0);
		float yaxis = Input.GetJoyAxis(0, (int)JoystickList.Axis1);
		Vector2 unroundedVetor = new Vector2(xaxis, yaxis);
		float angle = (float)Math.Atan2(yaxis, xaxis);
		float angleRounded = (float)(Math.Round(((angle)/(Math.PI*2))*8))/8;
		float angleInRadians = (float)(angleRounded*Math.PI*2);
		bool light = Input.IsActionPressed("light");
		bool heavy = Input.IsActionPressed("heavy");
		Vector2 gateRegion = stickGate.GetRect().Size;
		//stickHead.Position = stickOrigin + new Vector2(xaxis * maxTravel, yaxis * maxTravel);
		var stickDistance = new Vector2(Math.Abs(xaxis), Math.Abs(yaxis)).Length() * maxTravel;
		stickHead.Position = stickOrigin + stickDistance * new Vector2((float)Math.Cos(angleInRadians), (float)Math.Sin(angleInRadians));
		Label labelA = GetNode("A") as Label;
		Label labelB = GetNode("B") as Label;
		labelA.Text = light ? "(A)":"a";
		labelB.Text = heavy ? "(B)":"b";
	}

	private void _on_InputStack_DirectionInputted(Direction direction)
	{
		GD.Print(direction);
	}

	private void _on_InputStack_MoveInputted(string move)
	{
		GD.Print(move);
	}
	
}






