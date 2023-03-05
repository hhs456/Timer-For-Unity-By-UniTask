# Unity-Timer
A simple timer class for Unity using UniTask. Supports events for timer ticks and completion. Easy to use and customize. Perfect for games and other applications that require timed events.

Timer
A simple timer class for Unity, written in C# and utilizing the UniTask library.

Usage
Add the Timer.cs script to your Unity project.
Create a new instance of the Timer class, passing in the desired duration in seconds.
Subscribe to the OnTimerTick event to receive a callback each time the timer ticks.
Subscribe to the OnTimerComplete event to receive a callback when the timer reaches its end.
Call Start() to begin the timer.
Call Stop() to stop the timer before it has completed.
csharp
Copy code
Timer timer = new Timer(60f); // 60 second timer
timer.OnTimerTick += HandleTimerTick;
timer.OnTimerComplete += HandleTimerComplete;
timer.Start();

private async UniTask HandleTimerTick()
{
    // Handle timer tick
}

private async UniTask HandleTimerComplete()
{
    // Handle timer complete
}
Requirements
Unity 2018.4 or higher
UniTask 2.0.14 or higher
License
This project is licensed under the MIT License. See the LICENSE file for details.

Acknowledgements
This project uses the UniTask library for asynchronous programming.

Special thanks to @YourGitHubUsername for providing the initial implementation and code review.
