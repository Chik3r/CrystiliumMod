using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;

namespace CrystiliumMod.Sounds
{
	public class Thunder : ModSoundStyle
	{
		// TODO: Mystery magic, check if it works
		public override SoundEffectInstance Play(Vector2? position)
		{
			var instance = base.Play(position);
			if (position.HasValue)
			{
				CalculateVolumeAndPan(position.Value, 800, out float volumeScale, out float pan);
				instance.Volume = volumeScale * .5f;
				instance.Pan = pan;
				instance.Pitch = Main.rand.Next(-6, 7) / 30f;
			}

			return base.Play(position);
		}

		//public override SoundEffectInstance PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType type)
		//{
		//	soundInstance = sound.CreateInstance();
		//	soundInstance.Volume = volume * .5f;
		//	soundInstance.Pan = pan;
		//	soundInstance.Pitch = Main.rand.Next(-6, 7) / 30f;
		//	return soundInstance;
		//}

		public Thunder(string soundPath, int variations = 0, SoundType type = SoundType.Sound, float volume = 1, float pitch = 0, float pitchVariance = 0) : base(soundPath, variations, type, volume, pitch, pitchVariance)
		{
		}

		public Thunder(string modName, string soundPath, int variations = 0, SoundType type = SoundType.Sound, float volume = 1, float pitch = 0, float pitchVariance = 0) : base(modName, soundPath, variations, type, volume, pitch, pitchVariance)
		{
		}
	}
}