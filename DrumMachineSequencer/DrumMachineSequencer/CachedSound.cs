using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace DrumMachineSequencer
{
    public class CachedSound // Stores audio in memory for fast playback
    {
        public float[] AudioData { get; } 
        public WaveFormat WaveFormat { get;} //property of the class which tells you the format of the audio stored in the object ("kick.WaveFormat")

        public CachedSound(string filename) //public constructor expecting a string containing the path to the audiofile
        {
            using var reader = new AudioFileReader(filename); //Disposing when done ('using'), creates new AFR object that opens 'filename' & converts audio to float samples
            WaveFormat = reader.WaveFormat; //stores the readers wave format into the object, telling the sound how it should be played (file's sample rate, number of channels, and bit depth)

            var wholeFile = new List<float>(); //var called 'wholefile' which stores a growing list of all the audio samples read so far
            var buffer = new float[reader.WaveFormat.SampleRate * reader.WaveFormat.Channels]; //when a variable is made of this type, it will create a temporary array of floats. new float[...] this determines the size of the buffer. Here, it allocates enough space for one second of audio as a buffer
            int samplesRead; //this variable will store how many samples were actually read in each loop iteration

            while ((samplesRead = reader.Read(buffer, 0, buffer.Length)) > 0) //until there are no more samples to read, keep reading floats (audio converted to samples) from the file until there are no more, store the number of samples actually read in 'samplesRead'
                wholeFile.AddRange(buffer.AsSpan(0, samplesRead).ToArray()); //adds each valid sample in the buffer to the wholeFile list, by creating a span (view) of the samples in the buffer, and converting the span to an array (".ToArray") 
            
            AudioData = wholeFile.ToArray(); //converts list of floats to an array, and assigns it to the AudioData propertyz
        }

    }
}
