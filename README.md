# Math Quiz
Math Quiz Game is an educational Windows Forms application developed in Visual Studio 2022 using C#. It's designed to help users practice basic arithmetic operations through a timed quiz format that challenges their mental math skills while tracking performance.
## Objective
Create an interactive and engaging math practice tool that tests users on fundamental arithmetic operations (addition, subtraction, multiplication, and division) under time pressure, providing immediate feedback and score tracking.

# Core Features

## Game Mechanics
- 60-Second Timer: Countdown timer that creates urgency and challenge
- Randomized Problems: Automatically generates unique math problems
- Four Operations: Supports +, -, ×, ÷ with integer results
- Score Tracking: Real-time score display for correct answers
- Input Validation: Ensures only numeric input is accepted
# Initialization Phase
- Form loads with disabled game controls
- Welcome message displayed
- Only "Start" button is active
- Timer reset to 60 seconds, score to 0
# Game play Phase
- User clicks "Start" to begin
- Timer starts counting down from 60
- First random math problem appears
- TextBox enabled for answer input
- "Submit" and "Next" buttons activated
 # Problem Solving
- User enters answer and clicks "Submit" or presses Enter
- Immediate feedback (Correct/Incorrect popup)
- Score increments for correct answers
- "Next" button generates new problem
- Division problems ensure integer results
# Game Completion
- Timer reaches zero
- All game controls disabled
- Final score displayed
- "Start" button re-enabled for replay
# Learning Outcomes
This project demonstrates:
- Windows Forms development
- Timer control implementation
- Random number generation
- Event handling in C#
- User input validation
- State management in desktop applications
- Educational software design principles

The Math Quiz Game serves as an excellent example of combining educational content with engaging gameplay mechanics, making it both a practical learning tool and a demonstration of fundamental Windows Forms programming concepts.
