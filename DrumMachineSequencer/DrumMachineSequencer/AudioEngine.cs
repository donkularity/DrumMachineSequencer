using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace DrumMachineSequencer
{
   public class AudioEngine
    {
        public MixingSampleProvider Mixer { get; private set; } //This is the mixer which allows multiple sounds to be played at once
        private WaveOutEvent output; // this allows the audio to play without the program freezing for each sound
        private Dictionary<string, CachedSound> sounds = new(); // creates a collection called 'sounds' of CachedSound objects. Stores all preloaded drum samples so they can be triggered instantly by name.

        public void Init() //sets up the mixer and the output
        {
            Mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 2))
            {
                ReadFully = true //if a source runs out of samples, the mixer returns zero instead of stopping
            };

            output = new WaveOutEvent(); // Creates a new audio output object that plays the audio stream asynchronously
            output.Init(Mixer); //connects mixer to audio output, tells NAudio: "this is the audio i want u to play"
            output.Play(); //starts audio output
        }
        public void LoadSound(string name, string path) // loads and caches drum samples before they are played
        {
            sounds[name] = new CachedSound(path); //loads audio file into memory (RAM)
        }
        public void Trigger(string name) //called by the sequencer to play a drum hit
        {
            if (!sounds.ContainsKey(name)) return; //prevents from crashing if u try to play a sound that hasnt been loaded, skips.
            Mixer.AddMixerInput(new CachedSoundSampleProvider(sounds[name])); // THIS produces sound when a drum is triggered. Plays drum hit by mixing into the active audio stream. 
        }
    }
}
