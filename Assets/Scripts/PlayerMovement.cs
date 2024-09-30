using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //rb'yi Rigidbody fonksiyonuna referanslama
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    // Update is called once per frame
    /*Unity’de Update ve FixedUpdate fonksiyonlarý arasýnda bazý önemli farklar vardýr:

        Çaðrýlma Sýklýðý:
    Update: Her karede bir kez çaðrýlýr. Bu, oyunun kare hýzýna (FPS) baðlýdýr. Örneðin, oyun 60 FPS’de çalýþýyorsa,
Update fonksiyonu saniyede 60 kez çaðrýlýr.
    FixedUpdate: Sabit zaman aralýklarýnda çaðrýlýr. Bu, kare hýzýndan baðýmsýzdýr ve genellikle fizik hesaplamalarý 
için kullanýlýr. Varsayýlan olarak, her 0.02 saniyede bir kez çaðrýlýr1.
        Kullaným Alanlarý:
    Update: Genellikle kullanýcý giriþi, animasyonlar ve diðer kare bazlý iþlemler için kullanýlýr. Örneðin, 
oyuncu hareketlerini algýlamak için Update fonksiyonunu kullanabilirsiniz.
    FixedUpdate: Fizik hesaplamalarý ve fizik tabanlý hareketler için idealdir. Örneðin, bir nesneye kuvvet 
uygulamak veya çarpýþma hesaplamalarý yapmak için FixedUpdate fonksiyonunu kullanabilirsiniz1.
        Performans:
    Update: Kare hýzýna baðlý olduðu için, kare hýzýndaki dalgalanmalar Update fonksiyonunun çaðrýlma sýklýðýný 
etkileyebilir.
    FixedUpdate: Sabit zaman aralýklarýnda çalýþtýðý için, fizik hesaplamalarýnýn daha tutarlý ve kararlý 
olmasýný saðlar.*/
    void FixedUpdate()        
    {
        //ileri ittirme gücü eklendi
        rb.AddForce(0, 0, forwardForce * Time.deltaTime); //Z-ekseninde 2000 addForce
        /*Unity’de Time.deltaTime, iki kare arasýndaki zamaný saniye cinsinden temsil eden bir deðiþkendir. 
         Bu, oyun geliþtirmede oldukça önemli bir rol oynar çünkü oyun nesnelerinin kare hýzýndan baðýmsýz 
         olarak tutarlý bir þekilde hareket etmesini saðlar.*/

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
