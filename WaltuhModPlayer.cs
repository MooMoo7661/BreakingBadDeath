using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace BreakingBadDeath
{
    public class WaltuhModPlayer : ModPlayer
    {
        public int walterDeathTimer = 12600; //12600
        public override void UpdateDead()
        {

            Main.GameZoomTarget -= 0.0002f;
            if (Player.difficulty == PlayerDifficultyID.Hardcore)
                if (walterDeathTimer >= 0)
                {
                    walterDeathTimer--;
                    Player.respawnTimer = 60;
                }
        }
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            walterDeathTimer = 12600;
            return true;
        }
    }

    public class BabyBlue : ModSceneEffect
    {
        public override bool IsSceneEffectActive(Player player)
        {
            return player.dead;
        }
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/BabyBlue");
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;
        public override float GetWeight(Player player)
        {
            return 2;
        }
    }
}