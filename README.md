# FG Input
---
 - This is just an experiment into fighting game inputs using Godot.
 - In games like Street Fighter, there are special input moves which involve multiple inputs, for quarter circle forward + punch = hadouken
 ![Ryu performing a hadouken](https://media1.tenor.com/images/cc8c802f04e9899e085b3fc9b7037389/tenor.gif?itemid=9352787)
 - So we have the inputs being pressed every frame, how do we translate this to recognise this as a hadouken

## Current Idea
 - The main gist of the idea is store the joystick inputs as a stack, and when the player presses an attack button, check through the stack to see if there are any potential input moves.
 - First we simplify the joystick input. The majority of fighting games simplify this to 8 points, the compass points + the half way points between them. (Plus one more for no input)
 - Then every frame, we round the current joystick input to 1 of the 8 points and add this input to a stack
 
 The problem here is now if we store every input on every frame, there are going to be multiples of every input, unless the player is frame perfect. So my solution to this is:
 - The stack stores inputs in bundles of MAX_FRAMES
 - When you're adding a new input to the stack
	- If the last one on the stack hasn't reached MAX_FRAMES, we add 1 to that
	- Otherwise if it has, _or_ if it's a different input, add a new bundle to the stack
 - So this means the player has a MAX_FRAMES window to input every direction

 - Another issue that arises is the issue of idle/no inputs. If we just ignore them,then technically S, SE and S, (10 days of no input), SE are the same input.
 - My solution to this is clear the stack after MAX_FRAMES of no input.s
 - This is to add some leniency, but it may just be better to clear the stack after 1 frame of no input.

 So now we have the stack of inputs that we can pop for any potential input moves. The next issue is how to check for inputs. So far I have two solutions:
 **Tree Traversal**
  - Start off with a list of input moves
  - We can convert this into trees, the root being each of the 8 directions. The children are the next direction for that input move. Every time an input is pressed we can follow the tree until either they press a direction that doesn't match a move, or we reach a move.
  - I think this will be faster to run, but harder to implement

  **Pattern Matching**
  - We have a list of moves
  - When we're going through the stack of inputs, treat them like a stack as well and compare each popped item for each move to the current input.
  - If the needed input matches the current input, keep going with that move.
  - If it doesn't then we can stop checking that move and remove it from the list
  - Either the list will end up empty (no moves), or a move stack will end up empty, in which case then input that move.

