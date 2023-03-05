# Unity Timer

This is a simple timer tool that can be used in Unity games. It provides a simple API that allows you to create timers, set durations, start and stop timers, and register timer callbacks. It is based on Unity's [UniTask](https://github.com/Cysharp/UniTask) library and implemented using `C# 7.0`'s `async/await` syntax.

## Installation

You can integrate Timer into your Unity project by following these steps:

1. Download the [Unity-Timer](https://github.com/hhs456/Unity-Timer) code repository from `GitHub`.
2. Copy the `Timer.cs` file into the Assets folder in your Unity project.

## Usage

### Creating a Timer

To create a timer, simply create a new `Timer` object in Unity and specify the duration:

```csharp
Timer timer = new Timer(10f); // Set duration to 10 seconds
```

### Registering Callbacks

To register callbacks during the timer's runtime, simply subscribe to the `OnTimerTick` and `OnTimerComplete` events:：

```csharp
timer.OnTimerTick += OnTick; // Register tick callback
timer.OnTimerComplete += OnComplete; // Register complete callback
```
In the `OnTick` method, you can update the UI or perform any other necessary operations. In the `OnComplete` method, you can perform any necessary cleanup operations.

### Starting and Stopping the Timer

Start the timer:

```csharp
timer.Start();
```

Stop the timer:

```csharp
timer.Stop();
```

### Notes

During the timer's runtime, the `OnTimerTick` event will be triggered every 0.1 seconds until the timer completes. If the timer completes, the `OnTimerComplete` event will be triggered.

## Contributing

If you find any errors or would like to make a contribution, please open an issue or submit a pull request on `GitHub`.

## License

This timer is licensed under the [MIT](https://choosealicense.com/licenses/mit/) License. See the `LICENSE` file for more details.

## Acknowledgements
Thanks to [UniTask](https://github.com/Cysharp/UniTask) for providing async/await functionality, making it easier for us to use timers. Special thanks to the developers of [UniTask](https://github.com/Cysharp/UniTask) for providing such a great tool.
