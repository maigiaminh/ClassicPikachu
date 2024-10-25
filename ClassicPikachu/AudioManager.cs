using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicPikachu
{
    public class AudioManager
    {
        public IWavePlayer backgroundPlayer;
        public AudioFileReader backgroundMusic;
        public List<IWavePlayer> soundEffectPlayers = new List<IWavePlayer>();
        public List<AudioFileReader> soundEffectMusic = new List<AudioFileReader>();
        public Dictionary<string, string> soundEffects;
        private bool isBackgroundMuted = false;
        private bool areSoundEffectsMuted = false;


        public AudioManager()
        {
            soundEffects = new Dictionary<string, string>()
            {
                { "click", @"Resources\click.mp3" },
            };
            LoadSoundEffect();
        }

        private void LoadSoundEffect(){
            for(int i = 0; i < soundEffects.Count(); i++)
            {
                soundEffectMusic.Add(new AudioFileReader(soundEffects.ElementAt(i).Value) { Volume = 1 });
            }
        }

        public void StartBackgroundMusic(float volume = 0.5f)
        {
            backgroundPlayer = new WaveOutEvent();
            backgroundMusic = new AudioFileReader(@"Resources\bg.mp3") { Volume = isBackgroundMuted ? 0 : volume };

            backgroundPlayer.Init(backgroundMusic);
            backgroundPlayer.Play();
            backgroundPlayer.PlaybackStopped += (s, e) =>
            {
                if (backgroundPlayer == null) return;
                backgroundPlayer?.Play();
            };
        }

        public void PlaySoundEffect(string effectName, float volume = 1.0f)
        {
            if (!soundEffects.ContainsKey(effectName))
            {
                Debug.WriteLine($"Sound effect {effectName} not found!");
                return;
            }

            var soundPlayer = new WaveOutEvent();
            var soundFile = new AudioFileReader(soundEffects[effectName]) { Volume = areSoundEffectsMuted ? 0 : volume };
            soundPlayer.Init(soundFile);
            soundEffectPlayers.Add(soundPlayer); 
            soundPlayer.Play();

            soundPlayer.PlaybackStopped += (s, e) =>
            {
                soundFile.Dispose();
                soundPlayer.Dispose();
                soundEffectPlayers.Remove(soundPlayer);
            };
        }


        public void MuteBackgroundMusic(bool mute)
        {
            isBackgroundMuted = mute;
            if (backgroundMusic != null)
            {
                backgroundMusic.Volume = mute ? 0 : 0.5f;
            }
        }

        public void MuteSoundEffects(bool mute)
        {
            areSoundEffectsMuted = mute;
            foreach (var reader in soundEffectMusic)
            {
                
                reader.Volume = mute ? 0 : 1.0f; 
            }
        }
    }
}
