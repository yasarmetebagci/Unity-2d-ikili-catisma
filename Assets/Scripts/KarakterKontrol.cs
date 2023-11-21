using UnityEngine;

public class KarakterKontrol : MonoBehaviour
{
    public float hiz = 5f;
    public float ziplamaGucu = 8f;
    private bool yereDusuyor = false;
    private int ziplamaSayisi = 0;
    private const int maksZiplamaSayisi = 2;

    void Update()
    {
        YuruHareketi();
        ZiplamaKontrolu();
    }

    void YuruHareketi()
    {
        float yatayHareket = Input.GetAxis("Horizontal") * hiz * Time.deltaTime;
        transform.Translate(yatayHareket, 0, 0);
    }

    void ZiplamaKontrolu()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (yereDusuyor || ziplamaSayisi < maksZiplamaSayisi))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, ziplamaGucu), ForceMode2D.Impulse);

            if (yereDusuyor)
            {
                yereDusuyor = false;
                ziplamaSayisi = 1;
            }
            else
            {
                ziplamaSayisi++;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zemin")
        {
            yereDusuyor = true;
            ziplamaSayisi = 0;
        }
    }
}
