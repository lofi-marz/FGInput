using Godot;
using System;
using System.Collections.Generic;
public class InputStack : Node
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	const float DEADZONE = 0.1f;

	private Stack<DirectionInput> inputs;
	private int idleFrames = 0;
	MoveDictionary moves;
	[Signal]
	public delegate void MoveInputted(string move);

	public override void _Ready()
	{
		inputs = new Stack<DirectionInput>();
		moves = new MoveDictionary();
		moves.Moves.Add("hadouken", new List<Direction> {Direction.S, Direction.SE, Direction.E});
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
	  	Direction currentInput = getInputDirection();
		//GD.Print((Direction)angleRounded);
		if (currentInput == Direction.None) {
			idleFrames++;
			if (idleFrames > DirectionInput.MAX_FRAMES) {
				inputs.Clear(); //If we go too many frames with no input, clear the stack
			}
			return;
		} else {
			idleFrames = 0;
		}
		UpdateInputStack(currentInput);
		if (Input.IsActionJustPressed("light") || Input.IsActionJustPressed("heavy")) {
			var move = moves.CheckMoves(inputs);
			if (move != "") {
				EmitSignal(nameof(MoveInputted), move);
			}

			inputs.Clear();
		}
		
  }


  private Direction getInputDirection() {
	  	float xaxis = Input.GetJoyAxis(0, (int)JoystickList.Axis0);
		float yaxis = Input.GetJoyAxis(0, (int)JoystickList.Axis1);
		float angle = (float)Math.Atan2(yaxis, xaxis);
		int angleRounded = (8-(int)(Math.Round(((angle)/(Math.PI*2))*8))) % 8 +1;
		if (new Vector2(xaxis, yaxis).Length() < DEADZONE) angleRounded = 0;
		Direction currentInput = (Direction)angleRounded;
		return currentInput;
  }

  private void UpdateInputStack(Direction currentInput) {
	  //	GD.Print("Inputs:");
		foreach (var input in inputs.ToArray())
		{
			//GD.Print(input);
		}
		if (inputs.Count > 0) {
			DirectionInput lastInput = inputs.Pop();
			if (lastInput.Count >= DirectionInput.MAX_FRAMES || lastInput.Direction != currentInput) {
				inputs.Push(lastInput);
				inputs.Push(new DirectionInput(currentInput));
			} else {
				lastInput.Count++;
				inputs.Push(lastInput);
			}
		} else {
			inputs.Push(new DirectionInput(currentInput));
		}
  }



  
}
