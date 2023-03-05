# Unity Timer

A simple timer class for Unity that uses the UniTask library for asynchronous operations.

## Installation

### Unity Package Manager

1. Open the Package Manager window in Unity
2. Click on the `+` icon in the top-left corner and select "Add package from git URL"
3. Paste in the following URL: `https://github.com/your-username/unity-timer.git`
4. Click the "Add" button

### Manual Installation

1. Clone or download this repository
2. Copy the `Timer` folder into your Unity project

## Usage

```csharp
using UnityEngine;
using Cysharp.Threading.Tasks;

public class MyBehaviour : MonoBehaviour
{
    private Timer timer;

    private void Start()
    {
        timer = new Timer(10f);
        timer.OnTimerComplete += OnTimerCompleteHandler;
        timer.Start();
    }

    private async UniTask OnTimerCompleteHandler()
    {
        Debug.Log("Timer complete!");
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        Debug.Log("Delay complete!");
    }
}

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License

[MIT](https://choosealicense.com/licenses/mit/)

## Acknowledgements
Thanks to [@neuecc](https://github.com/neuecc) for creating UniTask.
