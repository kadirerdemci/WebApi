using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {


        //Burada hash oluşturuyoruz ve out ile girdiğimiz değişkenler dışarıya gönderilecek değişkenlerdir.
        public static void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            //Kriptografiden HMACSHA512 algoritmasını kullanacağımızı belirttik
            using (var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                //bir key değeri elde ettikten sonra atama yaptık
                passwordSalt = hmac.Key;

                //girdiğimiz parolayı önce bir hash karşılığını yazdık
                passwordHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            }
        }



       //Hash doğrulama
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[]passwordSalt)
        {

            //Yukarıda key hmac.key değeri ile bir hash algoritması oluşturduk
            using (var hmac=new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                //Daha sonra aynı algoritmayla passaportumuzun bir hash'ini daha oluşturduk
                var computedHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                //oluşturduğumuz hashi tek tek geziyoruz
                for(int i = 0; i < computedHash.Length; i++)
                {
                    //Ve bize gelen passwordHash ile demin oluşturduğumuz computedHash uyuşup uyuşmadığını
                    //kontrol ediyoruz
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

            }
            return true;
        }
    }
}
