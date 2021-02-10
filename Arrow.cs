using Godot;
using System;

public class Arrow : CenterContainer
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
	
	public void Init(Direction direction) {
		var arrow = GetNode("./Texture") as TextureRect;
		arrow.RectRotation = 360 * ((int)direction)/8;
		GD.Print(arrow.RectRotation);
		this.RectScale = new Vector2(0.1f, 0.1f);
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
