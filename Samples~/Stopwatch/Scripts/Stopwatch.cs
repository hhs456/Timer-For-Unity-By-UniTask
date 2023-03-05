using System;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

namespace ToolKid {
    public class Stopwatch : MonoBehaviour {
        [SerializeField] private Text timerText; // ��ܭp�ɾ��ɶ���UI Text
        [SerializeField] private float duration = 60f; // �p�ɾ��ɶ�
        [SerializeField] private bool isCountdown = true; // �O�_���˼ƭp��
        [SerializeField] private bool hasEndTime = true; // �O�_�������ɶ�
        [SerializeField] private bool destroyOnComplete = true; // �p�ɧ�����O�_�ۦ�P��
        private Timer timer;

        private void Start() {
            // �]�w�p�ɾ��ɶ�
            SetTimer(duration, hasEndTime);
            if (!timerText) return;
        }

        // �]�w�p�ɾ��ɶ�
        public void SetTimer(float duration, bool isCountdown = true) {
            if (isCountdown) {
                timer = new Timer(duration);
            }
            else {
                timer = new Timer(float.PositiveInfinity);
            }
            UpdateTimeUI();
            // �]�w Tick �ƥ�
            timer.OnTimerTick += () => {
                // ��s��ܮɶ�
                UpdateTimeUI();
                return UniTask.CompletedTask;
            };

            // �]�w Complete �ƥ�
            timer.OnTimerComplete += () => {
                // ��s��ܮɶ�
                UpdateTimeUI();
                if (destroyOnComplete) {
                    Destroy(gameObject);
                }

                return UniTask.CompletedTask;
            };
        }

        // ��s��ܮɶ�
        private void UpdateTimeUI() {
            if (timerText == null) return;

            // ���o�p�ɾ��ɶ�
            float time = timer.IsRunning ? timer.CurrentTime : timer.Duration;
            // �M�w�O�_��ܬ��˼ƪ��ɶ�
            time = isCountdown ? timer.Duration - timer.CurrentTime : time;

            // �ഫ���ɶ��榡
            TimeSpan timeSpan = TimeSpan.FromSeconds(time);

            // ��s UI ��r            
            timerText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        }

        // �}�l�p�ɾ�
        public void StartTimer() {
            if (timer == null) return;
            timer.Start();
        }

        // ����p�ɾ�
        public void StopTimer() {
            if (timer == null) return;
            timer.Stop();
        }

        // �P������ɡA����p�ɾ�
        private void OnDestroy() {
            StopTimer();
        }
    }
}