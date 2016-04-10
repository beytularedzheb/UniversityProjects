#include <iostream>
using namespace std;

struct Gost {
	char ime[21];
	char egn[11];
	unsigned short semeinoPolozhenie;
	unsigned int broiNoshtuvki;
	float cenaNaLeglo;
	char naselenoMqsto[26];
};

void DobavqneNaGoti(Gost gosti[], unsigned broi) {
	for (int i = 0; i < broi; i++) {
		cout << endl << "Ime: "; 
		cin >> gosti[i].ime;
		do {
			cout << "EGN: ";
			cin >> gosti[i].egn;
		} while (strlen(gosti[i].egn) != 10);

		do {
			cout << "Semeino polozhenie (1-nesemeen, 2-semeen): ";
			cin >> gosti[i].semeinoPolozhenie;
		} while (gosti[i].semeinoPolozhenie != 1 && gosti[i].semeinoPolozhenie != 2);
		cout << "Broi noshtuvki: ";
		cin >> gosti[i].broiNoshtuvki;
		cout << "Cena na polzvanoto leglo: ";
		cin >> gosti[i].cenaNaLeglo;
		cout << "Naseleno mqsto: ";
		cin >> gosti[i].naselenoMqsto;
	} 
}

void IzvezhdaneNaGostite(Gost gosti[], unsigned broi) {
	for (int i = 0; i < broi; i++) {
		cout << endl << gosti[i].ime;
		cout << endl << gosti[i].egn;
		if (gosti[i].semeinoPolozhenie == 1) {
			cout << endl << "nesemeen";
		}
		else {
			cout << endl << "semeen";
		}
		cout << endl << gosti[i].broiNoshtuvki;
		cout << endl << gosti[i].cenaNaLeglo;
		cout << endl << gosti[i].naselenoMqsto << endl;
	}
}

void ZaplatenaSumaOt(Gost gosti[], unsigned broi) {
	bool imaLiGosti = false;
	float suma = 0.0f;
	char naselenoMqsto[26];
	cout << endl << "Vuvedete naselenoto mqsto: ";
	cin >> naselenoMqsto;
	for (int i = 0; i < broi; i++)
	{
		if (gosti[i].semeinoPolozhenie == 2 &&
			strcmp(naselenoMqsto, gosti[i].naselenoMqsto) == 0) {
			cout << endl << endl << "Gost: " << gosti[i].ime;
			cout << endl << "Zaplatena suma: " << gosti[i].cenaNaLeglo * gosti[i].broiNoshtuvki;
			suma += (gosti[i].cenaNaLeglo * gosti[i].broiNoshtuvki);
			imaLiGosti = true;
		}
	}

	if (imaLiGosti) {
		cout << endl << "Obshta suma, zaplatena ot gostite ot " << naselenoMqsto << ": " << suma << endl;
	}
	else {
		cout << endl << "Nqma semeini gosti ot tova naseleno mqsto!" << endl;
	}
}

int BroiNesemeiniMuzhe(Gost gosti[], unsigned broi, char godina[5]) {
	int broiNesemeiniMuzhe = 0;

	for (int i = 0; i < broi; i++)
	{
		if (gosti[i].semeinoPolozhenie == 1 && 
			(gosti[i].egn[8] - '0') % 2 == 0 && 
			gosti[i].egn[0] == godina[2] &&
			gosti[i].egn[1] == godina[3]) {
			broiNesemeiniMuzhe++;
		}
	}

	return broiNesemeiniMuzhe;
}

void CopyNesemeini(Gost gosti[], unsigned broi, char godina[5], Gost nesemeini[], unsigned broiNesemeiniMuzhe)
{
	if (broiNesemeiniMuzhe > 0) {
		int indexNesemeini = 0;

		for (int i = 0; i < broi; i++)
		{
			if (gosti[i].semeinoPolozhenie == 1 &&
				(gosti[i].egn[8] - '0') % 2 == 0 &&
				gosti[i].egn[0] == godina[2] &&
				gosti[i].egn[1] == godina[3]) {
				strcpy(nesemeini[indexNesemeini].ime, gosti[i].ime);
				strcpy(nesemeini[indexNesemeini].egn, gosti[i].egn);
				nesemeini[indexNesemeini].semeinoPolozhenie = gosti[i].semeinoPolozhenie;
				nesemeini[indexNesemeini].broiNoshtuvki = gosti[i].broiNoshtuvki;
				nesemeini[indexNesemeini].cenaNaLeglo = gosti[i].cenaNaLeglo;
				strcpy(nesemeini[indexNesemeini].naselenoMqsto, gosti[i].naselenoMqsto);
				indexNesemeini++;
			}
		}
		cout << endl << "Masivyt e suzdaden!" << endl;
	}
	else {
		cout << endl << "Nqma nesemeini muzhe!" << endl;
	}
}

void main(void) {
	int choice;
	int broiGosti = 0, broiNesemeiniMuzhe = 0;
	char godina[5];
	Gost *gosti = NULL, *nesemeini = NULL;

	do
	{
		cout << endl << "\t\tMENU";
		cout << endl << "1. Dobavqne na gosti;";
		cout << endl << "2. Izvezhdane na gostite;";
		cout << endl << "3. Izvezhdane imenata i zaplatenata suma ot semeinite gosti";
		cout << endl << "   ot zadadeno naseleno mqsto;";
		cout << endl << "4. Syzdavane na nov masiv s dannite na nesemeinite muzhe,";
		cout << endl << "   rodeni prez posochena godina";
		cout << endl << "Izberete operaciq ili 0 za izhod: ";
		cin >> choice;

		switch (choice)
		{
		case 1:
			if (broiGosti == 0) {
				cout << endl << "Zadaite broq na gostite: ";
				cin >> broiGosti;
				gosti = new Gost[broiGosti];
				DobavqneNaGoti(gosti, broiGosti);
			}
			else {
				cout << endl << "Masivyt s gostite veche e syzdaden!" << endl;
			}
			break;
		case 2: 
			int ch;
			cout << endl << "1. Gosti";
			cout << endl << "2. Nesemeini muzhe" << endl;
			cin >> ch;
			if (ch == 1 && gosti != NULL) {
				IzvezhdaneNaGostite(gosti, broiGosti);
			}
			else if (ch == 2 && nesemeini != NULL) {
				IzvezhdaneNaGostite(nesemeini, broiNesemeiniMuzhe);
			}
			break;
		case 3:
			ZaplatenaSumaOt(gosti, broiGosti);
			break;
		case 4:
			if (nesemeini == NULL)
			{
				do
				{
					cout << endl << "Vuvedete godinata (primer: 1991): ";
					cin >> godina;
				} while (strlen(godina) != 4);

				broiNesemeiniMuzhe = BroiNesemeiniMuzhe(gosti, broiGosti, godina);
				nesemeini = new Gost[broiNesemeiniMuzhe];
				CopyNesemeini(gosti, broiGosti, godina, nesemeini, broiNesemeiniMuzhe);
			}
			break;
		}
	} while (choice != 0);

	delete[] gosti;
	delete[] nesemeini;
}