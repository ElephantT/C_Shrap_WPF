using System;
using System.Collections.Generic;
using System.Text;

namespace lab12
{
    class KeyGenerator
    {
        private static KeyGenerator key_generator;
        private static int counter = 0;

        // singleton
        private KeyGenerator()
        {
            key_generator = null;
        }

        // singleton
        public static KeyGenerator GetKeyGenerator()
        {
            if (key_generator == null)
                key_generator = new KeyGenerator();
            return key_generator;
        }

        public string GenerateKey()
        {
            ++counter;
            return counter.ToString();
        }
    }
}
