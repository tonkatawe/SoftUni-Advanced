using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {
    
        public static T[] Create<T>(int length, T item)
        {

            var newArr = new T[length];
            for (int i = 0; i < length; i++)
            {
                newArr[i] = item;
            }
            return newArr;
        }
    }
}
