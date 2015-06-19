// Build a Sieve of Eratosthenes.
private bool[] MakeSieve(int max)
{
    // Make an array indicating whether numbers are prime.
    bool[] is_prime = new bool[max + 1];
    for (int i = 2; i <= max; i++) is_prime[i] = true;

    // Cross out multiples.
    for (int i = 2; i <= max; i++)
    {
        // See if i is prime.
        if (is_prime[i])
        {
            // Knock out multiples of i.
            for (int j = i * 2; j <= max; j += i)
                is_prime[j] = false;
        }
    }
    return is_prime;
}
