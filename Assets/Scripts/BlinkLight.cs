using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    public float[] odstêpyCzasowe; // Tablica odstêpów czasowych dla ka¿dego œwiat³a
    public Light[] œwiat³a; // Tablica œwiate³

    private float[] czasOdOstatniegoMigotania; // Tablica czasu od ostatniego migotania dla ka¿dego œwiat³a

    private void Start()
    {
        czasOdOstatniegoMigotania = new float[œwiat³a.Length];
        for (int i = 0; i < czasOdOstatniegoMigotania.Length; i++)
        {
            czasOdOstatniegoMigotania[i] = 0.0f;
        }
    }

    private void Update()
    {
        for (int i = 0; i < œwiat³a.Length; i++)
        {
            czasOdOstatniegoMigotania[i] += Time.deltaTime;

            // SprawdŸ, czy min¹³ wymagany czas od ostatniego migotania dla danego œwiat³a
            if (czasOdOstatniegoMigotania[i] >= odstêpyCzasowe[i])
            {
                MigotajSwiat³o(i);
                czasOdOstatniegoMigotania[i] = 0.0f; // Zresetuj czas od ostatniego migotania dla danego œwiat³a
            }
        }
    }

    private void MigotajSwiat³o(int indeks)
    {
        // Odwróæ stan danego œwiat³a (w³¹czone/wy³¹czone)
        œwiat³a[indeks].enabled = !œwiat³a[indeks].enabled;
    }
}