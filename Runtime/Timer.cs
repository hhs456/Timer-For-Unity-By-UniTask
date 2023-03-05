using System;
using System.Threading;
using Cysharp.Threading.Tasks; // �ޤJUniTask�R�W�Ŷ�
using UnityEngine;

namespace ToolKid {
    public class Timer {
        // �O���ثe�w�g�g�L���ɶ�
        private float currentTime;
        // �p�ɾ����`�ɶ�
        private float duration;
        // �p�ɾ��O�_���b�B��
        private bool isRunning;
        // �p�ɾ��O�_���˼ƭp�ɾ�
        private bool isCountdown;
        // ����Token��Source
        private CancellationTokenSource cts;

        public Timer(float duration) {
            this.Duration = duration;
            IsRunning = false;
            // ��l�� CancellationTokenSource
            cts = new CancellationTokenSource();
        }

        public float CurrentTime { get => currentTime; set => currentTime = value; }
        public float Duration { get => duration; set => duration = value; }
        public bool IsRunning { get => isRunning; set => isRunning = value; }
        public bool IsCountdown { get => isCountdown; set => isCountdown = value; }

        // �p�ɾ���Tick�ƥ�
        public event Func<UniTask> OnTimerTick;
        // �p�ɾ������ƥ�
        public event Func<UniTask> OnTimerComplete;

        // �}�l�p�ɾ�
        public void Start() {
            if (IsRunning) return;
            IsRunning = true;
            CurrentTime = 0f;
            // �}�l����p�ɾ����j��
            _ = TimerLoop();
        }

        // ����p�ɾ�
        public void Stop() {
            if (!IsRunning) return;
            IsRunning = false;
            // �����j�餤�� await UniTask.Delay()�A���_�j��
            cts.Cancel();
        }

        // �p�ɾ��j��
        private async UniTask TimerLoop() {
            while (CurrentTime < Duration && IsRunning) {
                // ���� 0.1 ��
                await UniTask.Delay(TimeSpan.FromSeconds(0.1f), cancellationToken: cts.Token);
                // ��s�ثe�w�g�g�L���ɶ�
                CurrentTime += 0.1f;
                // �p�G�����U Tick �ƥ�A�I�s�ƥ�
                if (OnTimerTick != null) await OnTimerTick.Invoke();
            }

            // �p�G�p�ɾ��O���b�B�椤�A�åB�����U Complete �ƥ�A�I�s�ƥ�
            if (IsRunning && OnTimerComplete != null) await OnTimerComplete.Invoke();

            // �p�ɾ��B�浲��
            IsRunning = false;
        }
    }
}
