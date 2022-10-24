﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Source
{
    internal class MessageException
    {
        public const string Name = "Имя - содержит русские или латинские символы " +
            "(в одном имени не могут присутствовать\r\nи те и другие), начинается с заглавной буквы.";
        public const string Surname = "Фамилия - содержит русские или латинские символы " +
            "(в одной фамилии не могут присутствовать и те и другие), начинается с заглавной буквы. " +
            "Может содержать дефис, в этом случае первый символ после дефиса заглавная. " +
            "Дефис не может быть первым или последним символом.";
        public const string Email = "Электронная почта - имя почтового ящика может содержать: " +
            "буквы, цифры, точку, дефис и знак подчеркивания, причем первым и последним символами могут быть только буквы или цифры. " +
            "Для имен поддоменов действуют те же самые правила, но точка допустимой не является. " +
            "Имя домена первого уровня может состоять только из букв в количестве от 2 до 6.";
        public const string Login = "Логин - содержит латинские символы.";
    }
}
