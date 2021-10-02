using System;
using System.Collections.Generic;
using System.Text;

namespace BitMath
{
    public class SimpleMath
    {
        // Сложение
        public static long Add(long summand, long addend)
        {
            // Перенос.
            long carry = 0x00;

            // Итерировать до тех пор, пока не закончится перенос на старший разряд.
            while (addend != 0x00)
            {
                // Выставить флаг под разрядами с установленными битами.
                carry = (summand & addend);

                // Снять с первого слагаемого биты, разряд по которым уже учтен.
                summand = summand ^ addend;

                // Перенос переводится в старший разряд.
                addend = (carry << 1);
            }

            return summand;
        }

        // Вычитание
        public static long Sub(long minuend, long subtrahend)
        {
            // Отрицательный перенос.
            long borrow = 0x00;

            // Итерировать до тех пор, пока не закончится перенос на младший разряд.
            while (subtrahend != 0x00)
            {
                // Выставить флаг под разрядами с установленными битами.
                borrow = ((~minuend) & subtrahend);

                // Снять с уменьшаемого биты, разряд по которым уже учтен.
                minuend = minuend ^ subtrahend;

                // Перенос переводится в старший разряд.
                subtrahend = (borrow << 1);
            }

            return minuend;
        }

        // Умножение
        public static long Multiply(long mul1, long mul2)
        {
            // Результат.
            long result = 0;

            // Пока второй множитель не равен нулю.
            while (mul2 != 0)
            {
                // Если установлен бит в очередном разряде...
                if ((mul2 & 1) == 1)
                {
                    // сложить первый множитель с самим собою.
                    result = Add(result, mul1);
                }

                // Очередной сдвиг первого множителя влево.
                mul1 <<= 1;

                // Подводим очередной разряд в начало для сверки с условием оператора if().
                mul2 >>= 1;
            }

            return result;
        }

        // Хотя и входные данные long, их значения должны быть не больше int
        public static long Divide(long dividend, long divisor)
        {
            // Инициализация результата
            long ans = 0; 

            // Получаем знак результата
            bool isNegative = (dividend < 0) ^ (divisor < 0);

            // Получаем модуль числа (абсолютное значение) для входных параметров (делимого и делителя).
            dividend = dividend < 0 ? Add((~dividend), 1) : dividend;
            divisor = divisor < 0 ? Add((~divisor), 1) : divisor;

            // Осуществляем побитовое деление
            for (int i = sizeof(int) * 8 - 1; i > -1; i--)
            {
                if((divisor << i) <= dividend)
                {
                    dividend -= divisor << i;
                    ans += 1 << i;
                }
            }

            // Добавляем знак к результату
            return isNegative ? -ans : ans;
        }

        // Получение остатка от деления
        public static long DivisionRemainder(long dividend, long divisor)
        {
            // Получаем знак результата
            bool isNegative = (dividend < 0) ^ (divisor < 0);

            // Получаем модуль числа (абсолютное значение) для входных параметров (делимого и делителя).
            dividend = dividend < 0 ? Add((~dividend), 1) : dividend;
            divisor = divisor < 0 ? Add((~divisor), 1) : divisor;

            // Осуществляем побитовое деление и получаем остаток
            for (int i = sizeof(int) * 8 - 1; i > -1; i--)
            {
                if ((divisor << i) <= dividend)
                {
                    dividend -= divisor << i;
                }
            }

            // Добавляем знак к результату
            return isNegative ? -dividend : dividend;
        }
    }
}
