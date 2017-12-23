using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Defender.Classes
{
    public static class Sounds
    {
        private static SoundPlayer player = new SoundPlayer();
        public enum SoundTypes
        {
            Start, SavePeople, Materialize, Die
        }
        public static void Play(SoundTypes sound)
        {
            switch (sound)
            {
                case SoundTypes.Start: {
                        player.SoundLocation = @"..\..\Sounds\def_star.wav";
                        player.Play();
                        break; }
            }
        }
    }
}
