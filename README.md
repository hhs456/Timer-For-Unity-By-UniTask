# Unity 計時器

這是一個輕量級的計時器工具，可用於 Unity 遊戲中。提供了一個簡單的API，讓您可以創建計時器，設置持續時間，啟動和停止計時器，以及註冊計時器回調。它是建基於 [UniTask](https://github.com/Cysharp/UniTask)，使用`C# 7.0`的`async/await`語法進行實現。

## 安裝 

你可以通過以下步驟將 Timer 整合到你的 Unity 專案中：

1. 從`GitHub`下載 [Unity-Timer](https://github.com/hhs456/Unity-Timer) 儲存庫。
2. 複製`Timer.cs`文件到你的 Unity 項目中的 Assets 文件夾下。

## 使用方法

### 創建一個計時器

要創建一個計時器，只需在 Unity 中創建一個新的`Timer`物件，並指定持續時間：

```csharp
Timer timer = new Timer(10f); // 設定持續時間為10秒
```

### 註冊回調

要在計時器運行期間註冊回調，只需註冊`OnTimerTick`和`OnTimerComplete`事件：

```csharp
timer.OnTimerTick += OnTick; // 註冊每秒回調
timer.OnTimerComplete += OnComplete; // 註冊完成回調
```

在`OnTick`方法中，您可以更新UI或進行任何其他需要的操作。在`OnComplete`方法中，您可以執行任何必要的清理操作。

### 啟動和停止計時器

啟動計時器：

```csharp
timer.Start();
```

停止計時器：

```csharp
timer.Stop();
```

### 註解

在計時器的運行過程中，每隔0.1秒將觸發一次`OnTimerTick`事件，直到計時器完成。如果計時器完成，將觸發`OnTimerComplete`事件。

## 貢獻

如果您發現任何錯誤或希望做出貢獻，請在`GitHub`上發起一個問題或提交一個拉取請求。

## 授權

此計時器根據 [MIT](https://choosealicense.com/licenses/mit/) 許可證授權。請參閱`LICENSE`文件以了解更多內容。

## 銘謝

感謝 [UniTask](https://github.com/Cysharp/UniTask) 提供的`async/await`功能，讓我們可以更輕鬆地使用計時器。特別感謝 [UniTask](https://github.com/Cysharp/UniTask) 的開發人員，提供如此優秀的工具。
