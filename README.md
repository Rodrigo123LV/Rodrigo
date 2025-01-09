Atveriet GitHub repozitoriju:

Ieejiet GitHub repozitorijā, kur atrodas projekta fails. Saite var izskatīties, piemēram: https://github.com/jusu-lietotajvards/projekta-nosaukums. Kopējiet klonēšanas URL:

Nospiediet zaļo pogu "Code" (vai "Kods"). Izvēlieties HTTPS vai SSH URL (parasti HTTPS, piemēram, https://github.com/...). Nokopējiet URL, nospiežot uz "Copy" ikonas. Atveriet Git programmu vai komandrindu:

Ja izmantojat Windows: Meklējiet "Git Bash" vai atveriet parasto komandu logu (Command Prompt). Ja izmantojat Visual Studio, to var darīt arī caur "Team Explorer". Izpildiet klonēšanas komandu: Komandā ievadiet šādu tekstu un nospiediet Enter:

bash Copy code git clone https://github.com/jusu-lietotajvards/projekta-nosaukums Pārbaudiet lejupielādēto mapi:

Pēc klonēšanas izpildes datorā būs mape ar projekta failiem.

////////////////////////////////////////////////////////////////////////////

Projekta atvēršana un izpilde Visual Studio vidē (Ja ir, jo manuprāt šādi būtu pat vieglāk bet nemācēšu teikt.) Atveriet Visual Studio:

Ja Visual Studio nav instalēts, lejupielādējiet to no oficiālās mājaslapas. Izvēlieties "Community" versiju, kas ir bez maksas. Atveriet projektu:

Visual Studio izvēlnē izvēlieties: File > Open > Project/Solution. Atveriet .sln failu, kas atrodas jūsu klonētajā mapē. Uzstādiet projekta atkarības (Dependencies):

Ja projekts izmanto specifiskas NuGet pakotnes, tās automātiski tiks ielādētas, kad pirmoreiz izveidosiet projektu. Ja tas nenotiek, spiediet labo peles taustiņu uz projekta faila un izvēlieties Restore NuGet Packages. Palaidiet projektu:

Nospiediet zaļo pogu "Start" vai taustiņu F5. Projekts tiks kompilēts un palaists.

