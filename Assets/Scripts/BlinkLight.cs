using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    public float[] odstępyCzasowe;
    public Light[] światła;

    private float[] czasOdOstatniegoMigotania;

    private void Start()
    {
        czasOdOstatniegoMigotania = new float[światła.Length];
        for (int i = 0; i < czasOdOstatniegoMigotania.Length; i++)
        {
            czasOdOstatniegoMigotania[i] = 0.0f;
        }
    }

    private void Update()
    {
        for (int i = 0; i < światła.Length; i++)
        {
            czasOdOstatniegoMigotania[i] += Time.deltaTime;

            if (czasOdOstatniegoMigotania[i] >= odstępyCzasowe[i])
            {
                MigotajSwiatło(i);
                czasOdOstatniegoMigotania[i] = 0.0f;
            }
        }
    }

    private void MigotajSwiatło(int indeks)
    {
        światła[indeks].enabled = !światła[indeks].enabled;
    }
}