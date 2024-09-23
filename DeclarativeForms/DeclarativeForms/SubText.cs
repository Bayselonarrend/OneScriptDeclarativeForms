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
    [ContextClass("ДфПодстрочныйТекст", "DfSubText")]
    public class DfSubText : AutoContext<DfSubText>
    {

        public DfSubText()
        {
            Name = "d" + Path.GetRandomFileName().Replace(".", "");
            string strFunc = "createElement(\u0022" + "sub" + "\u0022, \u0022" + Name + "\u0022)";
            DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + ";";
            DeclarativeForms.AddToHashtable(Name, this);
            style = new DfStyle();
            style.Owner = this;
        }

        public PropertyInfo this[string p1]
        {
            get { return this.GetType().GetProperty(p1); }
        }

        private int scrollTop;
        [ContextProperty("ВертикальноеПрокручивание", "ScrollTop")]
        public int ScrollTop
        {
            get { return scrollTop; }
            set
            {
                scrollTop = value;
                //setProperty(nameElement, nameProperty, valueProperty)
                string strFunc = "setProperty(\u0022" + Name + "\u0022, \u0022" + "scrollTop" + "\u0022, \u0022" + scrollTop + "\u0022)";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + ";";
            }
        }

        private int scrollLeft;
        [ContextProperty("ГоризонтальноеПрокручивание", "ScrollLeft")]
        public int ScrollLeft
        {
            get { return scrollLeft; }
            set
            {
                scrollLeft = value;
                //setProperty(nameElement, nameProperty, valueProperty)
                string strFunc = "setProperty(\u0022" + Name + "\u0022, \u0022" + "scrollLeft" + "\u0022, \u0022" + scrollLeft + "\u0022)";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + ";";
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
                //setProperty(nameElement, nameProperty, valueProperty)
                string strFunc = "setProperty(\u0022" + Name + "\u0022, \u0022" + "id" + "\u0022, \u0022" + id + "\u0022)";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + ";";
            }
        }

        private string name;
        [ContextProperty("Имя", "Name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string className;
        [ContextProperty("ИмяКласса", "ClassName")]
        public string ClassName
        {
            get { return className; }
            set
            {
                className = value;
                //setProperty(nameElement, nameProperty, valueProperty)
                string strFunc = "setProperty(\u0022" + Name + "\u0022, \u0022" + "className" + "\u0022, \u0022" + className + "\u0022)";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + ";";
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
                //setProperty(nameElement, nameProperty, valueProperty)
                string strFunc = "setProperty(\u0022" + Name + "\u0022, \u0022" + "accessKey" + "\u0022, \u0022" + accessKey + "\u0022)";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + ";";
            }
        }

        private string dir;
        [ContextProperty("Направление", "Dir")]
        public string Dir
        {
            get { return dir; }
            set
            {
                dir = value;
                //setProperty(nameElement, nameProperty, valueProperty)
                string strFunc = "setProperty(\u0022" + Name + "\u0022, \u0022" + "dir" + "\u0022, \u0022" + dir + "\u0022)";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + ";";
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
                //setProperty(nameElement, nameProperty, valueProperty)
                string strFunc = "setProperty(\u0022" + Name + "\u0022, \u0022" + "tabIndex" + "\u0022, \u0022" + tabIndex + "\u0022)";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + ";";
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
                //setProperty(nameElement, nameProperty, valueProperty)
                string strFunc = "setProperty(\u0022" + Name + "\u0022, \u0022" + "contentEditable" + "\u0022, \u0022" + contentEditable.ToString().ToLower() + "\u0022)";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + ";";
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
                //setParent(nameElement, nameparent)
                string strFunc = "setParent(\u0022" + Name + "\u0022, \u0022" + parent.AsObject().GetPropValue("Name") + "\u0022)";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + ";";
                // Родителю добавим потомка.
                ArrayImpl ArrayImpl1 = ((dynamic)parent).Children;
                ArrayImpl1.Add(this);
            }
        }

        private DfStyle style;
        [ContextProperty("Стиль", "Style")]
        public DfStyle Style
        {
            get { return style; }
            set { style.Copy(value); }
        }
        
        private IValue innerText;
        [ContextProperty("Текст", "Text")]
        public IValue Text
        {
            get { return innerText; }
            set
            {
                innerText = value;
                //setProperty(nameElement, nameProperty, valueProperty)
                string str = value.AsString();
                str = str.Replace("\u005C", @"\u005C"); // Обратная косая черта
                str = str.Replace("\u003B", @"\u003B"); // Точка с запятой.
                str = str.Replace("\u000A", @"\u000A"); // Перевод строки
                str = str.Replace("\u007C", @"\u007C"); // Знак |
                str = str.Replace("\u0022", @"\u0022"); // Кавычки.
                string strFunc = "setProperty(\u0022" + Name + "\u0022, \u0022" + "innerText" + "\u0022, \u0022" + str + "\u0022)";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + ";";
            }
        }

        private ArrayImpl children = new ArrayImpl();
        [ContextProperty("Элементы", "Children")]
        public ArrayImpl Children
        {
            get { return children; }
        }

        public DfAction dblclick;
        [ContextProperty("ДвойноеНажатие", "DoubleClick")]
        public DfAction DoubleClick
        {
            get { return dblclick; }
            set
            {
                dblclick = value;
                //map.get(nameElement).addEventListener(nameEvent, doEvent);
                string strFunc = "map.get(\u0022" + Name + "\u0022).addEventListener(\u0022dblclick\u0022, doEvent);";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + ";";
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
                //map.get(nameElement).addEventListener(nameEvent, doEvent);
                string strFunc = "map.get(\u0022" + Name + "\u0022).addEventListener(\u0022click\u0022, doEvent);";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + ";";
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
                //map.get(nameElement).addEventListener(nameEvent, doEvent);
                string strFunc = "map.get(\u0022" + Name + "\u0022).addEventListener(\u0022mouseup\u0022, doEvent);";
                DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + ";";
            }
        }
        
        [ContextMethod("ДобавитьДочерний", "АppendChild")]
        public IValue АppendChild(IValue p1)
        {
            string strFunc = "map.get(\u0022" + Name + "\u0022).appendChild(map.get(\u0022" + ((dynamic)p1).Name + "\u0022));";
            DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + ";";
            ((dynamic)p1).Parent = this;
            return p1;
        }
        
        [ContextMethod("ПрокрутитьДо", "ScrollIntoView")]
        public void ScrollIntoView(bool p1 = true)
        {
            string strFunc;
            if (!p1)
            {
                strFunc = "map.get(\u0022" + Name + "\u0022).scrollIntoView(false);";
            }
            else
            {
                strFunc = "map.get(\u0022" + Name + "\u0022).scrollIntoView();";
            }
            DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + ";";
        }
        
        [ContextMethod("СнятьФокус", "Blur")]
        public void Blur()
        {
            //map.get(nameElement).blur();
            string strFunc = "map.get(\u0022" + Name + "\u0022).blur();";
            DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + ";";
        }
        
        [ContextMethod("Удалить", "Remove")]
        public void Remove()
        {
            //map.get(nameElement).remove();
            string strFunc = "map.get(\u0022" + Name + "\u0022).remove();";
            DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + ";";
        }
        
        [ContextMethod("УдалитьДочерний", "RemoveChild")]
        public void RemoveChild(IValue p1)
        {
            string strFunc = "map.get(\u0022" + Name + "\u0022).removeChild(map.get(\u0022" + ((dynamic)p1.AsObject()).Name + "\u0022));";
            DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + ";";
        }
        
        [ContextMethod("Фокус", "Focus")]
        public void Focus()
        {
            //map.get(nameElement).focus();
            string strFunc = "map.get(\u0022" + Name + "\u0022).focus();";
            DeclarativeForms.strFunctions = DeclarativeForms.strFunctions + strFunc + ";";
        }
        
    }
}