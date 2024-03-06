using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helper
{
    public class FileHelperManager : IFileHelper
    {


        public string Upload(IFormFile formFile, string root)
        {

            if (formFile.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    //Directory >> System.IO'nın bir class'ı. Dizinleri ve alt dizinleri oluşturmak,
                    //taşımak ve numaralandırmak için statik yöntemleri kullanıma sunar.
                    //Exists >> Verilen yolun diskte var olan bir dizine başvurup başvurmayacağını belirler.
                    Directory.CreateDirectory(root);
                }

                //Gönderilen dosyanın uzantısı elde edilir.
                string extension = Path.GetExtension(formFile.FileName);


                //Guid.NewGuid() >>> Eşsiz bir değer oluşturur..
                //ToString() >>> String hale getirir.
                string guid =Guid.NewGuid().ToString();



                //Oluşturulan eşsiz değer (GUID) ve dosya uzantısı birleştirilerek yeni dosya adı elde edilir.
                string filePath = guid + extension;


                //Dosyanın kaydedileceği yeni yol ve adı kullanılarak bir FileStream oluşturur.
                //Bu nesne, dosyanın içeriğini kopyalamak ve hedef dizine kaydetmek için kullanılır.
                //Eğer aynı isimde bir dosya bulunuyorsa üzerine yazılır.
                using (FileStream fileStream = File.Create(root + filePath))
                {

                    //IFormFile nesnesinin içeriğini oluşturulan FileStream nesnesine kopyalar.
                    //Yani, dosyanın içeriği yeni yere kopyalanır.
                    formFile.CopyTo(fileStream);



                    //Dosyanın içeriğini tampon bellekten gerçek diske yazmaya zorlar.Bellekten temizler.
                    fileStream.Flush();




                    //Sql servere dosyayı adı ile eklemek için
                    //eşsiz değer ve uzantısı ile oluşan yeni adını geri gönderir.
                    return filePath;
                }
              

            }
            return null; //Dosya yükleme işlemi tamamlanmışsa filePath döndürülür, aksi halde null döndürülür.



        }



        //String filePath >> 'CarImageManager'dan gelen dosyanın kaydedildiği adresini ve adını temsil eder.
        public void Delete(string filePath)
        {
            if (File.Exists(filePath)) //Belirtilen filePath'deki dosyanın var olup olmadığını kontrol eder.
            {
                File.Delete(filePath); //Eğer dosya var ise bulunduğu yerden silinir.
            }
        }



        //Dosya güncellemek için gelen parametreler >>
        //Güncellenecek yeni dosya, eski dosyanın kaydedildiği adres ve ad, ve yeni bir kayıt dizini
        public string Update(IFormFile formFile, string filePath, string root)
        {
            if (File.Exists(filePath)) //Belirtilen filePath'deki dosyanın var olup olmadığını kontrol eder.
            {
                File.Delete(filePath); //Eğer dosya var ise dosya bulunduğu yerden siliniyor.
            }



            //Eski dosya silindikten sonra yerine geçecek yeni dosyanın *Upload* metoduna gönderilmesini sağlar.
            //yeni dosya ve kayıt edileceği adres parametre olarak döndürülür.
            return Upload(formFile, root); 
        }

       
    }
}
