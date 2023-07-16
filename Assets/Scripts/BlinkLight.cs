using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    public float[] odstêpyCzasowe;
    public Light[] œwiat³a;

    private float[] czasOdOstatniegoMigotania;

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

            if (czasOdOstatniegoMigotania[i] >= odstêpyCzasowe[i])
            {
                MigotajSwiat³o(i);
                czasOdOstatniegoMigotania[i] = 0.0f;
            }
        }
    }

    private void MigotajSwiat³o(int indeks)
    {
        œwiat³a[indeks].enabled = !œwiat³a[indeks].enabled;
    }
}