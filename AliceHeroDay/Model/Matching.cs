using System;
using System.Linq;

namespace AliceHeroDay.Model
{
    public class Matching
    {
        public bool ContainOneOf(string text, string[] words)
        {
            foreach (var i in words)
            {
                i.ToLower().Split().ToHashSet();
                if (text.IndexOf(i, StringComparison.OrdinalIgnoreCase) >= 0) return true;
            }
            return false;
        }

        //Хеш-функция для алгоритма Рабина-Карпа
        public int Hash(string x)
        {
            int p = 31; //Простое число
            int rez = 0; //Результат вычисления
            for (int i = 0; i < x.Length; i++)
            {
                rez += (int)Math.Pow(p, x.Length - 1 - i) * (int)(x[i]);//Подсчет хеш-функции
            }
            return rez;
        } //Функция поиска алгоритмом Рабина-Карпа

        public string HashCompareTo(string x, string s)
        {
            string nom = "";
            //Номера всех вхождений образца в строку 
            if (x.Length > s.Length) return nom; //Если искомая строка больше исходной – возврат пустого поиска
            int xhash = Hash(x); //Вычисление хеш-функции искомой строки
            int shash = Hash(s.Substring(0, x.Length)); //Вычисление хеш-функции первого слова длины образца в строке S
            bool flag;
            int j;
            for (int i = 0; i < s.Length - x.Length; i++)
            {
                if (xhash == shash)//Если значения хеш-функций совпадают 
                {
                    flag = true; j = 0; while ((flag == true) && (j < x.Length)) { if (x[j] != s[i + j]) flag = false; j++; }
                    if (flag == true) //Если искомая строка совпала с частью исходной 
                        nom = nom + Convert.ToString(i) + ", "; //Добавление номера вхождения 
                }
                else //Иначе вычисление нового значения хеш-функции
                    shash = (shash - (int)Math.Pow(31, x.Length - 1) * (int)(s[i])) * 31 + (int)(s[i + x.Length]);
            }
            if (nom != "") //Если вхождение найдено 
            {
                nom = nom.Substring(0, nom.Length - 2); //Удаление запятой и пробела 
            }
            return nom; //Возвращение результата поиска 

        }
    }
}
