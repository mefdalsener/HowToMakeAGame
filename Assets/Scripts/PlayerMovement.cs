using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //rb'yi Rigidbody fonksiyonuna referanslama
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    // Update is called once per frame
    /*Unity�de Update ve FixedUpdate fonksiyonlar� aras�nda baz� �nemli farklar vard�r:

        �a�r�lma S�kl���:
    Update: Her karede bir kez �a�r�l�r. Bu, oyunun kare h�z�na (FPS) ba�l�d�r. �rne�in, oyun 60 FPS�de �al���yorsa,
Update fonksiyonu saniyede 60 kez �a�r�l�r.
    FixedUpdate: Sabit zaman aral�klar�nda �a�r�l�r. Bu, kare h�z�ndan ba��ms�zd�r ve genellikle fizik hesaplamalar� 
i�in kullan�l�r. Varsay�lan olarak, her 0.02 saniyede bir kez �a�r�l�r1.
        Kullan�m Alanlar�:
    Update: Genellikle kullan�c� giri�i, animasyonlar ve di�er kare bazl� i�lemler i�in kullan�l�r. �rne�in, 
oyuncu hareketlerini alg�lamak i�in Update fonksiyonunu kullanabilirsiniz.
    FixedUpdate: Fizik hesaplamalar� ve fizik tabanl� hareketler i�in idealdir. �rne�in, bir nesneye kuvvet 
uygulamak veya �arp��ma hesaplamalar� yapmak i�in FixedUpdate fonksiyonunu kullanabilirsiniz1.
        Performans:
    Update: Kare h�z�na ba�l� oldu�u i�in, kare h�z�ndaki dalgalanmalar Update fonksiyonunun �a�r�lma s�kl���n� 
etkileyebilir.
    FixedUpdate: Sabit zaman aral�klar�nda �al��t��� i�in, fizik hesaplamalar�n�n daha tutarl� ve kararl� 
olmas�n� sa�lar.*/
    void FixedUpdate()        
    {
        //ileri ittirme g�c� eklendi
        rb.AddForce(0, 0, forwardForce * Time.deltaTime); //Z-ekseninde 2000 addForce
        /*Unity�de Time.deltaTime, iki kare aras�ndaki zaman� saniye cinsinden temsil eden bir de�i�kendir. 
         Bu, oyun geli�tirmede olduk�a �nemli bir rol oynar ��nk� oyun nesnelerinin kare h�z�ndan ba��ms�z 
         olarak tutarl� bir �ekilde hareket etmesini sa�lar.*/

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(rb.position.y < -1f)
        {
            FindAnyObjectByType<GameManager>().EndGame();
        }
    }
}
