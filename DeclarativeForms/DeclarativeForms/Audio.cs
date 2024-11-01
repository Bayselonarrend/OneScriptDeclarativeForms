﻿using ScriptEngine.HostedScript.Library.Binary;
using ScriptEngine.HostedScript.Library;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System;

namespace osdf
{
    [ContextClass("ДфАудио", "DfAudio")]
    public class DfAudio : AutoContext<DfAudio>
    {

        public DfAudio()
        {
            ItemKey = "d" + Path.GetRandomFileName().Replace(".", "");
            string strFunc = "mapKeyEl.set('" + ItemKey + "', document.createElement('audio'));" + @"
mapElKey.set(mapKeyEl.get('" + ItemKey + "'), '" + ItemKey + "');";
            DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
            DeclarativeForms.AddToHashtable(ItemKey, this);
            style = new DfStyle();
            style.Owner = this;
		
            offsetTop = ValueFactory.Create(0);
            offsetHeight = ValueFactory.Create(0);
            offsetLeft = ValueFactory.Create(0);
            offsetWidth = ValueFactory.Create(0);
        }

        public PropertyInfo this[string p1]
        {
            get { return this.GetType().GetProperty(p1); }
        }

        private bool muted;
        [ContextProperty("Беззвучно", "Muted")]
        public bool Muted
        {
            get { return muted; }
            set
            {
                muted = value;
                string strFunc = "mapKeyEl.get('" + ItemKey + "')['muted'] = " + muted.ToString().ToLower() + ";";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
            }
        }

        private decimal volume;
        [ContextProperty("Громкость", "Volume")]
        public decimal Volume
        {
            get { return volume; }
            set
            {
                volume = value;
                string res = volume.ToString().Replace(",", ".");
                string strFunc = "mapKeyEl.get('" + ItemKey + "')['volume'] = '" + res + "';";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
            }
        }

        private int duration;
        [ContextProperty("Длительность", "Duration")]
        public int Duration
        {
            get { return duration; }
            set
            {
                duration = value;
                string strFunc = "mapKeyEl.get('" + ItemKey + "')['duration'] = '" + duration + "';";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
            }
        }

        private bool ended;
        [ContextProperty("Завершено", "Ended")]
        public bool Ended
        {
            get { return ended; }
            set
            {
                ended = value;
                string strFunc = "mapKeyEl.get('" + ItemKey + "')['ended'] = " + ended.ToString().ToLower() + ";";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
            }
        }

        private string id;
        [ContextProperty("Идентификатор", "Id")]
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                string strFunc = "mapKeyEl.get('" + ItemKey + "')['id'] = '" + id + "';";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
            }
        }

        private string name;
        [ContextProperty("Имя", "Name")]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                string strFunc = "mapKeyEl.get('" + ItemKey + "')['name'] = '" + name + "';";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
            }
        }

        private string src;
        [ContextProperty("Источник", "Src")]
        public string Src
        {
            get { return src; }
            set
            {
                src = value;
                string strFunc = "mapKeyEl.get('" + ItemKey + "')['src'] = '" + src + "';";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
            }
        }

        private string accessKey;
        [ContextProperty("КлавишаДоступа", "AccessKey")]
        public string AccessKey
        {
            get { return accessKey; }
            set
            {
                accessKey = value;
                string strFunc = "mapKeyEl.get('" + ItemKey + "')['accessKey'] = '" + accessKey + "';";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
            }
        }

        private string _class;
        [ContextProperty("Класс", "Class")]
        public string Class
        {
            get { return _class; }
            set
            {
                _class = value;
                string strFunc = "mapKeyEl.get('" + ItemKey + "')['className'] = '" + _class + "';";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
            }
        }

        private string itemKey;
        [ContextProperty("КлючЭлемента", "ItemKey")]
        public string ItemKey
        {
            get { return itemKey; }
            private set { itemKey = value; }
        }

        private bool controls;
        [ContextProperty("Контролы", "Controls")]
        public bool Controls
        {
            get { return controls; }
            set
            {
                controls = value;
                string strFunc = "mapKeyEl.get('" + ItemKey + "')['controls'] = " + controls.ToString().ToLower() + ";";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
            }
        }

        private bool paused;
        [ContextProperty("НаПаузе", "Paused")]
        public bool Paused
        {
            get { return paused; }
            set
            {
                paused = value;
                string strFunc = "mapKeyEl.get('" + ItemKey + "')['paused'] = " + paused.ToString().ToLower() + ";";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
            }
        }

        private bool loop;
        [ContextProperty("Повтор", "Loop")]
        public bool Loop
        {
            get { return loop; }
            set
            {
                loop = value;
                string strFunc = "mapKeyEl.get('" + ItemKey + "')['loop'] = " + loop.ToString().ToLower() + ";";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
            }
        }

        private int tabIndex;
        [ContextProperty("ПорядокОбхода", "TabIndex")]
        public int TabIndex
        {
            get { return tabIndex; }
            set
            {
                tabIndex = value;
                string strFunc = "mapKeyEl.get('" + ItemKey + "')['tabIndex'] = '" + tabIndex + "';";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
            }
        }

        private bool contentEditable;
        [ContextProperty("Редактируемый", "ContentEditable")]
        public bool ContentEditable
        {
            get { return contentEditable; }
            set
            {
                contentEditable = value;
                string strFunc = "mapKeyEl.get('" + ItemKey + "')['contentEditable'] = " + contentEditable.ToString().ToLower() + ";";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
            }
        }

        private IValue parent;
        [ContextProperty("Родитель", "Parent")]
        public IValue Parent
        {
            get { return parent; }
            set
            {
                parent = value;
                string strFunc;
                if (parent.AsObject().GetPropValue("ItemKey").AsString() == "mainForm")
                {
                    strFunc = "document.body.appendChild(mapKeyEl.get('" + ItemKey + "'));";
                }
                else
                {
                    strFunc = "mapKeyEl.get('" + parent.AsObject().GetPropValue("ItemKey").AsString() + "').appendChild(mapKeyEl.get('" + ItemKey + "'));";
                }
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
                // Родителю добавим потомка.
                ArrayImpl ArrayImpl1 = ((dynamic)parent).Children;
                ArrayImpl1.Add(this);
            }
        }

        private IValue playbackRate;
        [ContextProperty("Скорость", "PlaybackRate")]
        public IValue PlaybackRate
        {
            get { return playbackRate; }
            set
            {
                playbackRate = value;
                string res = playbackRate.AsNumber().ToString().Replace(",", ".");
                string strFunc = "mapKeyEl.get('" + ItemKey + "')['playbackRate'] = '" + res + "';";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
            }
        }

        public IValue offsetTop { get; set; }
        [ContextProperty("СмещениеВерх", "OffsetTop")]
        public int OffsetTop
        {
            get { return Convert.ToInt32(offsetTop.AsNumber()); }
        }

        public IValue offsetHeight { get; set; }
        [ContextProperty("СмещениеВысота", "OffsetHeight")]
        public int OffsetHeight
        {
            get { return Convert.ToInt32(offsetHeight.AsNumber()); }
        }

        public IValue offsetLeft { get; set; }
        [ContextProperty("СмещениеЛево", "OffsetLeft")]
        public int OffsetLeft
        {
            get { return Convert.ToInt32(offsetLeft.AsNumber()); }
        }

        public IValue offsetWidth { get; set; }
        [ContextProperty("СмещениеШирина", "OffsetWidth")]
        public int OffsetWidth
        {
            get { return Convert.ToInt32(offsetWidth.AsNumber()); }
        }

        private DfStyle style;
        [ContextProperty("Стиль", "Style")]
        public DfStyle Style
        {
            get { return style; }
            set { style.Copy(value); }
        }
        
        private int currentTime;
        [ContextProperty("ТекущаяПозиция", "CurrentTime")]
        public int CurrentTime
        {
            get { return currentTime; }
            set
            {
                currentTime = value;
                string strFunc = "mapKeyEl.get('" + ItemKey + "')['currentTime'] = '" + currentTime + "';";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
            }
        }

        public DfAction dblclick;
        [ContextProperty("ДвойноеНажатие", "DoubleClick")]
        public DfAction DoubleClick
        {
            get { return dblclick; }
            set
            {
                dblclick = value;
                string strFunc = "mapKeyEl.get(\u0022" + ItemKey + "\u0022).addEventListener(\u0022dblclick\u0022, doEvent);";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
            }
        }
        
        public DfAction click;
        [ContextProperty("Нажатие", "Click")]
        public DfAction Click
        {
            get { return click; }
            set
            {
                click = value;
                string strFunc = "mapKeyEl.get(\u0022" + ItemKey + "\u0022).addEventListener(\u0022click\u0022, doEvent);";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
            }
        }
        
        public DfAction mouseup;
        [ContextProperty("ПриОтпусканииМыши", "MouseUp")]
        public DfAction MouseUp
        {
            get { return mouseup; }
            set
            {
                mouseup = value;
                string strFunc = "mapKeyEl.get(\u0022" + ItemKey + "\u0022).addEventListener(\u0022mouseup\u0022, doEvent);";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
            }
        }
        
        [ContextMethod("Воспроизвести", "Play")]
        public void Play()
        {
            string strFunc = "mapKeyEl.get(\u0022" + ItemKey + "\u0022).play();";
            DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
        }
        
        [ContextMethod("Пауза", "Pause")]
        public void Pause()
        {
            string strFunc = "mapKeyEl.get(\u0022" + ItemKey + "\u0022).pause();";
            DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
        }
        
        [ContextMethod("ПрокрутитьДо", "ScrollIntoView")]
        public void ScrollIntoView(bool p1 = true)
        {
            string strFunc;
            if (!p1)
            {
                strFunc = "mapKeyEl.get(\u0022" + ItemKey + "\u0022).scrollIntoView(false);";
            }
            else
            {
                strFunc = "mapKeyEl.get(\u0022" + ItemKey + "\u0022).scrollIntoView();";
            }
            DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
        }
        
        [ContextMethod("СнятьФокус", "Blur")]
        public void Blur()
        {
            string strFunc = "mapKeyEl.get(\u0022" + ItemKey + "\u0022).blur();";
            DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
        }
        
        [ContextMethod("Удалить", "Remove")]
        public void Remove()
        {
            string strFunc = "mapKeyEl.get(\u0022" + ItemKey + "\u0022).remove();";
            DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
        }
        
        [ContextMethod("Фокус", "Focus")]
        public void Focus()
        {
            string strFunc = "mapKeyEl.get(\u0022" + ItemKey + "\u0022).focus();";
            DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + DeclarativeForms.funDelimiter;
        }
        
    }
}
