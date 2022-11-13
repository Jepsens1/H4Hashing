using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace H4Hashing
{
    public class CryptoService
    {
        public HashAlgorithm _Hash;
        public CryptoService(string name)
        {
            Handler(name);
        }
        private void Handler(string name)
        {
            switch (name.ToLower())
            {
                case "sha1":
                    _Hash = SHA1.Create();
                    break;
                case "sha256":
                    _Hash = SHA256.Create();
                    break;
                case "sha512":
                    _Hash = SHA512.Create();
                    break;
                case "md5":
                    _Hash = MD5.Create();
                    break;
                case "sha384":
                    _Hash = SHA384.Create();
                    break;
            }
        }
        public byte[] ComputeHash(byte[] mes)
        {
            return _Hash.ComputeHash(mes);
        }
    }
}
