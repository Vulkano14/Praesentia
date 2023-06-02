using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    public float[] odst�pyCzasowe; // Tablica odst�p�w czasowych dla ka�dego �wiat�a
    public Light[] �wiat�a; // Tablica �wiate�

    private float[] czasOdOstatniegoMigotania; // Tablica czasu od ostatniego migotania dla ka�dego �wiat�a

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

            // Sprawd�, czy min�� wymagany czas od ostatniego migotania dla danego �wiat�a
            if (czasOdOstatniegoMigotania[i] >= odst�pyCzasowe[i])
            {
                MigotajSwiat�o(i);
                czasOdOstatniegoMigotania[i] = 0.0f; // Zresetuj czas od ostatniego migotania dla danego �wiat�a
            }
        }
    }

    private void MigotajSwiat�o(int indeks)
    {
        // Odwr�� stan danego �wiat�a (w��czone/wy��czone)
        �wiat�a[indeks].enabled = !�wiat�a[indeks].enabled;
    }
}