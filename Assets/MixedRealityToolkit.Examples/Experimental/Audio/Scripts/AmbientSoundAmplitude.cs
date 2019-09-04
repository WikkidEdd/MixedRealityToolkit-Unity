﻿using Microsoft.MixedReality.Toolkit.Experimental.Audio;
using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using UnityEngine;
using UnityEngine.UI;

namespace Microsoft.MixedReality.Toolkit.Examples.Experimental
{
    [RequireComponent(typeof(AudioSource))]
    public class AmbientSoundAmplitude : MonoBehaviour
    {
        // todo: replace with spatial observer :)
        [SerializeField]
        [Tooltip("The text field in which to display the ambient sound amplitude.")]
        private Text amplitudeDisplay = null;

        private float averageAmplitude = 0.0f;

        private IMixedRealitySpatialAwarenessSystem spatialAwarenessSystem = null;
        private IMixedRealitySpatialAwarenessSystem SpatialAwarenessSystem
        {
            get
            {
                if (spatialAwarenessSystem == null)
                {
                    MixedRealityServiceRegistry.TryGetService<IMixedRealitySpatialAwarenessSystem>(out spatialAwarenessSystem);
                }
                return spatialAwarenessSystem;
            }
        }

        private IMixedRealitySpatialAwarenessMeshObserver spatialMeshObserver = null;
        private IMixedRealitySpatialAwarenessMeshObserver SpatialMeshObserver
        {
            get
            {
                if (spatialMeshObserver == null)
                {
                    spatialMeshObserver = (SpatialAwarenessSystem as IMixedRealityDataProviderAccess)?.GetDataProvider<IMixedRealitySpatialAwarenessMeshObserver>();
                }
                return spatialMeshObserver;
            }
        }

        private Material visibleMaterial = null;
        private Material VisibleMaterial
        {
            get
            {
                if (visibleMaterial == null)
                {
                    visibleMaterial = SpatialMeshObserver?.VisibleMaterial;
                }
                return visibleMaterial;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private WindowsMicrophoneStream micStream = null;

        private void Awake()
        {
            // We do not wish to play the ambient room sound from the audio source.
            gameObject.GetComponent<AudioSource>().volume = 0.0f;

            micStream = new WindowsMicrophoneStream();
            micStream.Gain = 1.0f;

            // Initialize the microphone stream.
            WindowsMicrophoneStreamErrorCode result = micStream.Initialize(WindowsMicrophoneStreamType.RoomCapture);
            if (result != WindowsMicrophoneStreamErrorCode.Success)
            {
                Debug.Log($"Failed to initialize the microphone stream. {result}");
            }

            // Start the microphone stream.
            // Do not keep the data and do not preview.
            result = micStream.StartStream(false, false);
            if (result != WindowsMicrophoneStreamErrorCode.Success)
            {
                Debug.Log($"Failed to start the microphone stream. {result}");
            }
        }

        private void OnDestroy()
        {
            // Stop the microphone stream.
            WindowsMicrophoneStreamErrorCode result = micStream.StopStream();
            if (result != WindowsMicrophoneStreamErrorCode.Success)
            {
                Debug.Log($"Failed to stop the microphone stream. {result}");
            }

            // Uninitialize the microphone stream.
            micStream.Uninitialize();
            micStream = null;
        }

        private void OnDisable()
        {
            // Pause the microphone stream.
            WindowsMicrophoneStreamErrorCode result = micStream.Pause();
            if (result != WindowsMicrophoneStreamErrorCode.Success)
            {
                Debug.Log($"Failed to pause the microphone stream. {result}");
            }
        }

        private void OnEnable()
        {
            // Resume the microphone stream.
            WindowsMicrophoneStreamErrorCode result = micStream.Resume();
            if (result != WindowsMicrophoneStreamErrorCode.Success)
            {
                Debug.Log($"Failed to resume the microphone stream. {result}");
            }
        }

        private void Update()
        {
            amplitudeDisplay.text = averageAmplitude.ToString("N4");

            if (VisibleMaterial != null)
            {
                // todo: this modifies the shader in the editor.... consider a different approach (ex: make a copy in the observer)
                VisibleMaterial.SetColor("_WireColor", Color.blue);

                int wireThickness = (int)(averageAmplitude * 10 * 700);
                wireThickness = Mathf.Clamp(wireThickness, 0, 700);
                VisibleMaterial.SetInt("_WireThickness", wireThickness);
            }
        }

        private void OnAudioFilterRead(float[] buffer, int numChannels)
        {
            // Read the microphone stream data.
            WindowsMicrophoneStreamErrorCode result = micStream.ReadAudioFrame(buffer, numChannels);
            if (result != WindowsMicrophoneStreamErrorCode.Success)
            {
                Debug.Log($"Failed to read the microphone stream data. {result}");
            }

            float sumOfValues = 0;

            // Calculate this frame's average amplitude.
            for (int i = 0; i < buffer.Length; i++)
            {
                if (float.IsNaN(buffer[i]))
                {
                    buffer[i] = 0;
                }

                buffer[i] = Mathf.Clamp(buffer[i], -1.0f, 1.0f);
                sumOfValues += Mathf.Clamp01(Mathf.Abs(buffer[i]));
            }

            averageAmplitude = sumOfValues / buffer.Length;
        }
    }
}