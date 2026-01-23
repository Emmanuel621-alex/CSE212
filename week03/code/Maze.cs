using System;
using System.Collections.Generic;

/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x, y) : [left, right, up, down]
/// 
/// 'x' and 'y' are integers and represent locations in the maze.
/// 'left', 'right', 'up', and 'down' are booleans representing valid directions.
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1; // Starting position x
    private int _currY = 1; // Starting position y

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;

        // Check if the starting position is valid
        if (!_mazeMap.ContainsKey((_currX, _currY)))
        {
            throw new ArgumentException("The starting position is not defined in the maze map.");
        }
    }

    /// <summary>
    /// Check to see if you can move left. If you can, then move. If you can't move, 
    /// throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        Move(-1, 0);
    }

    /// <summary>
    /// Check to see if you can move right. If you can, then move. If you can't move, 
    /// throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        Move(1, 0);
    }

    /// <summary>
    /// Check to see if you can move up. If you can, then move. If you can't move, 
    /// throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        Move(0, -1);
    }

    /// <summary>
    /// Check to see if you can move down. If you can, then move. If you can't move, 
    /// throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        Move(0, 1);
    }

    /// <summary>
    /// Helper method to handle movement based on direction deltas.
    /// </summary>
    private void Move(int deltaX, int deltaY)
    {
        var newX = _currX + deltaX;
        var newY = _currY + deltaY;

        // Check the validity of the move
        if (!CanMove(deltaX, deltaY))
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // Update the current position
        _currX = newX;
        _currY = newY;
    }

    /// <summary>
    /// Checks whether the move is valid based on the current position.
    /// </summary>
    private bool CanMove(int deltaX, int deltaY)
    {
        var newX = _currX + deltaX;
        var newY = _currY + deltaY;

        // Check if the new position exists within the maze
        if (_mazeMap.TryGetValue((newX, newY), out bool[] directions))
        {
            return (deltaX == -1 && directions[0]) || // left
                   (deltaX == 1 && directions[1]) || // right
                   (deltaY == -1 && directions[2]) || // up
                   (deltaY == 1 && directions[3]); // down
        }

        return false; // Out of bounds (wall)
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}