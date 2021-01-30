
public class DirectionInput {
	
	public static readonly int MAX_FRAMES = 10; //After this many frames, take the input as a ew input
	public Direction Direction {get; set;}
	public int Count;

	public DirectionInput(Direction direction, int startCount = 1) {
		this.Direction = direction;
		this.Count = startCount;

	}

	public override string ToString() {
		return $"{Direction}, {Count}";
	}
}