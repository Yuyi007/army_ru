using System;
using UnityEngine;
using SLua;
using System.Collections;
using System.Collections.Generic;
using LBoot;

namespace LBoot
{
    [System.Serializable]
    [SLua.CustomLuaClass]
    public class SpriteAsset : ScriptableObject, ISerializationCallbackReceiver
    {
        [NonSerialized]
        public Material material;


        [SLua.DoNotToLua]
        public string[] _keys;

        [SLua.DoNotToLua]
        public Sprite[] _values;

        [SLua.DoNotToLua]
        public Dictionary<string, Sprite> _sprites = null;


        [SLua.DoNotToLua]
        public static SpriteAsset Create()
        {
            return ScriptableObject.CreateInstance<SpriteAsset>();
        }

        [SLua.DoNotToLua]
        public void Fill(Sprite[] sprites, Texture mainTexture = null, Texture maskTexture = null)
        {
            _values = sprites;
            _keys = new string[_values.Length];

            for (var i = 0; i < _values.Length; i++)
            {
                _keys[i] = _values[i].name;
            }


            this.material = null;
        }

        [SLua.DoNotToLua]
        public void Dump()
        {
            foreach (var pair in _sprites)
            {
                LogUtil.Debug(pair.Key);
                LogUtil.Debug(pair.Value.name);
            }
        }

        [SLua.DoNotToLua]
        public void OnBeforeSerialize()
        {

        }

        [SLua.DoNotToLua]
        public void OnAfterDeserialize()
        {
            if (_sprites != null)
            {
                _sprites.Clear();
            }
            else
            {
                _sprites = new Dictionary<string,Sprite>();
            }

            for (int i = 0; i != Math.Min(_keys.Length, _values.Length); i++)
            {
                var sprite = _values[i];
                if (sprite != null)
                    _sprites.Add(_keys[i], _values[i]);
            }

        }

        public Sprite GetSprite(string name)
        {
            Sprite sprite;
            _sprites.TryGetValue(name, out sprite);
            return sprite;
        }

        public Material GetMaterial()
        {
            if (material != null)
                return material;

            return null;
        }

        void OnDestroy()
        {
            Unload();
        }

        public void Unload()
        {
            if(_values != null && _values.Length > 0)
            {
                var texture = _values[0].texture;
                Resources.UnloadAsset(texture);
            }

            if (_sprites != null)
                _sprites.Clear();

            _sprites = null;
            _keys = null;
            _values = null;
            material = null;
        }

    }
}

