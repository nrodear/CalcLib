using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CalcLib.Types;

namespace CalcLib.Engine
{
    public sealed class Values
    {
        private static readonly Values _instance = new();

        public event Action ValueChanged;

        private Item lastItem;

        private readonly Stack<Item> _stack = new Stack<Item>();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Values()
        {
        }

        private Values()
        {
        }

        public static Values Instance
        {
            get { return _instance; }
        }

        public static void Add(Item item)
        {
            if (item.GetType() == typeof(ItemValue))
            {
                // value, value as item (5 & 5 = 55)
                if (_instance.lastItem != null
                    && _instance.lastItem.GetType() == typeof(ItemValue))
                {
                    var itemLast = ((ItemValue)_instance.lastItem);
                    var itemValue = ((ItemValue)item);
                    ((ItemValue)_instance.lastItem).Value = GetParsedValue(itemLast, itemValue);
                    _instance.ValueChanged?.Invoke();
                    return;
                }
            }

            if (item.GetType() == typeof(ItemMethod))
            {
                if (_instance._stack.Count == 0)
                {
                    return;
                }

                var method = (ItemMethod)item;
                if (method.LevelType == LevelType.None)
                {
                    method.Method.Invoke(new float[] { });
                    return;
                }

                if (method.LevelType == LevelType.Instant)
                {
                    var lastItem = (ItemValue)_instance.lastItem;
                    lastItem.Value = method.Method.Invoke(new[] { lastItem.Value });
                    _instance.ValueChanged?.Invoke();
                    return;
                }
            }

            Push(item);

            _instance.AutoProcessItems();
        }

        private static void Push(Item? item)
        {
            if (item == null)
            {
                return;
            }

            var newInstance = item.Copy();
            _instance.lastItem = newInstance;
            _instance._stack.Push(newInstance);
            _instance.ValueChanged?.Invoke();
        }

        public static void Clear()
        {
            _instance._stack.Clear();
            _instance.lastItem = null;
        }


        private static float GetParsedValue(ItemValue valueA, ItemValue value)
        {
            string concatValue = valueA.Value + value.Value.ToString(CultureInfo.InvariantCulture);
            var parsedValue = float.Parse(concatValue, CultureInfo.InvariantCulture.NumberFormat);
            return parsedValue;
        }

        public static bool TryGetValue(out float value)
        {
            foreach (var item in _instance._stack)
            {
                if (item.GetType() == typeof(ItemValue))
                {
                    value = ((ItemValue)item).Value;
                    return true;
                }
            }

            Clear();
            value = default(float);
            return true;
        }

        public static float Process()
        {
            var result = _instance.ProcessItems();
            _instance.ValueChanged?.Invoke();
            return result;
        }

        public float AutoProcessItems()
        {
            if (_instance._stack.Count >= 4)
            {
                return ProcessItems();
            }

            return 0;
        }

        public float ProcessItems()
        {
            bool hasValueA = false;
            bool hasMethod1 = false;
            bool hasMethod2 = false;

            ItemMethod methodItem;
            ItemMethod method1Item = null;
            ItemMethod method2Item = null;

            float valueA = 0;
            float valueB = 0;
            float result;

            ItemMethod rememberItemMethod = null;

            // LevelType.None == instanced exe on add
            // LevelType.One       

            foreach (var item in _stack.Reverse())
            {
                if (item.GetType() == typeof(ItemValue) && !hasValueA)
                {
                    hasValueA = true;
                    valueA = ((ItemValue)item).Value;
                    continue;
                }

                if (item.GetType() == typeof(ItemValue) && hasValueA)
                {
                    valueB = ((ItemValue)item).Value;
                    continue;
                }

                if (item.GetType() == typeof(ItemMethod) && !hasMethod1)
                {
                    methodItem = ((ItemMethod)item);
                    if (methodItem.LevelType == LevelType.Two)
                    {
                        method1Item = (ItemMethod)item;
                        hasMethod1 = true;
                        continue;
                    }

                    // makes no sense 
                    throw new Exception("LevelType.One method here, missing values tho.");
                }

                if (item.GetType() == typeof(ItemMethod) && hasMethod1 && !hasMethod2)
                {
                    methodItem = ((ItemMethod)item);
                    if (methodItem.LevelType == LevelType.Two)
                    {
                        rememberItemMethod = methodItem;
                        continue;
                    }

                    method2Item = ((ItemMethod)item);
                    hasMethod2 = true;
                    if (method2Item.ArgType != ArgsType.Two)
                    {
                        throw new Exception(" ArgsType.One not expected");
                    }
                }
            }

            result = valueA;

            if (hasMethod2)
            {
                valueB = method2Item.Method.Invoke(new[] { valueA, valueB });
            }

            if (hasMethod1)
            {
                result = method1Item.Method.Invoke(new[] { valueA, valueB });
            }

            var resultItem = new ItemValue("=>", result);
            Clear();
            Push(resultItem);

            Push(rememberItemMethod);


            return result;
        }
    }
}