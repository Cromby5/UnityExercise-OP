using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void SetJewel(int x, int y, JewelKind kind) { }

    // I am making the assumption within this exercise that this board has been copied and will not be used in a way that would affect the original board in the game
    Move CalculateBestMoveForBoard()
    {
        // Implement this function : Exercise 2 Match-3 game 
        // The best move for a given board is thus the one that will remove the most jewels.
        // 1 Point for each jewel removed. 3 points will be the minimum score for a move (match-3).
        // In theory each check only needs to move the current jewel in 2 directions, in this case right or down, as we will check all the jewels in the board,
        // no need to recheck up or left as done previously.

        Move bestMove = new Move(); // Create a new Move to store our best move for the board
        int bestScore = 0; // Store the best score for the board

        // 0: If the board is empty, return an empty move, this may be done elsewhere in the full version of the game (end screen?), but I want to consider it here.
        // 1: Loop through all the jewels on the board using our GetWidth() and GetHeight() functions, using the size of our board for further checks
        for (int x = 0; x < GetWidth(); x++)
        {
            for (int y = 0; y < GetHeight(); y++)
            {
                // 2: Check if the current jewel can be swapped with the jewel to the right
                if (x < GetWidth() - 1)
                {
                    // 2.1: Carry out the swap virtually (player wont see any of these checks, so on a copy) and check if the swap will result in a match-3
                    JewelKind temp = GetJewel(x, y); // get jewel at current position (1,1)
                    SetJewel(x, y, GetJewel(x + 1, y)); // set jewel at current position (1,1) to jewel at position (2,1)
                    SetJewel(x + 1, y, temp); // set jewel at position (2,1) to jewel that was at position (1,1)                   

                    int score = CalculateScore();
                   
                    // Check if the current move is the best move so far
                    if (score > bestScore)
                    {
                        // 2.2: If it does, calculate the score for the move and store it if it is the best move so far
                        bestMove.x = x;
                        bestMove.y = y;
                        bestMove.direction = MoveDirection.Right; // I believe the representatation of this towards the player would be carried out by the display function
                    }
                    // 2.3: Make sure the jewels back to their original positions (since we are only calculating the best move and not carrying it out)
                    temp = GetJewel(x, y);
                    SetJewel(x, y, GetJewel(x + 1, y));
                    SetJewel(x + 1, y, temp);
                }
                // 3: Check if the current jewel can be swapped with the jewel below
                if (y < GetHeight() - 1)
                {
                    // 3.1: Carry out the swap virtually (player wont see any of these checks, so on a copy) and check if the swap will result in a match-3
                    JewelKind temp = GetJewel(x, y);
                    SetJewel(x, y, GetJewel(x, y + 1));
                    SetJewel(x, y + 1, temp);

                    int score = CalculateScore();

                    if (score > bestScore)
                    {
                        // 3.2: If it does, calculate the score for the move and store it if it is the best move so far
                        bestMove.x = x;
                        bestMove.y = y;
                        bestMove.direction = MoveDirection.Down;
                    }
                    // 3.3: Make sure the jewels back to their original positions (since we are only calculating the best move and not carrying it out)
                    temp = GetJewel(x, y);
                    SetJewel(x, y, GetJewel(x, y + 1));
                    SetJewel(x, y + 1, temp);
                }
            }
        }
        // 4: Return the best move for the board, presumably then used by an AI to make a move or for a player to see the best move available through powerups
        return bestMove; 
    }

    int CalculateScore()
    {
        // Since this would be used twice in the CalculateBestMoveForBoard function, I have moved it out into its own function. also should open it to be used elsewhere in the game, such as the real score (though that may have to account for the further movements that jewels make when matched)
        int score = 0;
        // Check for vertical matches
        for (int x = 0; x < GetWidth(); x++) // another loop within that goes through the board, this time looking for matches after the swap
        {
            int count = 1;
            for (int y = 1; y < GetHeight(); y++)
            {
                if (GetJewel(x, y) == GetJewel(x, y - 1))
                {
                    count++; // If a match is found, increment the count
                }
                else
                {
                    count = 1; // If no match is found, reset the count to 1. it is unlikely a match will be found further in the same direction, so we may be able to break here
                }
                if (count >= 3)
                {
                    score += count; // If the count is greater than or equal to 3, increment the score by the count. The score is independent as matches can be found in both directions.
                }
            }
        }
        // Check for horizontal matches, same as before but in the other direction
        for (int y = 0; y < GetHeight(); y++)
        {
            int count = 1;
            for (int x = 1; x < GetWidth(); x++)
            {
                if (GetJewel(x, y) == GetJewel(x + 1, y))
                {
                    count++;
                }
                else
                {
                    count = 1;
                }
                if (count >= 3)
                {
                    score += count;
                }
            }
        }
        return score; // Return the score for the move
    }
}
