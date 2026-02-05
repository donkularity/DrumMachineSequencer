using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace DrumMachineSequencer
{
   public class CachedSoundSampleProvider : ISampleProvider // "Sample" = A single number that represents the amplitude of the sound at a specific point in time, each sound is a wave which is measured many times per second. Each measurement is a sample.
    {
        private readonly CachedSound cachedSound; //declares a variable called 'cachedSound' of the type CachedSound, made in CachedSound.cs
        private long position; //'long' means it is a 64 bit integer, as audio arrays can be very large. 'position' is a variable for the current position in the audio array (AudioData) (AudioData = wholeFile.ToArray();))

        public CachedSoundSampleProvider(CachedSound cachedSound) //initializes the provider with a specific cached sound, the provider is (CachedSound cachedSound)
        {
            this.cachedSound = cachedSound; //this assigns the constructor parameter ( = cachedSound) to the class variable (this.cachedSound). this links the provider to the specified cached audio
        }
        public WaveFormat WaveFormat => cachedSound.WaveFormat; //returns the waveformat of the cached sound, lets NAudio know how to interpret the audio samples

        public int Read(float[] buffer, int offset, int count) //fills buffers with audio data. 'float[] buffer' is what we fill, 'int offset' is where we start, 'int count' is where we finish
        { //this is the Read method body
            long availableSamples = cachedSound.AudioData.Length - position; //variable for how many samples remain, total number of samples in the cached sound SUBTRACT the already read samples
            int samplesToCopy = (int)Math.Min(availableSamples, count); //ensures we dont overflow the buffer or read past the end of the audio
            Array.Copy(cachedSound.AudioData, position, buffer, offset, samplesToCopy); // This is what moves the audio samples into NAudios playback buffer
            position += samplesToCopy; //Increments position by the number of samples just copied, which updates the read pointer so the next Read call continues correctly
            return samplesToCopy; //returns the number of samples actually written to the buffer
        }
    }
}
