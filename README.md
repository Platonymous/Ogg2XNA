# Ogg2XNA
Loads Ogg Files as XNA SoundEffect

### Package
https://www.nuget.org/packages/Platonymous.Ogg2XNA/

### Incorporates
https://archive.codeplex.com/?p=oggsharp

https://gamedev.stackexchange.com/questions/20772/loading-sound-in-xna-without-the-content-pipeline/42090#42090

### Usage
```sh
using Microsoft.Xna.Framework.Audio;
using Ogg2XNA;

SoundEffect s = OggLoader.Load(PATH_TO_FILE);
```
