using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Top _Top;
    [SerializeField] private GameObject[] Ip_Merkezleri;
    [SerializeField] private int ToplamTopSayisi;
    [SerializeField] private int DevrilmesiGerekenObjeSayisi;
    [SerializeField] GameObject[] Paneller;


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Merkez_1"))
                    ZinciriTektikIslem(hit, "Merkez_1");
                else if (hit.collider.CompareTag("Merkez_2"))
                    ZinciriTektikIslem(hit, "Merkez_2");
                else if (hit.collider.CompareTag("Merkez_3"))
                    ZinciriTektikIslem(hit, "Merkez_3");
                else if (hit.collider.CompareTag("Merkez_4"))
                    ZinciriTektikIslem(hit, "Merkez_4");
                else if (hit.collider.CompareTag("Merkez_5"))
                    ZinciriTektikIslem(hit, "Merkez_5");
            }
        }
    }
    void ZinciriTektikIslem(RaycastHit2D hit, string HingeAdi)
    {
        hit.collider.gameObject.SetActive(false);
        foreach (var item in Ip_Merkezleri)
        {
            if (item.GetComponent<Ip_Yonetimi>().HingeAdi == HingeAdi)
            {
                foreach (var item2 in item.GetComponent<Ip_Yonetimi>().BaglantiHavuzu)
                {
                    item2.SetActive(false);
                }
            }
        }
    }
    public void TopDustu()
    {
        ToplamTopSayisi--;
        if (ToplamTopSayisi == 0)
        {
            if (DevrilmesiGerekenObjeSayisi > 0)
            {
                Paneller[1].gameObject.SetActive(true);
                Debug.Log("Kaybettin");
            }
            else if (DevrilmesiGerekenObjeSayisi == 0)
            {
                Paneller[0].gameObject.SetActive(true);
                Debug.Log("Kazandýn");
            }
        }
        else
        {
            if (DevrilmesiGerekenObjeSayisi == 0)
            {
                Paneller[0].gameObject.SetActive(true);
                Debug.Log("Kazandýn");
            }

        }

    }
    public void HedefObjeDustu()
    {
        DevrilmesiGerekenObjeSayisi--;
        if (ToplamTopSayisi == 0 && DevrilmesiGerekenObjeSayisi == 0)
        {
            if (DevrilmesiGerekenObjeSayisi > 0)
            {
                Debug.Log("Kaybettin");
            }
            else if (DevrilmesiGerekenObjeSayisi == 0)
            {
                Debug.Log("Kazandýn");
            }
        }
    }
    public void Butonlarinislemleri(string Deger)
    {
        switch (Deger)
        {
            case "Durdur":
                Time.timeScale = 0;
                Paneller[0].SetActive(true);
                break;
            case "DevamEt":
                Time.timeScale = 1;
                Paneller[0].SetActive(false);
                break;
            case "Tekrar":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
                break;
            case "SonrakiLevel":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Time.timeScale = 1;
                break;
            case "Ayarlar":
            //isteðe baðlý 
            case "Cikis":
                Application.Quit();
                break;
        }

    }
}
