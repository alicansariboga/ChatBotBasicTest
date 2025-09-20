using NAudio.Wave;
using System.IO;
using Vosk;

namespace WinFormsApp1
{
    using System;
    using System.IO;
    using NAudio.Wave;
    using Vosk;

    public class SpeechToText
    {
        private VoskRecognizer _rec;
        private string _transcribedText = string.Empty;
        private WaveInEvent _waveIn;
        private bool _isListening = false;
        private string assistantName = "asistan";

        private readonly Action<string> _onWakeWordDetected;

        public SpeechToText(Action<string> onWakeWordDetected)
        {
            _onWakeWordDetected = onWakeWordDetected;
        }

        public string InitializeVosk()
        {
            Vosk.SetLogLevel(0);
            string modelPath = "C:\\vosk-model-small-tr-0.3";

            if (!Directory.Exists(modelPath))
            {
                throw new Exception($"Model directory '{modelPath}' does not exist.");
            }

            var model = new Model(modelPath);
            _rec = new VoskRecognizer(model, 16000.0f);

            _waveIn = new WaveInEvent();
            _waveIn.DeviceNumber = 0;
            _waveIn.WaveFormat = new WaveFormat(16000, 1);
            _waveIn.BufferMilliseconds = 1000;

            _waveIn.DataAvailable += (s, a) =>
            {
                ProcessAudioData(a.Buffer, a.BytesRecorded);
            };

            return "Vosk initialized successfully. Ready to listen.";
        }

        private void ProcessAudioData(byte[] buffer, int bytesRecorded)
        {
            if (_rec.AcceptWaveform(buffer, bytesRecorded))
            {
                _transcribedText = _rec.Result();
            }
            else
            {
                _transcribedText = _rec.PartialResult();
            }

            if (_transcribedText.Contains(assistantName))
            {
                HandleBotActivation();
            }
        }

        public string GetTranscribedText()
        {
            return _transcribedText;
        }

        public void StartRecording()
        {
            if (_waveIn != null && !_isListening)
            {
                _isListening = true;
                _waveIn.StartRecording();
                Console.WriteLine("Recording started...");
            }
        }

        public void StopRecording()
        {
            if (_waveIn != null && _isListening)
            {
                _isListening = false;
                _waveIn.StopRecording();
                Console.WriteLine("Recording stopped.");
            }
        }

        private void HandleBotActivation()
        {
            StopRecording();

            string response = "evet sizi dinliyorum";

            _onWakeWordDetected?.Invoke(response);

            StartRecording();
        }
    }
}
