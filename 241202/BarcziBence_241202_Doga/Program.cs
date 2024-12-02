using BarcziBence_241202_Doga;

Random rnd = new Random();

// Szerzők
string[] vezeteknevek = { "Nagy", "Fazekas", "Kovács", "Horváth", "Kőműves", "Kiss" };
string[] keresztnevek = { "Nándor", "Jázmin", "Béla", "Kristóf", "Andrea", "Bálint", "Krisztina", "Eszter" };

// Magyar Címek
string[] magyarElotagok = {"Hősies", "Bátor", "Legyőzhetetlen", "Szerencsejátékfüggő", "Szomorú", "Éhes", "Elveszett"};
string[] magyarKarakterek = { "Lúd", "Pingvin", "Háromfejű szamár", "Rózsaszín sárkány", "Péter", "Kincsvadász", "Kalóz", "Influencer" };
string[] magyarUtotagok = { "Legendája", "Kalandjai", "Varászlaots Ereklyéi", "Karácsonya", "Rémtörténetei" };

// Angol Címek 

string[] angolElotagok = {"BlueHaired", "Tall", "Scary", "Happy", "Bold"};
string[] angolKarakterek = {"Harry", "Grinch", "Elf"};
string[] angolUtotagok = {"IDK"};


List<Book> konyvek = new List<Book>();

// Lista Feltöltéks

for (int i = 0; i < 15; i++)
{
    int keszlet = rnd.Next(1, 101);
    int szerzok = rnd.Next(1, 101);
    int nyelv = rnd.Next(0, 5);

    string cim = (nyelv == 4 ? $"The {angolElotagok[rnd.Next(angolElotagok.Length)]} {angolKarakterek[rnd.Next(angolKarakterek.Length)]} {angolUtotagok[rnd.Next(angolUtotagok.Length)]}" : $"A(z) {magyarElotagok[rnd.Next(magyarElotagok.Length)]} {magyarKarakterek[rnd.Next(magyarKarakterek.Length)]} {magyarUtotagok[rnd.Next(magyarUtotagok.Length)]}");

    if (keszlet < 71) { keszlet = rnd.Next(5, 11); }
    else { keszlet = 0; }

    if (szerzok < 71) { szerzok = 1; }
    else if (szerzok < 86) { szerzok = 2; }
    else { szerzok = 3; }

    string[] genSzerzok = new string[szerzok];
    for (int j = 0; j < genSzerzok.Length; j++) { genSzerzok[j] = $"{vezeteknevek[rnd.Next(vezeteknevek.Length)]} {keresztnevek[rnd.Next(keresztnevek.Length)]}"; }


    konyvek.Add(new(1000000000, cim, rnd.Next(2007, 2023), keszlet, rnd.Next(10, 90)*100, (nyelv == 5 ? Book.Nyelvek.Angol : Book.Nyelvek.Magyar), genSzerzok));

}

// Emuláció

int kifogyott = 0;
int bevetel = 0;
for (int i = 0; i < 100; i++)
{
    Book kivalasztott = konyvek[rnd.Next(konyvek.Count)];
    if (kivalasztott.Keszlet > 0)
    {
        bevetel += kivalasztott.Ar;
        kivalasztott.Keszlet--;
    }
    else
    {
        if (rnd.Next(1, 3) % 2 == 0) { kivalasztott.Keszlet += rnd.Next(1, 11); }
        else { konyvek.Remove(kivalasztott); kifogyott++; }
    }
}

Console.WriteLine($"A nap végén {bevetel}Ft ot keresett a könyvesbolt\n \t{15-konyvek.Count} könyv került eladásra\n \t{kifogyott}db könyv fogyott ki a nagykertben");
Console.WriteLine(konyvek[rnd.Next(konyvek.Count)]);
