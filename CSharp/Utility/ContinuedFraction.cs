        public static Tuple<BigInteger, BigInteger> ComputeNthConvergent(int[] coefficientList)
        {
            BigInteger h_0 = 0;
            BigInteger h_1 = 1;
            BigInteger k_0 = 1;
            BigInteger k_1 = 0;

            for (var i = 0; i < coefficientList.Length; i++)
            {
                BigInteger h_temp = h_1;
                BigInteger k_temp = k_1;
                h_1 = coefficientList[i] * h_1 + h_0;
                k_1 = coefficientList[i] * k_1 + k_0;
                h_0 = h_temp;
                k_0 = k_temp;
            }

            return new Tuple<BigInteger, BigInteger>(h_1, k_1);
        }
