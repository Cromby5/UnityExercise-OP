using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  Exercise 2: Match-3 game 
public class Board
{
    enum JewelKind
    {
        Empty,
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet
    }
    enum MoveDirection
    {
        Up,
        Down,
        Left,
        Right
    }
    struct Move
    {
        public int x;
        public int y;
        public MoveDirection direction;
    }
    int GetWidth();
    int GetHeight();
    JewelKind GetJewel(int x, int y);
    void SetJewel(int x, int y, JewelKind kind);

    Move CalculateBestMoveForBoard()
    {
        // Implement this function

        // The best move for a given board is thus the one that will remove the most jewels.
        // 1 Point for each jewel removed. 3 points will be the minimum score for a move (match-3).
        // In theory each check only needs to move the current jewel in 2 directions, in this case right or down, as we will check all the jewels in the board,
        // no need to recheck up or left as done previously.

        // 1: Loop through all the jewels on the board using our GetWidth() and GetHeight() functions, using the size of our board for further checks

        // 2: Check if the current jewel can be swapped with the jewel to the right
        // 2.1: Carry out the swap virtually (player wont see any of these checks) and check if the swap will result in a match-3
        // 2.2: If it does, calculate the score for the move and store it if it is the best move so far
        // 2.3: Make sure the jewels back to their original positions (virtually)


        // 3: Check if the current jewel can be swapped with the jewel below
        // 3.1: Carry out the swap virtually (player wont see any of these checks) and check if the swap will result in a match-3
        // 3.2: If it does, calculate the score for the move and store it if it is the best move so far
        // 3.3: Make sure the jewels back to their original positions (virtually)

        // 4: Return the best move for the board, presumably then used by an AI to make a move or for a player to see the best move available through powerups
        return new Move(); 
    }
}
