using Microsoft.Xna.Framework.Audio;
using OggSharp;
using System.IO;
using System.Linq;

namespace Ogg2XNA
{
    public static class OggLoader
    {
        public static SoundEffect Load(string path)
        {
            SoundEffect soundEffect;

            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                OggDecoder decoder = new OggDecoder();
                decoder.Initialize(File.OpenRead(path));
                byte[] data = decoder.SelectMany(chunk => chunk.Bytes.Take(chunk.Length)).ToArray();
                WriteWave(writer, decoder.Stereo ? 2 : 1, decoder.SampleRate, data);
                stream.Position = 0;
                soundEffect = SoundEffect.FromStream(stream);
            }

            return soundEffect;
        }

        private static void WriteWave(BinaryWriter writer, int channels, int rate, byte[] data)
        {
            writer.Write(new char[4] { 'R', 'I', 'F', 'F' });
            writer.Write((36 + data.Length));
            writer.Write(new char[4] { 'W', 'A', 'V', 'E' });
            writer.Write(new char[4] { 'f', 'm', 't', ' ' });
            writer.Write(16);
            writer.Write((short)1);
            writer.Write((short)channels);
            writer.Write(rate);
            writer.Write((rate * ((16 * channels) / 8)));
            writer.Write((short)((16 * channels) / 8));
            writer.Write((short)16);
            writer.Write(new char[4] { 'd', 'a', 't', 'a' });
            writer.Write(data.Length);
            writer.Write(data);
        }
    }
}
