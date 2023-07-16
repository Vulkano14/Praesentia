using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    public float[] odst�pyCzasowe;
    public Light[] �wiat�a;

    private float[] czasOdOstatniegoMigotania;

    private void Start()
    {
        czasOdOstatniegoMigotania = new float[�wiat�a.Length];
        for (int i = 0; i < czasOdOstatniegoMigotania.Length; i++)
        {
            czasOdOstatniegoMigotania[i] = 0.0f;
        }
    }

    private void Update()
    {
        for (int i = 0; i < �wiat�a.Length; i++)
        {
            czasOdOstatniegoMigotania[i] += Time.deltaTime;

            if (czasOdOstatniegoMigotania[i] >= odst�pyCzasowe[i])
            {
                MigotajSwiat�o(i);
                czasOdOstatniegoMigotania[i] = 0.0f;
            }
        }
    }

    private void MigotajSwiat�o(int indeks)
    {
        �wiat�a[indeks].enabled = !�wiat�a[indeks].enabled;
    }
}