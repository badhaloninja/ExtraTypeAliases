using FrooxEngine;
using HarmonyLib;
using NeosModLoader;
using System;
using BaseX;
using System.Collections.Generic;

namespace ExtraTypeAliases
{
    public class ExtraTypeAliases : NeosMod
    {
        public override string Name => "ExtraTypeAliases";
        public override string Author => "badhaloninja";
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/badhaloninja/ExtraTypeAliases";
        public override void OnEngineInit()
        {
            addNewTypeAliases();
        }

        private void addNewTypeAliases()
        {
            /* Normal AliasTable also overwrites the generated name of the type
             * BiDictionary<string, Type> aliasTable = Traverse.Create(typeof(TypeHelper)).Field("aliasTable").GetValue<BiDictionary<string, Type>>();
             * aliasTable.ContainsSecond
             */
            Dictionary<string, Type> extraAliases = Traverse.Create(typeof(TypeHelper)).Field("extraAliases").GetValue<Dictionary<string, Type>>();
            
            foreach (var item in newAliases)
            {
                if (extraAliases.ContainsKey(item.Key)) continue;
                extraAliases.Add(item.Key, item.Value);
            }
        }

        Dictionary<string, Type> newAliases = new Dictionary<string, Type>()
        {
            { "Texture2D Provider", typeof(IAssetProvider<Texture2D>) },
            { "Texture3D Provider", typeof(IAssetProvider<Texture3D>) },
            { "ITexture2D Provider", typeof(IAssetProvider<ITexture2D>) },
            { "Video Provider", typeof(IAssetProvider<VideoTexture>) },
            { "VideoTexture Provider", typeof(IAssetProvider<VideoTexture>) },
            { "Mesh Provider", typeof(IAssetProvider<Mesh>) },
            { "Material Provider", typeof(IAssetProvider<Material>) },
            { "AudioClip Provider", typeof(IAssetProvider<AudioClip>) },
            { "Animation Provider", typeof(IAssetProvider<Animation>) },
        };
    }
}