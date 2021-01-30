
using System.Collections; 
using System; 
using System.Collections.Generic;
using System.Linq;
using Godot;
public class MoveDictionary {
	public Dictionary<string, List<Direction>> Moves;
	public MoveDictionary() {
		Moves = new Dictionary<string, List<Direction>>();
	}

	public string CheckMoves(Stack<DirectionInput> inputs) {
		var inputList = inputs.ToList();
		
		foreach (var move in Moves)
		{
			move.Value.Reverse();
			var i = 0;
			for (i = 0; i < move.Value.Count; i++) {
				
				if (move.Value.Count > inputList.Count) break;
				GD.Print($"{move.Value[i]} == {inputList[i].Direction}");
				if (move.Value[i] != inputList[i].Direction) break;
			}
			GD.Print(i);
			if (i == move.Value.Count) return move.Key; //If we reach the end of the move list and everything has matched up, return the move
		}
		return "";
	}
}