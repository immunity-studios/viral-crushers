using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Game.Views
{
    public partial class VolumeSlidersControl : ContentView
    {
        public VolumeSlidersControl()
        {
            InitializeComponent();
        }

        #region Click Handlers

        /// <summary>
        /// Volume slider for music which controls the audio engine
        /// TODO create a number label which shows the current value of slider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnMusicVolumeSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            // get slider value
            double value = args.NewValue;
            // Set volume of global audio engine with value of slider 
            AudioSystem.AudioEngine.Instance.SetBusVolume(AudioSystem.AudioBusEnum.Music, value);
        }

        /// <summary>
        /// Volume slider for sound effects (SFX) which controls the audio engine
        /// TODO create a number label which shows the current value of slider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnSFXVolumeSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            // get slider value
            double value = args.NewValue;
            // Set volume of global audio engine with value of slider 
            AudioSystem.AudioEngine.Instance.SetBusVolume(AudioSystem.AudioBusEnum.SFX, value);
        }

        bool SetVolumeSliderLevelsToAudioEngineBusLevels()
        {
            musicVolume.Value = AudioSystem.AudioEngine.Instance.GetBusVolume(AudioSystem.AudioBusEnum.Music);
            sfxVolume.Value = AudioSystem.AudioEngine.Instance.GetBusVolume(AudioSystem.AudioBusEnum.SFX);
            return true;
        }
        #endregion
    }
}
