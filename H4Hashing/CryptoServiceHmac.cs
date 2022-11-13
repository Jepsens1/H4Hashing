using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace H4Hashing
{
    public class CryptoServiceHmac
    {
        private HMAC _mac;
        public byte[] Key;
        public CryptoServiceHmac(string name)
        {
            HmacHandler(name);
        }
        private void HmacHandler(string name)
        {
            switch (name.ToLower())
            {
                case "sha1":
                    _mac = new HMACSHA1();
                    Key = GenerateKey(64);
                    break;
                case "sha256":
                    _mac = new HMACSHA256();
                    Key = GenerateKey(64);
                    break;
                case "sha512":
                    _mac = new HMACSHA512();
                    Key = GenerateKey(128);
                    break;
                case "md5":
                    _mac = new HMACMD5();
                    Key = GenerateKey(16);
                    break;
                case "sha384":
                    _mac = new HMACSHA384();
                    Key = GenerateKey(48);
                    break;
            }
        }
        private byte[] GenerateKey(int size)
        {
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] key = new byte[size];
                rng.GetBytes(key);
                return key;
            }
        }

        public bool CheckAuth(byte[] mess, byte[] mac)
        {
            _mac.Key = Key;
            if (CompareByteArrays(_mac.ComputeHash(mess), mac, _mac.HashSize / 8) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public byte[] ComputeMac(byte[] mes)
        {
            _mac.Key = Key;
            return _mac.ComputeHash(mes);
        }
        private bool CompareByteArrays(byte[] a, byte[] b, int len)
        {
            for (int i = 0; i < len; i++)
                if (a[i] != b[i])
                    return false;
            return true;
        }
    }
}
