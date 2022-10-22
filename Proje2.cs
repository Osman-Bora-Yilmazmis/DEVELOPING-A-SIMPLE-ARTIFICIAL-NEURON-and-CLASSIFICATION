using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructers2
{
    class Program
    {   
        static void Main(string[] args)
        {
            // EGİTİM VE TEST VERİLERİ BURADA BULUNMAKTADIR
            int [][] Egitimverisi =  new int [][]{new int[] {6,5,1 },new int[] {2,4,1 },new int[] {-3,-5,-1 },new int[] {-1,-1, -1},new int[] {1,1, 1},new int[] {-2,7, 1},new int[] {-4,-2, -1},new int[] {-6,3, -1} };
            int[][] TestVerisi1= new int[][] { new int[] { 7, 8, 1 }, new int[] { -5, 4, -1 }, new int[] { -3, -5, -1 }, new int[] { 1, -5, -1 }, new int[] { 1, 4, 1 }, new int[] { -9, 6, -1 }, new int[] { 2, 7, 1 }, new int[] { -4, -5, -1 }, new int[] { -6, -2, -1 } };
            int[][] TestVerisi2 = new int[][] { new int[] { 2, 7, 1 }, new int[] { 10, 7, 1}, new int[] { 3, -6, -1 }, new int[] { 7, -5, 1 }, new int[] { -1, 4, 1 }, new int[] { 6, 5, 1 }, new int[] { 3, -7, -1 }, new int[] { 4, -5, -1 }, new int[] { 6, -2, 1 } };
            int[][] TestVerisi3 = new int[][] { new int[] { -8, -4, -1 }, new int[] { -9, 7, -1 }, new int[] { -3, 6, 1 }, new int[] { 4, -9, -1 }, new int[] { -1, 2, 1 }, new int[] { -6, -5, -1 }, new int[] { -8, 10, 1 }, new int[] { 2, -6, -1 }, new int[] { 7, 2, 1 } };
            int[][] TestVerisi4 = new int[][] { new int[] { -5, -2, -1 }, new int[] { -1, 3, 1}, new int[] { 7, 2, 1 }, new int[] { 6, 3, 1 }, new int[] { -5, -2, -1 }, new int[] { 10, 0, 1 }, new int[] { -4, 10, 1 }, new int[] { -2, -6, -1 }, new int[] { 1, 1, 1 } };
            int[][] TestVerisi5 = new int[][] { new int[] { -8, -4, -1 }, new int[] { -9, 7, -1 }, new int[] { -3, 6, 1 }, new int[] { 4, -9, -1 }, new int[] { -1, 2, 1 }, new int[] { -6, -5, -1 }, new int[] { -8, 10, 1 }, new int[] { 2, -6, -1 }, new int[] { 7, 2, 1 } };
            
            //SİNİR HUCREMİZ
            SinirHücresi Shücre = new SinirHücresi();
            
            HucreEgitimi(Shücre, Egitimverisi, 10);//10 EPOK ICIN HUCRE EGITIMI 
            HucreEgitimi(Shücre, Egitimverisi, 100);//100 EPOK ICIN HUCRE EGITIMI
            Console.ReadKey();
            
            testİslemi(Shücre , TestVerisi1);//TESTVERISI1 ICIN HUCRENIN TESTI
           
            testİslemi(Shücre, TestVerisi2);//TESTVERISI2 ICIN HUCRENIN TESTI

            testİslemi(Shücre, TestVerisi3);//TESTVERISI3 ICIN HUCRENIN TESTI

            testİslemi(Shücre, TestVerisi4);//TESTVERISI4 ICIN HUCRENIN TESTI

            testİslemi(Shücre, TestVerisi5);//TESTVERISI5 ICIN HUCRENIN TESTI

        }
        //TESTVERISI1 TESTVERISI2 TESTVERISI3 TESTVERISI4 TESTVERISI5 burada isleme tabi tutulmaktadır
        static void testİslemi(SinirHücresi Shücre,int[][] TestVerisi) { //Test basari oranının ekrana yazdırıldıgı metottur
            double dogruOrani = testEt(Shücre, TestVerisi);
            Console.WriteLine(String.Format("TestVerisi için doğruluk oranı: {0:00.00}", dogruOrani));
            Console.ReadKey();
        }

        static double testEt(SinirHücresi sHücre,int[][] veriSetleri) {//her bir veri seti icin dogru sayısı burada oluşturulur
            double dogruSayisi = 0;
            foreach (int[] veriseti in veriSetleri)
            {
                double x1 = veriseti[0] * 0.1;
                double x2 = veriseti[1] * 0.1;
                int hedef = veriseti[2];
                if (sHücre.Cikti(x1, x2) == hedef)
                {
                    dogruSayisi++;
                }

            }
            return (dogruSayisi / veriSetleri.Length) *100;//Accurcy degerini döndürür
        }
        static void HucreEgitimi(SinirHücresi Shücre, int[][] veriSetleri, int epokSayisi) {//epok sayisi kadar verilen veri setinin eğitimi yapılır
            
            for(int i = 0; i < epokSayisi; i++)
            {
                int toplamDogruluk = Shücre.egit(veriSetleri);
                Console.WriteLine("Epok:" + i +"   " + "Dogruluk:" + ((double)toplamDogruluk / veriSetleri.Length) * 100);
            }
        
        }
        class SinirHücresi //sinir hücresi sınıfımız burada bulunmaktadır
        {
            double LambdaSabiti = 0.05;
            double Agirlikx1;
            double Agirlikx2;
            
            Random RandomSayi = new Random();
            public SinirHücresi()//-1 le 1 arasında random veri oluşturulur
            {
                Agirlikx1 = RandomSayi.NextDouble() *2 -1;
                Agirlikx2 = RandomSayi.NextDouble() * 2 - 1;
            }

            public int egit(int[][] egitimVerisi) //veri setindeki verilere sinir hücresine hedef tahmin ettirilir
            {
                int dogruSayisi = 0;
                foreach(int[] i in egitimVerisi)
                {
                    int cikti = Cikti(i[0] * 0.1,i[1] * 0.1);
                    if (cikti != i[2])
                    {
                        AgirliklariDegistir(i[0] * 0.1 , i[1] * 0.1, i[2] - cikti);

                    }
                    else {
                        dogruSayisi++;
                    }

                }
                return dogruSayisi;
            }

            private void  AgirliklariDegistir(double x1, double x2,int tEksiO)//Agirliklar degistirilir
            {

                Agirlikx1 += LambdaSabiti * tEksiO * x1;
                Agirlikx2 += LambdaSabiti * tEksiO * x2;
            
            }

            public int Cikti(double x1, double x2)//toplama fonkisyonu ve eşik fonksiyonu burada bulunmaktadır
            {
                double toplam = Agirlikx1 * x1 + Agirlikx2 * x2;
                if(toplam > 0.5)
                {
                    return 1;

                }else
                {
                    return -1;
                }

            }

        }
   
    }
}
