using Microsoft.VisualBasic.Devices;
using NAudio.CoreAudioApi;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.IO;


namespace DrumMachineSequencer
{
    public partial class Form1 : Form
    {
        const int Rows = 3; // how many rows for the sequencer grid
        const int Steps = 16; // how many collums for the sequencer grid

        Button[,] grid = new Button[Rows, Steps]; // matrix of buttons, this is the sequencer grid, which is a 2 dimensional array
        int currentStep = 0; // start from the beginning :OOO
        bool isPlaying = false; // natural state
        
        System.Diagnostics.Stopwatch clock = new(); // high accuracy clock for timing steps
        double nextStepTime = 0; //stores when the next step should play in seconds

        AudioEngine audio = new(); // this is the Audio System Controller, which handles Loading Sounds, Mixing, Playing drum hits





        public Form1()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            currentStep = 0;
            isPlaying = true;
            clock.Restart();
            nextStepTime = 0;
        }

        private void lblBpm_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            isPlaying = false;
        }

        private void Form1_Load(object sender, EventArgs e) // Load audio, Build grid, Attach clicks, Store state, Start timing loop
        {
            audio.Init(); // audio = the AudioEngine object, Init() calls the method that sets up the mixer + output
            audio.LoadSound("hihat", "Samples/hihat.wav");
            audio.LoadSound("snare", "Samples/snare.wav");
            audio.LoadSound("kick", "Samples./kick.wav");
           
            

            gridPanel.ColumnCount = Steps; // creates the collums for the steps for the sequencer
            gridPanel.RowCount = Rows; // I can guess

            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Steps; c++)
                {
                    //creating the buttons 
                    var btn = new Button(); // creates a cell
                    btn.Dock = DockStyle.Fill; // each button fills the cell
                    btn.Tag = false; // stores whether the step is active
                    btn.BackColor = Color.DimGray; // Sets OFF button to DimGray

                    int rr = r, cc = c; // fuck knows mate "Captures loop values safely for lambda"

                    btn.Click += (s, e2) => //when this is clicked, give me info about what caused the click (this is the (s, e2) ), then do whats after this code (this is =>)
                    {
                        // Clicking steps on and off
                        btn.Tag = !(bool)btn.Tag; // turn step on and off, makes true = false, false = true
                        btn.BackColor = (bool)btn.Tag ? Color.Orange : Color.DimGray; // if the button is active (indicated by Tag ?) make the BackColor orange, if not make it grey
                    };

                    grid[r, c] = btn; // Used later during playback to check which steps are on
                    gridPanel.Controls.Add(btn, c, r); // places button into grid panel visually, makes sequencer interface
                }

            }

            System.Windows.Forms.Application.Idle += SequencerLoop; //runs sequencer continuously while app is idle. This is the playback engine loop
        }

        private void SequencerLoop(object sender, EventArgs e) //this method runs repeatedly while the app is idle as mentioned right above <<<^^^ (unless thats not the Application.Idle line anymore)
        { // This does this:  Check playing, Read BPM, Calculate step time, Check clock, Run step, Schedule next
            if (!isPlaying) return; // if the sequencer is stopped, do nothing lil bitch

            double bpm = (double)numBpm.Value; // whatever value the user has chosen for the BPM on the NumericUpDown control on the UI, set the bmp to DAT
            double stepLength = 60.0 / bpm / 4.0; // seconds per minute / divided by beats per minute / convert quarter notes to 16th notes by dividing again by 4. Controls how long one step lasts in seconds.

            double now = clock.Elapsed.TotalSeconds; // clock.Elapsed = time since clock started, TotalSeconds = convert to seconds. Gets the current playback time 

            if (now >= nextStepTime) //if its time to play the next step,,,,,,,,
            {
                RunStep(); // plays the current sequencer collumn
                nextStepTime += stepLength; // schedule the following step
            }
        }

        private void RunStep() //Check grid, Play sounds, Clear highlights, Highlight current column, Advance index, Loop around
        {
            for (int r = 0; r < Rows; r++) // loops through instruments
            {
                if ((bool)grid[r, currentStep].Tag) // check if this step is enabled
                {
                    if (r == 0) audio.Trigger("hihat"); // if row 0 for this step is active, play the sound associated, which is right now "kick"
                    if (r == 1) audio.Trigger("snare"); // ^^^
                    if (r == 2) audio.Trigger("kick"); // ^^^^^^

                }

            }

            for (int c = 0; c < Steps; c++)
                for (int r = 0; r < Rows; r++)
                    grid[r, c].FlatAppearance.BorderColor = Color.Black; // reset highlights to Black (shows which step its on)

            for (int r = 0; r < Rows; r++)
                grid[r, currentStep].FlatAppearance.BorderColor = Color.Lime; // highlight activated step in Lime

            currentStep++;
            if (currentStep >= Steps) currentStep = 0; //loop back to start when at end

        }
    }
}