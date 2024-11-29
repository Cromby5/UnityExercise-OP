using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the first exercise of the test : Predict the position of the ball if and when it reaches h
public class Exercise1 : MonoBehaviour
{
    // Imagine the ball physics / display code here if expanded beyond this exercise
    // This function should calculate the position of the ball at height h
    // No top boundary, ball will bounce off the left and right walls, and wont at the bottom.
    bool TryCalculateXPositionAtHeight(float h, Vector2 p, Vector2 v, float G, float w, ref float xPosition)
    {
        // Using the quadratic formula : at^2 + bt + c
        // 1: Calculate the a, b and c values of the quadratic formula
        float a = 0.5f * G; // half the value to fit the formula for projectile motion
        float b = v.y; // as is, just taking the y velocity of the ball from the vector2
        float c = p.y - h; // the height of the ball minus the height we want to calculate the x position at

        float t1 = (-b + Mathf.Sqrt(b * b - 4.0f * a * c)) / (2.0f * a); // Calculate the first time the ball reaches the height h
        float t2 = (-b - Mathf.Sqrt(b * b - 4.0f * a * c)) / (2.0f * a); // Calculate the second time the ball reaches the height h? 

        // Really unsure if I would need this in this scenario since we shouldnt be hitting the height twice (diagram).
        // Just remembering that the quadratic formula has 2 solutions from the hours of maths at school of the + / - part of the formula / usually when working with a parabola 

        if (t1 < 0 && t2 < 0) return false; // If both times are negative, the ball will never reach the height h (should not happen but just in case)

        // If one of the times is negative, discard it and use the other time
        float t;
        if (t1 < 0)
        {
            t = t2; // If t1 is negative, set t1 to t2
        }
        else if (t2 < 0)
        {
            t = t1; // If t2 is negative, set t2 to t1
        }
        else
        {
            // We will take the smallest positive value of t1 and t2, I belive this solves the scenario where height may be above the ball rather than below (since that should have 2 values)
            t = Mathf.Min(t1, t2); 
        }
  
        float x = p.x + v.x * t; // Calculate the x position of the ball at the time t (no walls)
        
        // Handle the ball hitting the wall
        x = x % (2 * w);
        if (x > w)
        {
            // If the x position is greater than our width, the ball will hit the right wall
            // Calculate the new x position of the ball when it hits the right wall
            x = 2 * w - x;
        }

        xPosition = x; // Set the xPosition to the calculated x position of the ball at the height h 
        return true;
    }
}
