using System;

namespace Julius.LongSchlong
{
    public struct LongSchlong
    {
        byte[] actualNumber;

        public LongSchlong(LongSchlong number)
        {
            this.actualNumber = number.actualNumber;
        }

        public LongSchlong(string number)
        {
            actualNumber = new byte[number.Length];
            for (int i = 0; i < number.Length; i++)
            {
                byte digit = (byte)(number[i] - '0');
                actualNumber[i] = digit;
            }
        }

        private string Stringify(byte[] items)
        {
            return string.Join("", items);
        }

        public override string ToString()
        {
            return Stringify(actualNumber);
        }

        private int GetResultLength(LongSchlong number)
        {
            return Math.Max(number.actualNumber.Length, this.actualNumber.Length);
        }
        private int GetNumberIfInRange(byte[] number, int index)
        {
            int max = number.Length - 1 - index;
            return max < 0 ? 0 : number[max];
        }
        private (byte[] result, int carry) Add_SameLength(LongSchlong number, int maxLength)
        {
            //both same length:
            int carry = 0;
            byte[] result = new byte[maxLength];

            for (int i = maxLength - 1; i >= 0; i--)
            {
                int res = carry + number.actualNumber[i] + this.actualNumber[i];
                carry = res > 9 ? 1 : 0;
                result[i] = Convert.ToByte(res > 9 ? 0 : res);
            }

            return (result, carry);
        }
        private (byte[] result, int carry) Add_DiffLength(LongSchlong number, int maxLength)
        {
            int carry = 0;
            byte[] result = new byte[maxLength];

            for (int i = 0; i < maxLength; i++)
            {
                int value1 = GetNumberIfInRange(number.actualNumber, i);
                int value2 = GetNumberIfInRange(this.actualNumber, i);
                var res = carry + value1 + value2;
                carry = res > 9 ? 1 : 0;

                result[maxLength - i - 1] = Convert.ToByte(res > 9 ? 0 : res);
            }

            return (result, carry);
        }

        private LongSchlong Add(LongSchlong number)
        {
            int carry = 0;
            byte[] result;
            int maxLength = GetResultLength(number);

            if (number.actualNumber.Length == this.actualNumber.Length)
            {
                var res = Add_SameLength(number, maxLength);
                carry = res.carry;
                result = res.result;
            }
            else //different length
            {
                var res = Add_DiffLength(number, maxLength);
                carry = res.carry;
                result = res.result;
            }

            //Extend the array for carry values: eg. 500(3) + 500(3) = 1000(4)
            if (carry == 1)
            {
                Array.Resize(ref this.actualNumber, this.actualNumber.Length + 1);
                this.actualNumber[this.actualNumber.Length - 1] = 1;
            }

            this.actualNumber = result;
            return this;
        }

        public static LongSchlong operator +(LongSchlong val1, LongSchlong val2)
        {
            return new LongSchlong(val1.Add(val2));
        }
    }
}