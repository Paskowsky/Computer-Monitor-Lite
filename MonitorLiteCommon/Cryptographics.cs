using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MonitorLiteCommon
{
    public static class Cryptographics
    {
        private static RijndaelManaged CreateRijndael()
        {
            RijndaelManaged rij = new RijndaelManaged();
            rij.KeySize = 256;
            rij.BlockSize = 256;
            rij.Padding = PaddingMode.Zeros;
            rij.Mode = CipherMode.CBC;

            return rij;
        }

        private static RSACryptoServiceProvider CreateRSA(string key)
        {
            byte[] keyData = Convert.FromBase64String(key);
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportCspBlob(keyData);
            return rsa;
        }

        public static byte[] Encrypt(byte[] data, string publicKey)
        {

            byte[] cipherData;

            using (RijndaelManaged rij = CreateRijndael())
            {
                rij.GenerateKey();
                rij.GenerateIV();

                byte[] key = rij.Key;
                byte[] iv = rij.IV;

                byte[] keyblob = new byte[key.Length + iv.Length];

                Buffer.BlockCopy(key, 0, keyblob, 0, key.Length);
                Buffer.BlockCopy(iv, 0, keyblob, key.Length, iv.Length);

                using (RSACryptoServiceProvider rsa = CreateRSA(publicKey))
                {

                    keyblob = rsa.Encrypt(keyblob, true);

                }

                using (ICryptoTransform enc = rij.CreateEncryptor())
                {
                    byte[] encrypted_data = enc.TransformFinalBlock(data, 0, data.Length);

                    cipherData = new byte[encrypted_data.Length + keyblob.Length + 4];

                    Buffer.BlockCopy(encrypted_data, 0, cipherData, 0, encrypted_data.Length);
                    Buffer.BlockCopy(keyblob, 0, cipherData, encrypted_data.Length, keyblob.Length);
                    Buffer.BlockCopy(BitConverter.GetBytes(keyblob.Length), 0, cipherData, encrypted_data.Length + keyblob.Length, sizeof(int));
                }
                return cipherData;
            }


        }

        public static byte[] HashSign(byte[] data, string publicKey)
        {
            using (RSACryptoServiceProvider rsa = CreateRSA(publicKey))
            {
                using (SHA256Managed sha256 = new SHA256Managed())
                {
                    byte[] hash = sha256.ComputeHash(data);

                    byte[] encryptedHash = rsa.Encrypt(hash, true);

                    byte[] signed = new byte[data.Length + encryptedHash.Length + 4];

                    Buffer.BlockCopy(data, 0, signed, 0, data.Length);
                    Buffer.BlockCopy(encryptedHash, 0, signed, data.Length, encryptedHash.Length);
                    Buffer.BlockCopy(BitConverter.GetBytes(encryptedHash.Length), 0, signed, data.Length + encryptedHash.Length, 4);
                    return signed;
                }

            }
        }

        public static byte[] Decrypt(byte[] data, string privateKey)
        {

            int keyblobLen = BitConverter.ToInt32(data, data.Length - 4);

            byte[] keyblob = new byte[keyblobLen];

            Buffer.BlockCopy(data, data.Length - 4 - keyblob.Length, keyblob, 0, keyblob.Length);

            using (RSACryptoServiceProvider rsa = CreateRSA(privateKey))
            {
                keyblob = rsa.Decrypt(keyblob, true);

            }

            using (RijndaelManaged rij = CreateRijndael())
            {
                byte[] key = new byte[rij.KeySize / 8];
                byte[] iv = new byte[rij.BlockSize / 8];
                Buffer.BlockCopy(keyblob, 0, key, 0, key.Length);
                Buffer.BlockCopy(keyblob, key.Length, iv, 0, iv.Length);
                rij.Key = key;
                rij.IV = iv;
                using (ICryptoTransform dec = rij.CreateDecryptor())
                {
                    byte[] encrypted_data = new byte[data.Length - 4 - keyblob.Length];

                    Buffer.BlockCopy(data, 0, encrypted_data, 0, encrypted_data.Length);

                    byte[] decrypted_data = dec.TransformFinalBlock(encrypted_data, 0,encrypted_data.Length);
                    return decrypted_data;
                }
            }

        }

        public static byte[] HashVerify(byte[] data, string privateKey)
        {
            using (RSACryptoServiceProvider rsa = CreateRSA(privateKey))
            {
                using (SHA256Managed sha256 = new SHA256Managed())
                {
                    byte[] encrypted_hash = new byte[BitConverter.ToInt32(data,data.Length - 4)];
                    Buffer.BlockCopy(data, data.Length - 4 - encrypted_hash.Length, encrypted_hash, 0, encrypted_hash.Length);

                    byte[] decrypted_hash = rsa.Decrypt(encrypted_hash,true);

                    byte[] nude_data = new byte[data.Length - 4 - encrypted_hash.Length];
                    Buffer.BlockCopy(data, 0, nude_data, 0, nude_data.Length);

                    byte[] hash = sha256.ComputeHash(nude_data);

                    for(int i = 0; i < hash.Length; i++)
                    {
                        if(hash[i] != decrypted_hash[i])
                        {
                            throw new Exception();
                        }
                    }

                    return nude_data;
                  
                }
            }
        }

        public static void GenerateKeyPair(out string publicKey,out string privateKey)
        {
            using(RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(4096))
            {
                publicKey = Convert.ToBase64String(rsa.ExportCspBlob(false));
                privateKey = Convert.ToBase64String(rsa.ExportCspBlob(true));
            }
        }
    }
}
