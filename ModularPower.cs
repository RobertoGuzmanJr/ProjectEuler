        public static BigInteger ModularPower(BigInteger b, long exponent, BigInteger modulus)
        {
            BigInteger result = 1;
            var binaryExponent = Convert.ToString(exponent, 2);
            while (binaryExponent.Length > 0)
            {
                if (Convert.ToInt16(binaryExponent.Substring(binaryExponent.Length - 1, 1)) == 1)
                {
                    result = (result*b)%modulus;
                }
                binaryExponent = binaryExponent.Substring(0, binaryExponent.Length - 1);
                b = (b*b)%modulus;
            }
            return result;
        }
